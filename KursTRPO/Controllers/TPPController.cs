using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursTRPO.Models;
using Microsoft.AspNet.Identity;

namespace KursTRPO.Controllers
{
    public class TPPController : Controller
    {
        // Детали
        public ActionResult ViewListEquipment()
        {
            TppContext db = new TppContext();
            IEnumerable<Equipment> temp = db.Equipments;
            return View(temp);
        }
        public ActionResult AddEquipment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEquipment(Equipment temp)
        {
            if (ModelState.IsValid)
            {
                TppContext k = new TppContext();
                k.Equipments.Add(temp);
                k.SaveChanges();
            }

            return RedirectToAction("ViewListEquipment");
        }
        public ActionResult DeleteEquipment(Equipment temp)
        {
            TppContext db = new TppContext();
            db.Equipments.Remove(db.Equipments.Find(temp.EquipmentId));
            db.SaveChanges();

            return RedirectToAction("ViewListEquipment");
        }


        // Материал
        public ActionResult ViewListMaterial()
        {
            TppContext db = new TppContext();
            IEnumerable<Material> temp = db.Materials;

            return View(temp);
        }
        public ActionResult AddMaterial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterial(Material temp)
        {
            TppContext db = new TppContext();
            db.Materials.Add(temp);
            db.SaveChanges();

            return RedirectToAction("ViewListMaterial");
        }
        public ActionResult DeleteMaterial(Material temp)
        {
            TppContext db = new TppContext();
            db.Materials.Remove(db.Materials.Find(temp.MaterialId));
            db.SaveChanges();

            return RedirectToAction("ViewListMaterial");
        }

        // Операция
        public ActionResult ViewListOperation()
        {
            TppContext db = new TppContext();
            IEnumerable<Operation> temp = db.Operations;
            return View(temp);
        }
        public ActionResult AddOperation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOperation(Operation temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.Operations.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListOperation");
        }
        public ActionResult DeleteOperation(Operation temp)
        {
            TppContext db = new TppContext();
            db.Operations.Remove(db.Operations.Find(temp.OperationId));
            db.SaveChanges();

            return RedirectToAction("ViewListOperation");
        }

        // Остастка
        public ActionResult ViewListRigging()
        {
            TppContext db = new TppContext();
            IEnumerable<Rigging> temp = db.Riggings;
            return View(temp);
        }
        public ActionResult AddRigging()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRigging(Rigging temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.Riggings.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListRigging");
        }
        public ActionResult DeleteRigging(Rigging temp)
        {
            TppContext db = new TppContext();
            db.Riggings.Remove(db.Riggings.Find(temp.RiggingId));
            db.SaveChanges();

            return RedirectToAction("ViewListRigging");
        }

        // Маршрут
        public ActionResult ViewListRoute()
        {
            TppContext db = new TppContext();
            IEnumerable<Route> temp = db.Routes;
            return View(temp);
        }
        public ActionResult AddRoute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRoute(Route temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.Routes.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListRoute");
        }
        public ActionResult DeleteRoute(Route temp)
        {
            TppContext db = new TppContext();
            db.Routes.Remove(db.Routes.Find(temp.RouteId));
            db.SaveChanges();

            return RedirectToAction("ViewListRoute");
        }

        // Маршрутная карта
        public ActionResult ViewListRouteCar()
        {
            TppContext db = new TppContext();
            IEnumerable<RouteCar> temp = db.RouteCars;
            return View(temp);
        }
        public ActionResult AddRoutCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRouteCar(RouteCar temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.RouteCars.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListRouteCar");
        }
        public ActionResult DeleteRouteCar(RouteCar temp)
        {
            TppContext db = new TppContext();
            db.RouteCars.Remove(db.RouteCars.Find(temp.RouteId));
            db.SaveChanges();

            return RedirectToAction("ViewListRouteCar");
        }

        // Технологический процесс
        public ActionResult ViewListTechnologicalProcesses()
        {
            TppContext db = new TppContext();
            IEnumerable<TechnologicalProcesses> temp = db.TechnologicalProcesseses;
            return View(temp);
        }
        public ActionResult AddTechnologicalProcesses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTechnologicalProcesses(TechnologicalProcesses temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.TechnologicalProcesseses.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListTechnologicalProcesses");
        }
        public ActionResult DeleteTechnologicalProcesses(TechnologicalProcesses temp)
        {
            TppContext db = new TppContext();
            db.TechnologicalProcesseses.Remove(db.TechnologicalProcesseses.Find(temp.TechProcId));
            db.SaveChanges();

            return RedirectToAction("ViewListTechnologicalProcesses");
        }

        // Переход
        public ActionResult ViewListTransition()
        {
            TppContext db = new TppContext();
            IEnumerable<Transition> temp = db.Transitions;
            return View(temp);
        }
        public ActionResult AddTransition()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTransition(Transition temp)
        {
            if (ModelState.IsValid)
            {
                TppContext db = new TppContext();
                db.Transitions.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("ViewListTransition");
        }
        public ActionResult DeleteTransition(Transition temp)
        {
            TppContext db = new TppContext();
            db.Transitions.Remove(db.Transitions.Find(temp.TransitionId));
            db.SaveChanges();

            return RedirectToAction("ViewListTransition");
        }


    }
}