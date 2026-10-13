using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliverySystem
{
    internal static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("=========================================="); 
        }

        public static void PrintSystemTitle(string title)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine(title); 
            Console.WriteLine("==========================================");
        }
    }
}
