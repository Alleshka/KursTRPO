using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursTRPO.Models
{
    [Table("RouteCar", Schema = "TechProcProd")]
    public class RouteCar
    {
        [Key]
        public int RouteCarId { get; set; }

        public int RouteId { get; set; }

        public string CompanyName { get; set; }

        public int Developer { get; set; }

        public int Checked { get; set; }

        public int Agreed { get; set; }

        public int Approved { get; set; }

        public int NormСontroller { get; set; }
        [ForeignKey("RouteId")]
        public Route Route { get; set; }

    }
}
