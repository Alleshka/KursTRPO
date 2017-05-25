using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursTRPO.Models
{
    [Table("Transition", Schema = "TechProcProd")]
    public class Transition
    {
        public Transition()
        {
            Operations = new List<Operation>();
        }
        public int TransitionId { get; set; }

        public int TransitionNumber { get; set; }

        public string Keyword { get; set; }

        public string TransitionType { get; set; }

        public ICollection<Operation> Operations { get; set; }      
    }

    public class AddTransitionModel
    {
        [Required(ErrorMessage ="Заполните поле «Номер»")]
        public int TransitionNumber { get; set; }

        [Required(ErrorMessage ="Заполните номер «Ключевое слово»")]
        public string KeyWord { get; set; }

        [Required(ErrorMessage ="Заполните поле «Вид перехода»")]
        public string TransitionType { get; set; }
    }
}
