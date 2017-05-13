using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KursTRPO.Models
{
    [Table("Route", Schema = "TechProcProd")]
    public class Route
    {
        public Route()
        {
            RouteCars = new List<RouteCar>();
        }
        [Key]
        public int RouteId { get; set; }

        public int TechProcId { get; set; }

        public string NameTechProc { get; set; }

        public int NameOfDeveloper { get; set; }

        public string DetailsDesignation { get; set; }

        public string DetailsName { get; set; }

        public ICollection<RouteCar> RouteCars { get; set; }
        
        [ForeignKey("TechProcId")]
        public TechnologicalProcesses TechnologicalProcesses { get; set; }
    }
}
