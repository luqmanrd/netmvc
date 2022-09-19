using netmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace netmvc.Controllers
{
    public class SystemParameterController : Controller
    {
        private NetMVCEntities db;
        // GET: SystemParameter

        public SystemParameterController()
        {
            db = new NetMVCEntities();
        }
        public ActionResult Index()
        {
            var systemParameterList = db.SystemParameters.ToList();
            if(TempData["Success"] != null)
            {
                ViewBag.Message = TempData["Success"].ToString();
            }
            return View(systemParameterList);
        }

        // GET: SystemParameter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemParameter/Create
        public ActionResult Create()
        {
            SystemParameter systemParameter = new SystemParameter();
            return View(systemParameter);
        }

        // POST: SystemParameter/Create
        [HttpPost]
        public ActionResult Create(SystemParameter systemParameter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SystemParameters.Add(systemParameter);
                    db.SaveChanges();
                    TempData["Success"] = "Data Successfully saved to Database";
                    return RedirectToAction("Index");
                }
                return View(systemParameter);
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemParameter/Edit/5
        public ActionResult Edit(int id)
        {
            SystemParameter objData = new SystemParameter();
            objData = db.SystemParameters.Where(x => x.PK_SystemParameter_ID == id).FirstOrDefault();

            return View(objData);
        }

        // POST: SystemParameter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemParameter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemParameter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
