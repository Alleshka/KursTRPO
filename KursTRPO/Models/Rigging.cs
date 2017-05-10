using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursTRPO.Models
{
    [Table("Rigging", Schema = "TechProcProd")]
    public class Rigging
    {
        public Rigging()
        {
            Operations = new List<Operation>();
        }
        public int RiggingId { get; set; }

        public string Name { get; set; }

        public string TypeOfTool { get; set; }

        public int Quantity { get; set; }

        public ICollection<Operation> Operations { get; set; }

    }
}
