using System;
using System.Collections.Generic;

namespace MaintenanceCenter
{
    // صف ساكن يحتوي على أدوات التحقق وحساب الإحصائيات العامة للمجموعة
    public static class MaintenanceValidator
    {
        // دالة ساكنة للتحقق من طول وصحة الرقم التسلسلي للمنتج
        public static bool ValidateSerialNumber(string serialNumber)
        {
            return !string.IsNullOrEmpty(serialNumber) && serialNumber.Length >= 5;
        }

        // دالة ساكنة للمرور على القائمة وحساب الأجهزة المطابقة لحالة معينة
        public static int CountAppliancesByStatus(List<Appliance> appliances, string targetStatus)
        {
            int count = 0;
            foreach (var app in appliances)
            {
                if (app.Status == targetStatus) count++;
            }
            return count;
        }
    }
}
