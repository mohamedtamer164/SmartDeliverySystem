using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal class Shipment
    {
        #region feild
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;
        #endregion

        #region Encapsulation
        public string City
        {
            get { return trackingCode; }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }
        public decimal Weight
        {
            get { return weight; }
            set
            {
             if (weight > 0)
                {
                    Weight = value;
                }
            }
        }

        #endregion

    }
}
