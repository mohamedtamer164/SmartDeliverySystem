using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal abstract partial class Shipment
    {
        private string trackingStatus = "In Transit";

        public string TrackingStatus
        {
            get => trackingStatus;
            set
            {
                if (trackingStatus != value)
                {
                    trackingStatus = value;
                    OnTrackingStatusChanged(trackingStatus);
                }
            }
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
        }

        // إعلان الدالة الجزئية (Partial Method)
        partial void OnTrackingStatusChanged(string newStatus);
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}"); 
        }
    }
}

