using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
    
    public override string GetTrackingStatus() => "Delivered";

        public override decimal CalculateInsurance() => EstimatedCost * 0.05m;

        public override Shipment CopyShipment()
        {
            return new CompletedShipment(TrackingCode, Description, Weight, DeliveryFee, Destination);
        }

        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return new CompletedShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress);
        }
    }

}
