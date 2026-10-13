using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private decimal extrafee;
        public decimal ExtraFee
        {
            get
            {
                return extrafee;
            }
            set
            {
                if (value > 0)
                {
                    extrafee = value;
                }

            }
        }
        public override decimal EstimatedCost => base.EstimatedCost + ExtraFee;
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override string GetTrackingStatus() => TrackingStatus;
        public override decimal CalculateInsurance() => EstimatedCost * 0.08m;
        public override Shipment CopyShipment() => new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, Destination, ExtraFee);

        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, ExtraFee);
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee:C}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost:C}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Extra Fee      : {ExtraFee} EGP");
            Console.WriteLine("----------------------------------------");
        }
    }
}
