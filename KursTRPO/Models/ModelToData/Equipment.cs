using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursTRPO.Models
{
    [Table("Equipment", Schema = "TechProcProd")]
    public class Equipment
    {
        public Equipment()
        {
            Operations = new List<Operation>();
        }
        
        public int EquipmentId { get; set; }

        public int DetailNumber { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Department { get; set; }

        public ICollection<Operation> Operations { get; set; }  
    }

    public class AddEqupmentModel
    {
        [Required(ErrorMessage ="Заполните поле «Название»")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле «Количество»")]
        public int Quntity { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер детали»")]
        public int DetailNumber { get; set; }

        [Required(ErrorMessage = "Заполните поле «Цех»")]
        public string Department { get; set; }
    }
}
