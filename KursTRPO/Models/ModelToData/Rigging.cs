using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursTRPO.Models
{
    [Table("Rigging", Schema = "TechProcProd")]
    public class Rigging
    {
        public Rigging()
        {
            Operations = new HashSet<Operation>();
        }
        public int RiggingId { get; set; }

        public string Name { get; set; }

        public string TypeOfTool { get; set; }

        public int Quantity { get; set; }

        
        public virtual ICollection<Operation> Operations { get; set; }
    }


    public class AddRiggingModel
    {
        [Required(ErrorMessage = "Заполните поле «Название»")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Заполните поле «Вид инструмента»")]
        public string TypeOfTool { get; set; }
        [Required(ErrorMessage ="Заполните поле «Количество»")]
        public int Quntity { get; set; }
    }
}
