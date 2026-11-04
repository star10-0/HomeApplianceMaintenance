using System;

namespace MaintenanceCenter
{
    // تطبيق مفهوم الوراثة وتعدد الأشكال من خلال الصفوف المشتقة

    // 1. صف البراد
    public class Refrigerator : Appliance
    {
        public bool HasGasLeak { get; set; }

        public Refrigerator(string serialNumber, string brand, double baseRepairCost, bool hasGasLeak)
            : base(serialNumber, brand, baseRepairCost)
        {
            HasGasLeak = hasGasLeak;
        }

        // إعادة تعريف دالة الحساب لتشمل تكلفة معالجة تسريب الغاز
        public override double CalculateTotalRepairCost()
        {
            return BaseRepairCost + (HasGasLeak ? 50000 : 0);
        }

        public override void DisplayApplianceInfo()
        {
            Console.Write("[Refrigerator] ");
            base.DisplayApplianceInfo();
        }
    }

    // 2. صف الغسالة
    public class WashingMachine : Appliance
    {
        public bool NeedsMotorReplacement { get; set; }

        public WashingMachine(string serialNumber, string brand, double baseRepairCost, bool needsMotorReplacement)
            : base(serialNumber, brand, baseRepairCost)
        {
            NeedsMotorReplacement = needsMotorReplacement;
        }

        // إعادة تعريف دالة الحساب لتشمل تكلفة استبدال المحرك
        public override double CalculateTotalRepairCost()
        {
            return BaseRepairCost + (NeedsMotorReplacement ? 75000 : 0);
        }

        public override void DisplayApplianceInfo()
        {
            Console.Write("[WashingMachine] ");
            base.DisplayApplianceInfo();
        }
    }

    // 3. صف المكيف
    public class AirConditioner : Appliance
    {
        public bool NeedsFilterCleaningOnly { get; set; }

        public AirConditioner(string serialNumber, string brand, double baseRepairCost, bool needsFilterCleaningOnly)
            : base(serialNumber, brand, baseRepairCost)
        {
            NeedsFilterCleaningOnly = needsFilterCleaningOnly;
        }

        // إعادة تعريف دالة الحساب بناءً على نوع الصيانة المطلوبة للمكيف
        public override double CalculateTotalRepairCost()
        {
            if (NeedsFilterCleaningOnly) return 15000;
            return BaseRepairCost + 30000;
        }

        public override void DisplayApplianceInfo()
        {
            Console.Write("[AirConditioner] ");
            base.DisplayApplianceInfo();
        }
    }
}
