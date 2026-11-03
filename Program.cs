using System;
using System.Collections.Generic;

namespace MaintenanceCenter
{
    public class Program
    {
        // الدالة الرئيسية لتشغيل واختبار ترابط كامل ملفات النظام
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Home Appliance Maintenance System ===");

            // إنشاء قائمة برمجية موحدة من صنف الأب لتطبيق تعدد الأشكال
            List<Appliance> maintenanceList = new List<Appliance>();
            NotificationService notifier = new NotificationService();

            // إنشاء الأجهزة وتطبيق فحص المدخلات الساكن قبل الإضافة
            string sn1 = "REF101";
            if (MaintenanceValidator.ValidateSerialNumber(sn1))
                maintenanceList.Add(new Refrigerator(sn1, "L.G", 40000, true));

            string sn2 = "WSH202";
            if (MaintenanceValidator.ValidateSerialNumber(sn2))
                maintenanceList.Add(new WashingMachine(sn2, "Samsung", 50000, false));

            string sn3 = "AIR303";
            if (MaintenanceValidator.ValidateSerialNumber(sn3))
                maintenanceList.Add(new AirConditioner(sn3, "Gree", 60000, true));

            // ربط كائنات الأجهزة بحدث الإشعارات الآلي (الاشتراك بالحدث)
            foreach (var appliance in maintenanceList)
            {
                appliance.StatusChanged += notifier.OnApplianceStatusChanged;
            }

            Console.WriteLine("\n--- Displaying Appliances & Costs (Polymorphism): ---");
            double totalCost = 0;
            foreach (var app in maintenanceList)
            {
                // استدعاء دالة العرض المتعددة الأشكال بحسب نوع الكائن الحالي
                app.DisplayApplianceInfo();
                totalCost += app.CalculateTotalRepairCost();
            }
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"Total Expected Repair Revenue: {totalCost} SYP");

            Console.WriteLine("\n--- Simulating Maintenance Updates (Events Triggering): ---");
            // محاكاة تعديل الحالات لاختبار انطلاق الأحداث التلقائية
            foreach (var app in maintenanceList)
            {
                if (app is Refrigerator || app is WashingMachine)
                {
                    app.UpdateStatus("Repaired and Completed");
                }
            }

            Console.WriteLine("\n--- System Statistics (Static Members): ---");
            // استخدام الدوال الساكنة لطباعة الإحصاء النهائي للأجهزة المنجزة
            int completedCount = MaintenanceValidator.CountAppliancesByStatus(maintenanceList, "Repaired and Completed");
            Console.WriteLine($"Number of successfully repaired appliances: {completedCount}");

            Console.ReadLine();
        }
    }
}
