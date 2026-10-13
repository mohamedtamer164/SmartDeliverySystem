using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal abstract partial class  Shipment : ITrackable, IInsurable
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public static int TotalShipmentsCreated { get; private set; } = 0;
        public string TrackingCode // Read-only property ان هو يقرا الداتا بس ما يكتبها
        {
            get { return trackingCode; }
        }

        public string Description // Read-write property ان هو يقرا الداتا ويكتبها
                                  // بس شرط انها متكونش  Null او Empty
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }

        }
        public decimal Weight // Read-write property ان هو يقرا الداتا ويكتبها
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        public decimal DeliveryFee // Read-only property ان هو يقرا الداتا بس ما يكتبها
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }
        public DeliveryAddress Destination { get; set; } // Read-write property ان هو يقرا الداتا ويكتبها
        public virtual decimal EstimatedCost => DeliveryFee + (decimal)(Weight * 5);
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized"); 
        }
        public Shipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                trackingCode = "Unknown";
            }

            this.trackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress();
        }

        public Shipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                trackingCode = "Unknown";
            }

            this.trackingCode = trackingCode;

            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
            TotalShipmentsCreated++;
        }

        #region Methods
        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }
        public void UpdateWeight(decimal newWeight, decimal packingWeight)
        {
            if (newWeight > 0 && packingWeight >= 0)
            {
                Weight = newWeight + packingWeight;
            }
        }
        public virtual void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                deliveryFee = newFee;
            }
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Generating standard customs report for international shipment.");
        }
        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee:C}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost:C}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine("----------------------------------------");
        }
        public static int GetTotalShipmentsCreated() => TotalShipmentsCreated;
        public abstract Shipment CopyShipment();
        // 2. Shallow Copy باستخدام MemberwiseClone()
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }
        // 3. Deep Copy (إنشاء كائن جديد وكائن عنوان جديد)
        public abstract Shipment DeepCopy();
        public abstract string GetTrackingStatus();
        public abstract decimal CalculateInsurance();
    }
        #endregion

}

