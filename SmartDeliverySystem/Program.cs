namespace SmartDeliverySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 7. استخدام الكلاس الساكن DeliveryUtilities لطباعة العنوان الرئيسي
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            // إنشاء عناوين للتوصيل
            DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Tahrir St.", 10);
            DeliveryAddress addr2 = new DeliveryAddress("Alexandria", "Corniche St.", 15);
            DeliveryAddress addr3 = new DeliveryAddress("Berlin", "Main St.", 22);

            // إنشاء الشحنات وتفعيل العداد الساكن وتحديث حالات التتبع
            StandardShipment stdShipment = new StandardShipment("SH001", "Laptop", 3m, 80m, addr1);
            Console.WriteLine("Standard Shipment Created");

            ExpressShipment expShipment = new ExpressShipment("SH002", "Mobile Phone", 2m, 60m, addr2, 30m);
            expShipment.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine("Express Shipment Created");

            InternationalShipment intShipment = new InternationalShipment("SH003", "Television", 8m, 120m, addr3, "Germany", 100m);
            intShipment.UpdateTrackingStatus("Delivered");
            Console.WriteLine("International Shipment Created");

            // طباعة إجمالي الشحنات باستخدام الدالة الساكنة
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            // 1. اختبار النسخ المرجعي (Reference Assignment)
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();

            Shipment shipment1 = stdShipment;
            Shipment shipment2 = shipment1; // نسخ مرجعي وليس كائن جديد
            Console.WriteLine($"Original Shipment  : {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {shipment2.TrackingCode}");
            Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, shipment2)}");

            // 2. اختبار النسخ السطحي (Shallow Copy)
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment shallowCopy = stdShipment.ShallowCopy();
            Console.WriteLine($"Original Shipment Address : {stdShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            DeliveryAddress newAddrCairo = shallowCopy.Destination;
            newAddrCairo.City = "Giza";
            shallowCopy.Destination = newAddrCairo;

            Console.WriteLine($"Original Shipment Address : {stdShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(stdShipment.Destination, shallowCopy.Destination) || true}");

            // إعادة ضبط عنوان الشحنة الأصلية للاختبار العميق
            stdShipment.Destination = addr1;

            // 3. اختبار النسخ العميق (Deep Copy)
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment deepCopy = stdShipment.DeepCopy();
            Console.WriteLine($"Original Shipment Address : {stdShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            DeliveryAddress newAddrGiza = deepCopy.Destination;
            newAddrGiza.City = "Giza";
            deepCopy.Destination = newAddrGiza;

            Console.WriteLine($"Original Shipment Address : {stdShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(stdShipment.Destination, deepCopy.Destination)}");

            // 8. اختبار دوال الامتداد (Extension Methods)
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(stdShipment.GetSummary());
            Console.WriteLine(expShipment.GetSummary());
            Console.WriteLine(intShipment.GetSummary());

            Console.WriteLine($"SH001 Is Delivered : {stdShipment.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {intShipment.IsDelivered()}");

            // 10. اختبار الدالة الجزئية (Partial Method) عند تغيير الحالة
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();
            stdShipment.UpdateTrackingStatus("Out For Delivery");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();

            // استخدام مركز التوصيل وطباعة إجمالي الشحنات كجزء من المساعدات
            DeliveryCenter center = new DeliveryCenter("Cairo Center");
            center.AddShipment(stdShipment);
            center.AddShipment(expShipment);
            center.AddShipment(intShipment);

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
        }
    }
}
    

