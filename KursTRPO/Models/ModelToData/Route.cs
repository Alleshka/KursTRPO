using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web;


namespace KursTRPO.Models
{
    [Table("Route", Schema = "TechProcProd")]
    public class Route
    {
        public Route()
        {
            RouteCars = new List<RouteCar>();
        }
        [Key]
        public int RouteId { get; set; }

        public int TechProcId { get; set; }

        public string NameTechProc { get; set; }

        public string NameOfDeveloper { get; set; }

        public string DetailsDesignation { get; set; }

        public string DetailsName { get; set; }

        public ICollection<RouteCar> RouteCars { get; set; }
        
        [ForeignKey("TechProcId")]
        public TechnologicalProcesses TechnologicalProcesses { get; set; }
    }

    public class AddRouteModel
    {
        [Required]
        public int TechProcId { get; set; }

        [Required]
        public string NameTechProc { get; set; }

        [Required]
        public string NameOfDeveloper { get; set; }

        [Required]
        public string DetailsDesignation { get; set; }

        [Required]
        public string DetailsName { get; set; }

        public IEnumerable<SelectListItem> techprocList { get; set; }
        public IEnumerable<SelectListItem> developList { get; set; }

        public AddRouteModel()
        {
            TppContext db = new TppContext();

            List<SelectListItem> temp = new List<SelectListItem>();

            foreach (TechnologicalProcesses tp in db.TechnologicalProcesseses)
            {
                temp.Add(new SelectListItem()
                {
                    Text = tp.Name,
                    Value = tp.TechProcId.ToString()
                });
            }
            techprocList = temp;
        }
        public void SetDevelopList(IEnumerable<ApplicationUser> usrlist)
        {
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (ApplicationUser us in usrlist)
            {
                temp.Add(new SelectListItem()
                {
                    Text = us._UserFIO,
                    Value = us.Id
                });
            }
            developList = temp;
        }
    }

    public class ViewRouteModel
    {
        public Route _route;

        public string DevelopNameString { get; set; }
    }
}
