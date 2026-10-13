using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string typeName = shipment.GetType().Name.Replace("Shipment", "");
            return $"{shipment.TrackingCode} | {typeName} | {shipment.Weight} KG | {shipment.TrackingStatus}"; 
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.TrackingStatus.Equals("Delivered", StringComparison.OrdinalIgnoreCase);   
        }
    }
}
