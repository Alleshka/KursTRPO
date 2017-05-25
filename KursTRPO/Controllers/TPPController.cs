using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using KursTRPO.Models;
using Microsoft.AspNet.Identity.Owin;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calabonga.Xml.Exports;



namespace KursTRPO.Controllers
{
    [Authorize]
    public class TPPController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // <--------------- Просмотреть список ------------------->     
        public ActionResult Materials()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<Material> model = dbTpp.Materials;

            return View(model);
        }
        public ActionResult Equipments()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<Equipment> model = dbTpp.Equipments;

            return View(model);
        }
        public ActionResult Transitions()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<Transition> model = dbTpp.Transitions;

            return View(model);
        }
        public ActionResult Riggings()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<Rigging> model = dbTpp.Riggings;

            return View(model);
        }
        public ActionResult Operations()
        {
            TppContext db = new TppContext();
            IEnumerable<Operation> model = db.Operations;

            return View(model);

        }
        public ActionResult TechnologicalProcesses()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<TechnologicalProcesses> model = dbTpp.TechnologicalProcesseses;

            return View(model);
        }
        public ActionResult Routes()
        {
            TppContext dbTpp = new TppContext();

            List<Route> routeList;
            List<ViewRouteModel> routeViewList = new List<ViewRouteModel>();

            routeList = dbTpp.Routes.ToList();

            foreach (var temp in routeList)
            {
                ViewRouteModel mod = new ViewRouteModel();
                mod._route = temp;
                mod.DevelopNameString = UserManager.Users.First(x => x.Id == temp.NameOfDeveloper)._UserFIO;
                routeViewList.Add(mod);
            }

            return View(routeViewList);
        }
        public ActionResult RouteCars()
        {
            TppContext dbTpp = new TppContext();
            IEnumerable<RouteCar> model = dbTpp.RouteCars;

            List<ViewRouteCarModel> vrc = new List<ViewRouteCarModel>();

            foreach (RouteCar temp in model)
            {
                ViewRouteCarModel v = new ViewRouteCarModel();
                v._rc = temp;
                v.AgreedString = UserManager.Users.Where(x => x.Id == temp.Agreed).First()._UserFIO;
                v.ApprovedString = UserManager.Users.Where(x => x.Id == temp.Approved).First()._UserFIO;
                v.CheckedString = UserManager.Users.Where(x => x.Id == temp.Checked).First()._UserFIO;
                v.DeveloperString = UserManager.Users.Where(x => x.Id == temp.Developer).First()._UserFIO;
                v.NormСontrollerString = UserManager.Users.Where(x => x.Id == temp.NormСontroller).First()._UserFIO;
                vrc.Add(v);
            }

            return View(vrc);
        }

        // <--------------- !Просмотреть список ------------------->

        // <--------------- Добавление ------------------->     
        public ActionResult AddMaterial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterial(AddMaterialModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                Material temp = new Material
                {
                    Name = model.Name,
                    Assortment = model.Assortment,
                    DesignOfStandard = model.DesignOfStandart,
                    Stamp = model.Stamp
                };

                db.Materials.Add(temp);
                db.SaveChanges();
                return RedirectToAction("Materials", "TPP");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddEqupment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEqupment(AddEqupmentModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                Equipment temp = new Equipment();
                temp.Name = model.Name;
                temp.Department = model.Department;
                temp.DetailNumber = model.DetailNumber;
                temp.Quantity = model.Quntity;

                db.Equipments.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Equipments", "TPP");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddTransition()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTransition(AddTransitionModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                Transition temp = new Transition();
                temp.Keyword = model.KeyWord;
                temp.TransitionNumber = model.TransitionNumber;
                temp.TransitionType = model.TransitionType;

                db.Transitions.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Transitions");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddRigging()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRigging(AddRiggingModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                Rigging k = new Rigging();
                k.Name = model.Name;
                k.Quantity = model.Quntity;
                k.TypeOfTool = model.TypeOfTool;

                db.Riggings.Add(k);
                db.SaveChanges();

                return RedirectToAction("Riggings");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AddOperation()
        {
            AddOperationModel model = new AddOperationModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddOperation(AddOperationModel model)
        {
            if (ModelState.IsValid)
            {
                Operation temp = new Operation();
                temp.DepartmentNumber = model.DepartmentNumber;
                temp.EquipmentId = model.EquipmentId;
                temp.Name = model.Name;
                temp.Number = model.Number;
                temp.SiteNumber = model.SiteNumber;
                temp.TransitionId = model.TransitionId;
                temp.TransitionName = model.TransitionName;
                temp.WorkplaceNumber = model.WorkplaceNumber;

                TppContext db = new TppContext();
                Transition tempTrans = db.Transitions.Find(temp.TransitionId);
                temp.Transition = tempTrans;

                Equipment tempEquip = db.Equipments.Find(temp.EquipmentId);
                temp.Equipment = tempEquip;

                // temp.Riggings = new List<Rigging>();
                foreach (var tmp in model.selectRigging)
                {
                    Rigging tempRig = db.Riggings.Find(Convert.ToInt32(tmp));
                    temp.Riggings.Add(tempRig);
                }

                db.Operations.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Operations");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddTpp()
        {
            AddTppModel model = new AddTppModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTpp(AddTppModel model)
        {
            if (ModelState.IsValid)
            {
                TechnologicalProcesses temp = new TechnologicalProcesses();
                temp.Operations = new List<Operation>();

                temp.Name = model.Name;
                temp.MaterialId = model.MaterialId;
                temp.TypeByExecution = model.TypeByExecution;
                temp.ActNumber = model.ActNumber;
                temp.DateStartTechProc = model.DateStartTechProc;

                TppContext db = new TppContext();

                foreach (var op in model.selectedOperations)
                {
                    Operation tempOp = db.Operations.Find(Convert.ToInt32(op));
                    temp.Operations.Add(tempOp);
                }

                db.TechnologicalProcesseses.Add(temp);
                db.SaveChanges();        

                return RedirectToAction("TechnologicalProcesses");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult AddRoute()
        {
            AddRouteModel model = new AddRouteModel();
            model.SetDevelopList(UserManager.Users);

            return View(model);
        }
        [HttpPost]
        public ActionResult AddRoute(AddRouteModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                Route temp = new Route();

                temp.DetailsDesignation = model.DetailsDesignation;
                temp.DetailsName = model.DetailsName;
                temp.NameOfDeveloper = model.NameOfDeveloper;
                temp.NameTechProc = model.NameTechProc;
                temp.TechProcId = model.TechProcId;

                db.Routes.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Routes");
            }
            else
            {
                return View(model);
            }
      
        }

        public ActionResult AddRouteCar()
        {
            AddRouteCarModel model = new AddRouteCarModel();
            model.SetDevelopList(UserManager.Users);

            return View(model);
        }
        [HttpPost]
        public ActionResult AddRouteCar(AddRouteCarModel model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();

                RouteCar temp = new RouteCar();
                temp.Agreed = model.Agreed;
                temp.Approved = model.Approved;
                temp.Checked = model.Checked;
                temp.CompanyName = model.CompanyName;
                temp.Developer = model.Developer;
                temp.NormСontroller = model.NormСontroller;
                temp.RouteId = model.RouteId;

                db.RouteCars.Add(temp);
                db.SaveChanges();

                return RedirectToAction("RouteCars");
            }
            else
            {
                return View(model);
            }
        }
        // <--------------- !Добавление ------------------->  

        //// Скачать карту
        //public ActionResult DownloadCard()
        //{ 
        //}
    }
}