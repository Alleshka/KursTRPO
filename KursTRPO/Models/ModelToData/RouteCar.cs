using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace KursTRPO.Models
{
    [Table("RouteCar", Schema = "TechProcProd")]
    public class RouteCar
    {
        [Key]
        public int RouteCarId { get; set; }

        public int RouteId { get; set; }

        public string CompanyName { get; set; }

        public string Developer { get; set; }

        public string Checked { get; set; }

        public string Agreed { get; set; }

        public string Approved { get; set; }

        public string NormСontroller { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
    }
    public class AddRouteCarModel
    {
        public int RouteId { get; set; }

        public string CompanyName { get; set; }

        public string Developer { get; set; }

        public string Checked { get; set; }

        public string Agreed { get; set; }

        public string Approved { get; set; }

        public string NormСontroller { get; set; }

        public IEnumerable<SelectListItem> routeList { get; set; }
        public IEnumerable<SelectListItem> developList { get; set; }

        public AddRouteCarModel()
        {
            TppContext db = new TppContext();

            List<SelectListItem> temp = new List<SelectListItem>();

            foreach (var r in db.Routes)
            {
                temp.Add(new SelectListItem()
                {
                    Text = r.RouteId.ToString(),
                    Value = r.RouteId.ToString()
                });
            }
            routeList = temp;
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

    public class ViewRouteCarModel
    {
        public RouteCar _rc;

        public string DeveloperString { get; set; }

        public string CheckedString { get; set; }

        public string AgreedString { get; set; }

        public string ApprovedString { get; set; }

        public string NormСontrollerString { get; set; }

    }
}
