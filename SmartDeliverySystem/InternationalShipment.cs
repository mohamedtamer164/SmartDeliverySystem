using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string destinationCountry;
        private decimal customsFee;
        public InternationalShipment(
     string trackingCode,
     string description,
     decimal weight,
     decimal deliveryFee,
     DeliveryAddress destination,
     string destinationCountry,
     decimal customsFee)
     : base(trackingCode, description, weight, deliveryFee, destination)
        { }

        public string DestinationCountry
        {
            get
            {
                return destinationCountry;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;

                }
            }
        }
        public decimal CustomsFee
        {
            get => customsFee;
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }

        public override decimal EstimatedCost => base.EstimatedCost + CustomsFee;
        public override string GetTrackingStatus() => TrackingStatus;
        public override decimal CalculateInsurance() => EstimatedCost * 0.12m;

        public override Shipment CopyShipment() => new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, Destination, DestinationCountry, CustomsFee);

        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, DestinationCountry, CustomsFee);
        }
        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee:C}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost:C}");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee         : {CustomsFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");

            Console.WriteLine("----------------------------------------");
        }

    }
}
