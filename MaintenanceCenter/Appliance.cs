using System;

namespace MaintenanceCenter
{
    // الفئة المجردة الأساسية التي ترث منها بقية صفوف الأجهزة
    public abstract class Appliance : IMaintenanceOperations
    {
        // حقول خاصة لتطبيق مفهوم التغليف ومنع الوصول المباشر
        private string _serialNumber;
        private string _brand;
        private string _status;
        private double _baseRepairCost;

        // خصائص للقراءة فقط لحماية البيانات الحساسة بعد الإنشاء
        public string SerialNumber => _serialNumber;
        public string Brand => _brand;

        // خاصية التحكم بالحالة مع تفعيل إطلاق الحدث عند التعديل
        public string Status
        {
            get => _status;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _status = value;
                    OnStatusChanged(value); // استدعاء دالة إطلاق الحدث
                }
            }
        }

        public double BaseRepairCost
        {
            get => _baseRepairCost;
            set => _baseRepairCost = value < 0 ? 0 : value; // التحقق من صحة القيمة المالية
        }

        // تعريف المفوض والحدث الخاص بتعديل حالة الجهاز
        public delegate void StatusChangedEventHandler(Appliance appliance, string newStatus);
        public event StatusChangedEventHandler StatusChanged;

        protected virtual void OnStatusChanged(string newStatus)
        {
            StatusChanged?.Invoke(this, newStatus);
        }

        // الباني الأساسي لتهيئة قيم الجهاز عند دخوله الصيانة
        protected Appliance(string serialNumber, string brand, double baseRepairCost)
        {
            _serialNumber = serialNumber;
            _brand = brand;
            _baseRepairCost = baseRepairCost;
            _status = "Pending";
        }

        // دالة مجردة لحساب التكلفة الإجمالية يتم تفصيلها داخل الصفوف الابنة
        public abstract double CalculateTotalRepairCost();

        // تحقيق دالة العرض التابعة للواجهة الأساسية
        public virtual void DisplayApplianceInfo()
        {
            Console.WriteLine($"SN: {SerialNumber} | Brand: {Brand} | Status: {Status} | Cost: {CalculateTotalRepairCost()} SYP");
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
    }
}
