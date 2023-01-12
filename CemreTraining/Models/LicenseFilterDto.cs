using System.ComponentModel;

namespace CemreTraining.Models
{
    public class LicenseFilterDto
    {
        public string Licence { get; set; }

        public MaintenanceType MaintenanceType { get; set; }

        public DateTime MaintenanceDate { get; set; }

        public DateTime FutureMaintenanceDate { get; set; }

        public int MaintenanceKm { get; set; }

        public int FutureMaintenanceKm { get; set; }

        public int MaintenanceCost { get; set; }

    }

    public enum MaintenanceType
    {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3
    }
}