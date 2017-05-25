using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace KursTRPO.Models
{
    [Table("TechnologicalProcesses", Schema = "TechProcProd")]
    public class TechnologicalProcesses
    {
        public TechnologicalProcesses()
        {
            Routes = new List<Route>();
            Operations = new HashSet<Operation>();
        }
        [Key]
        public int TechProcId { get; set; }

        public string Name { get; set; }

        public int MaterialId { get; set; }

        public string TypeByExecution { get; set; }

        public int ActNumber { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime DateStartTechProc { get; set; }
        public ICollection<Route> Routes { get; set; }

        [ForeignKey("MaterialId")]
        public Material Material { get; set; }

        public ICollection<Operation> Operations { get; set; }       
    }

    public class AddTppModel
    {
        [Required(ErrorMessage ="Заполните поле «Название»")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле «Материал»")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Заполните поле «Тип по методу выполнения»")]
        public string TypeByExecution { get; set; }

        [Required(ErrorMessage = "Заполните поле «Номер акта»")]
        public int ActNumber { get; set; }

        [Required(ErrorMessage = "Заполните поле «Дата внедрения»")]
        [DataType(DataType.Date)]
        public DateTime DateStartTechProc { get; set; }

        [Required(ErrorMessage = "Заполните поле «Операции»")]
        public IEnumerable<string> selectedOperations { get; set; }

        public IEnumerable<SelectListItem> listmaterial { get; set; }
        public IEnumerable<SelectListItem> operationList { get; set; }

        public AddTppModel()
        {
            selectedOperations = new List<string>();

            TppContext db = new TppContext();

            List<SelectListItem> temp = new List<SelectListItem>();

            foreach (Material mt in db.Materials)
            {
                temp.Add(new SelectListItem()
                {
                    Text = mt.Name,
                    Value = mt.MaterialId.ToString()
                });
            }
            listmaterial = temp;

            temp = new List<SelectListItem>();
            foreach (Operation op in db.Operations)
            {
                temp.Add(new SelectListItem()
                {
                    Text = op.Name,
                    Value = op.OperationId.ToString()
                });
            }
            operationList = temp;
        }
    }
}
