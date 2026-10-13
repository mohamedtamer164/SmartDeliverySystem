using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal class DeliveryCenter
    {
        private Shipment[] shipments; // indexrs
        private int count;
        public string CenterName { get; set; }
        public Driver AssignedDriver { get; set; }
        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
            shipments = new Shipment[20]; // السعة 20 شحنة
            count = 0;
        }
        public DeliveryCenter(int capacity)
        {
            shipments = new Shipment[capacity];
            count = 0;
        }

        // مؤشر الأرقام (Integer Indexer)
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];
                return default;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
            }
        }

        // مؤشر النصوص (String Indexer) للبحث برمز التتبع
        public Shipment this[string trackingCode]
        {
            get
            {
                foreach (var shipment in shipments)
                {
                    if (shipment.TrackingCode == trackingCode)
                        return shipment;
                }
                return default;
            }
        }

        // دالة لإضافة شحنة جديدة
        public bool AddShipment(Shipment shipment)
        {
            if (count < shipments.Length)
            {
                shipments[count] = shipment;
                count++;
                return true;
            }
            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            int foundIndex = -1;
            for (int i = 0; i < count; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex != -1)
            {
                // إعادة ترتيب المصفوفة لسد الفراغ الناتج عن الحذف
                for (int i = foundIndex; i < count - 1; i++)
                {
                    shipments[i] = shipments[i + 1];
                }
                shipments[count - 1] = null;
                count--;
                return true;
            }

            return false;
        }
        public void PrintTrackingStatuses()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("Tracking Status");
        Console.WriteLine("==========================================");
        Console.WriteLine();

        for (int i = 0; i<count; i++)
        {
            if (shipments[i] is ITrackable trackable)
            {
                Console.WriteLine(trackable.GetTrackingStatus());
                Console.WriteLine();
            }
}
    }
        public void PrintAllShipments()
        {
            Console.WriteLine($"==========================================");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine($"==========================================");

            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is StandardShipment)
                    Console.WriteLine("\nStandard Shipment\n");
                else if (shipments[i] is ExpressShipment)
                    Console.WriteLine("\nExpress Shipment\n");
                else if (shipments[i] is InternationalShipment)
                    Console.WriteLine("\nInternational Shipment\n");

                shipments[i].PrintShipment();
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}

