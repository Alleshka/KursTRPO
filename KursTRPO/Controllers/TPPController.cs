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
    }
}