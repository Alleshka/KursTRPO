using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KursTRPO.Models
{
    [Table("Operation", Schema = "TechProcProd")]
    public class Operation
    {
        public Operation()
        {
            TechnologicalProcesseses = new HashSet<TechnologicalProcesses>();
            Riggings = new HashSet<Rigging>();
        }
        public int OperationId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int TransitionId { get; set; }

        public string TransitionName { get; set; }

        public int EquipmentId { get; set; }

        public virtual ICollection<Rigging> Riggings { get; set; }

        public int DepartmentNumber { get; set; }

        public int SiteNumber { get; set; }

        public int WorkplaceNumber { get; set; }

        public virtual ICollection<TechnologicalProcesses> TechnologicalProcesseses { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }

        [ForeignKey("TransitionId")]
        public virtual Transition Transition { get; set; }
    }


    public class AddOperationModel
    {
        [Required(ErrorMessage ="Заполните поле «Название»")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер операции»")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер перехода»")]
        public int TransitionId { get; set; }

        [Required(ErrorMessage = "Заполните поле «Название перехода»")]
        public string TransitionName { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер оборудования»")]
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер цеха»")]
        public int DepartmentNumber { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер участка»")]
        public int SiteNumber { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер рабочего места»")]
        public int WorkplaceNumber { get; set; }

        public IEnumerable<SelectListItem> equipList { get; set; }
        public IEnumerable<SelectListItem> transList { get; set; }
        public IEnumerable<SelectListItem> riggingList { get; set; }

        [Required(ErrorMessage = "Оснастка")]
        public IEnumerable<string> selectRigging { get; set; } 

        public AddOperationModel()
        {        
            TppContext db = new TppContext();

            List<SelectListItem> temp = new List<SelectListItem>();
            temp = new List<SelectListItem>();
            foreach (Equipment eq in db.Equipments)
            {
                temp.Add(new SelectListItem()
                {
                    Text = eq.Name,
                    Value = eq.EquipmentId.ToString()
                });
            }
            this.equipList = temp;

            temp = new List<SelectListItem>();
            foreach (Transition tr in db.Transitions)
            {
                temp.Add(new SelectListItem()
                {
                    Text = tr.Keyword,
                    Value = tr.TransitionId.ToString()
                });
            }
            this.transList = temp;

            temp = new List<SelectListItem>();
            foreach (Rigging rg in db.Riggings)
            {
                temp.Add(new SelectListItem()
                {
                    Text = rg.Name,
                    Value = rg.RiggingId.ToString()
                });
            }
            this.riggingList = temp;            
        }
    }
}
