using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal class StandardShipment : Shipment, ITrackable, IInsurable
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
        public override string GetTrackingStatus() => TrackingStatus;

        public override decimal CalculateInsurance() => EstimatedCost * 0.05m;

        // إضافة دالة النسخ العادي
        public override Shipment CopyShipment()
        {
            return new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, Destination);
        }

        // إضافة دالة النسخ العميق
        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress);
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }


}


