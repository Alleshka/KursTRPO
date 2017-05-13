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
    }
}