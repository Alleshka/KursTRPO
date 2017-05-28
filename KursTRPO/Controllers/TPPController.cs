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


        public ActionResult DeleteMaterial(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Material temp = db.Materials.Find(i);

                if (temp != null)
                {
                    db.Materials.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Materials");
        }
        public ActionResult DeleteEquipment(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Equipment temp = db.Equipments.Find(i);

                if (temp != null)
                {
                    db.Equipments.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Equipments");
        }
        public ActionResult DeleteTransition(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Transition temp = db.Transitions.Find(i);

                if (temp != null)
                {
                    db.Transitions.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Transitions");
        }
        public ActionResult DeleteRigging(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Rigging temp = db.Riggings.Find(i);

                if (temp != null)
                {
                    db.Riggings.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Riggings");
        }
        public ActionResult DeleteOperation(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Operation temp = db.Operations.Find(i);

                if (temp != null)
                {
                    db.Operations.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Operations");
        }
        public ActionResult DeleteTPP(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                TechnologicalProcesses temp = db.TechnologicalProcesseses.Find(i);

                if (temp != null)
                {
                    db.TechnologicalProcesseses.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("TechnologicalProcesseses");
        }
        public ActionResult DeleteRoute(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                Route temp = db.Routes.Find(i);

                if (temp != null)
                {
                    db.Routes.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Routes");
        }
        public ActionResult DeleteRouteCar(int i = -1)
        {
            if (i != -1)
            {
                TppContext db = new TppContext();
                RouteCar temp = db.RouteCars.Find(i);

                if (temp != null)
                {
                    db.RouteCars.Remove(temp);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("RouteCars");
        }
        public ActionResult DownloadCard(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TppContext db = new TppContext();

                RouteCar _routeCar = db.RouteCars.Where(x => x.RouteCarId == i).First();
                // Route _route = db.Routes.Where(x => x.RouteId == _routeCar.RouteId).First();
                Route _route = _routeCar.Route;
                TechnologicalProcesses _tpp = db.TechnologicalProcesseses.Where(x => x.TechProcId == _route.TechProcId).First();

                var document = new XLWorkbook(Server.MapPath("~\\App_Data\\MK_-pustoy_shablon.xlsx"));
                var ws = document.Worksheet(1);

                // Строим таблицу

                // Выставляем дату
                string str = String.Format("{0}.{1}.{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

                ws.Cell("AF8").Value = str;
                ws.Cell("AF9").Value = str;
                ws.Cell("AF12").Value = str;


                // Разработал
                ws.Cell("J8").Value = UserManager.Users.Where(x => x.Id == _routeCar.Developer).First()._UserFIO;

                // Проверил
                ws.Cell("J9").Value = UserManager.Users.Where(x => x.Id == _routeCar.Checked).First()._UserFIO;

                // Нормконтроллер
                ws.Cell("J12").Value = UserManager.Users.Where(x => x.Id == _routeCar.NormСontroller).First()._UserFIO;

                // Имя компании
                ws.Cell("AL8").Value = _routeCar.CompanyName;

                // Обозначение детали
                ws.Cell("BB8").Value = _route.DetailsDesignation;

                // Название детали
                ws.Cell("AR11").Value = _route.DetailsName;

                // ID материала
                ws.Cell("F15").Value = _tpp.MaterialId;

                int operCounter = 0;
                int strCounter = 0;

                foreach (var oper in _tpp.Operations)
                {
                    ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("А{0}", (strCounter + 3).ToString("D2"));
                    ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1} {2} {3} {4} {5}",
                        oper.DepartmentNumber, //shop number
                        oper.SiteNumber,
                        oper.WorkplaceNumber,
                        oper.Name,
                        oper.OperationId,
                        oper.Name
                        );
                    strCounter++;
                    ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("Б{0}", (strCounter + 3).ToString("D2"));

                    ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1}",
                        oper.Equipment.EquipmentId,
                        oper.Equipment.Name
                        );
                    foreach (var rig in oper.Riggings)
                    {
                        ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("Т{0}", (strCounter + 3).ToString("D2"));
                        ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1}",
                           rig.RiggingId,
                           rig.Name
                           );
                        strCounter++;
                    }
                    operCounter++;
                }


                // !Составляем таблицу
                document.SaveAs(Server.MapPath("~\\App_Data\\mk.xlsx"));
                string filename = "mk.xlsx";
                string filepath = filename;
                byte[] filedata = System.IO.File.ReadAllBytes(Server.MapPath("~\\App_Data\\mk.xlsx"));
                string contentType = MimeMapping.GetMimeMapping(Server.MapPath("~\\App_Data\\mk.xlsx"));

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
        }

        // Редактирование
        public ActionResult EditMaterial(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Materials");
            }
            else
            {
                TppContext db = new TppContext();
                Material model = db.Materials.Find(i);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditMaterial(Material model)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                Material temp = db.Materials.Where(x => x.MaterialId == model.MaterialId).First();

                if (temp != null)
                {
                    temp.Assortment = model.Assortment;
                    temp.DesignOfStandard = model.DesignOfStandard;
                    temp.Name = model.Name;
                    temp.Stamp = model.Stamp;
                    temp.TechnologicalProcesseses = model.TechnologicalProcesseses;
                    db.SaveChanges();
                }
                return RedirectToAction("Materials");
            }
            else return View(model);
        }

        public ActionResult EditEquipment(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Equipments");
            }
            else
            {
                TppContext db = new TppContext();
                Equipment model = db.Equipments.Find(i);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditEquipment(Equipment model)
        {
            TppContext db = new TppContext();
            Equipment temp = db.Equipments.Where(x => x.EquipmentId == model.EquipmentId).First();

            if (temp != null)
            {
                temp.Department = model.Department;
                temp.DetailNumber = model.DetailNumber;
                temp.Name = model.Name;
                temp.Quantity = model.Quantity;
                db.SaveChanges();
            }
            return RedirectToAction("Equipments");
        }

        public ActionResult EditTransition(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Transitions");
            }
            else
            {
                TppContext db = new TppContext();
                Transition model = db.Transitions.Find(i);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditTransition(Transition model)
        {
            TppContext db = new TppContext();
            Transition temp = db.Transitions.Where(x => x.TransitionId == model.TransitionId).First();

            if (temp != null)
            {
                temp.Keyword = model.Keyword;
                temp.TransitionId = model.TransitionId;
                temp.TransitionNumber = model.TransitionNumber;
                temp.TransitionType = model.TransitionType;
                db.SaveChanges();
            }
            return RedirectToAction("Transitions");
        }

        public ActionResult EditRigging(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Riggings");
            }
            else
            {
                TppContext db = new TppContext();
                Rigging model = db.Riggings.Find(i);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditRigging(Rigging model)
        {
            TppContext db = new TppContext();
            Rigging temp = db.Riggings.Where(x => x.RiggingId == model.RiggingId).First();

            if (temp != null)
            {
                temp.Name = model.Name;
                temp.Quantity = model.Quantity;
                temp.TypeOfTool = model.TypeOfTool;
                db.SaveChanges();
            }
            return RedirectToAction("Riggings");
        }

        /*public ActionResult EditOperation(int i = -1)
        {
            if (i == -1)
            {
                return RedirectToAction("Operations");
            }
            else
            {
                TppContext db = new TppContext();
                Operation model = db.Operations.Find(i);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditOperation(Operation model)
        {
            TppContext db = new TppContext();
            Operation temp = db.Operations.Where(x => x.OperationId == model.OperationId).First();

            if (temp != null)
            {
                temp.DepartmentNumber = model.DepartmentNumber;
                temp.EquipmentId = model.EquipmentId;
                temp.Name = model.Name;
                temp.Number = model.Number;
                temp.SiteNumber = model.SiteNumber;
                temp.TransitionId = model.TransitionId;
                temp.TransitionName = model.TransitionName;
                temp.WorkplaceNumber = model.WorkplaceNumber;

                db.SaveChanges();
            }
            return RedirectToAction("Operations");
        }*/
    }

}