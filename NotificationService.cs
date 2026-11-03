using System;

namespace MaintenanceCenter
{
    // صف مستقل مسؤول عن معالجة الأحداث وطباعة الإشعارات فور تحقق الشرط
    public class NotificationService
    {
        // الدالة المستهدفة التي يتم استدعاؤها تلقائياً عند إطلاق حدث تغيير الحالة
        public void OnApplianceStatusChanged(Appliance appliance, string newStatus)
        {
            Console.WriteLine($"[Notification]: Appliance [{appliance.SerialNumber}] status updated to -> ({newStatus})");
        }
    }
}
