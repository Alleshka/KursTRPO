using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
}
