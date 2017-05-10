using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursTRPO.Models
{
    [Table("Material", Schema = "TechProcProd")]
    public class Material
    {
        public Material()
        {
            TechnologicalProcesseses = new List<TechnologicalProcesses>();
        }
        public int MaterialId { get; set; }

        public string Assortment { get; set; }

        public string Name { get; set; }

        public string Stamp { get; set; }

        public string DesignOfStandard { get; set; }
        public ICollection<TechnologicalProcesses> TechnologicalProcesseses { get; set; }


    }
}
