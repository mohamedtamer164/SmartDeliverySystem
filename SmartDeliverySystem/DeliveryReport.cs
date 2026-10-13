using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal static class DeliveryReport
    {
        public static void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }
        public static void PrintInsurance(IInsurable shipment)
    {
        // استخدام تقسيم اسم الكلاس لطباعة التنسيق المطلوب
        string typeName = shipment.GetType().Name.Replace("Shipment", " Shipment");
        Console.WriteLine($"{typeName} Insurance : {shipment.CalculateInsurance():F2} EGP");
    }
}
}
