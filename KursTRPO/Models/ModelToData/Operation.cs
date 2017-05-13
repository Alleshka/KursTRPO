using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursTRPO.Models
{
    [Table("Operation", Schema = "TechProcProd")]
    public class Operation
    {
        public Operation()
        {
            TechnologicalProcesseses = new List<TechnologicalProcesses>();
        }
        public int OperationId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int TransitionId { get; set; }

        public string TransitionName { get; set; }

        public int EquipmentId { get; set; }

        public int RiggingId { get; set; }

        public int DepartmentNumber { get; set; }

        public int SiteNumber { get; set; }

        public int WorkplaceNumber { get; set; }

        public ICollection<TechnologicalProcesses> TechnologicalProcesseses { get; set; }

        [ForeignKey("EquipmentId")]
        public Equipment Equipment { get; set; }

        [ForeignKey("RiggingId ")]
        public Rigging Rigging { get; set; }

        [ForeignKey("TransitionId")]
        public Transition Transition { get; set; }

    }
}
