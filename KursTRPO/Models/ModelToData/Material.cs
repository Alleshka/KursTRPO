using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public class AddMaterialModel
    {

        [Required(ErrorMessage = "Заполните поле «Название»")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле «Сортамент»")]
        public string Assortment { get; set; }

        [Required(ErrorMessage = "Заполните поле «Печать»")]
        public string Stamp { get; set; }

        [Required(ErrorMessage ="Заполните поле «Обозначение стандарта»")]
        public string DesignOfStandart { get; set; }
    }
}
