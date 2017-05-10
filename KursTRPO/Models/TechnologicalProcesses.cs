using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursTRPO.Models
{
    [Table("TechnologicalProcesses", Schema = "TechProcProd")]
    public class TechnologicalProcesses
    {
        public TechnologicalProcesses()
        {
            Routes = new List<Route>();
        }
        [Key]
        public int TechProcId { get; set; }

        public string Name { get; set; }

        public int OperationId { get; set; }

        public int MaterialId { get; set; }

        public string TypeByExecution { get; set; }

        public int ActNumber { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime DateStartTechProc { get; set; }
        public ICollection<Route> Routes { get; set; }

        [ForeignKey("MaterialId")]
        public Material Material { get; set; }

        [ForeignKey("OperationId")]
        public Operation Operation { get; set; }
        
    }
}
