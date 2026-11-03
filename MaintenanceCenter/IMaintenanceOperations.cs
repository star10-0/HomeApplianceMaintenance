using System;

namespace MaintenanceCenter
{
    // الواجهة الأساسية لتحديد العمليات المشتركة لكل الأجهزة في المركز
    public interface IMaintenanceOperations
    {
        void DisplayApplianceInfo();
        void UpdateStatus(string newStatus);
    }
}
