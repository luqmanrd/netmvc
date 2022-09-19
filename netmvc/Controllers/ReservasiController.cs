using netmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace netmvc.Controllers
{
    public class ReservasiController : Controller
    {
        private NetMVCEntities db;
        // GET: SystemParameter

        public ReservasiController()
        {
            db = new NetMVCEntities();
        }
        public ActionResult Index()
        {
            var reservasi = db.Vw_Reservasi.ToList();
            if (TempData["Success"] != null)
            {
                ViewBag.Message = TempData["Success"].ToString();
            }
            return View(reservasi);
        }

        // GET: SystemParameter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemParameter/Create
        public ActionResult Create()
        {
            var rooms = db.tblM_Ruangan.Where(x=> x.Status_FK != 3).ToList();
            if (rooms != null)
            {
                ViewBag.data = rooms;
            }

            tblT_Reservasi reservasi = new tblT_Reservasi();
            return View(reservasi);
        }

        // POST: SystemParameter/Create
        [HttpPost]
        public ActionResult Create(tblT_Reservasi reservasi)
        {
            using (var save = db.Database.BeginTransaction())
            {
                try
                {
                    var rooms = db.tblM_Ruangan.Where(x => x.Status_FK != 3).ToList();
                    if (rooms != null)
                    {
                        ViewBag.data = rooms;
                    }

                    if (ModelState.IsValid)
                    {
                        if(reservasi.JamMulai > reservasi.JamSelesai)
                        {
                            ViewBag.Message = "Start can't be greater than End";
                            return View(reservasi);
                        }

                        var listReservasi = db.tblT_Reservasi.Where(x => x.Ruangan_FK == reservasi.Ruangan_FK && x.TanggalReservasi == reservasi.TanggalReservasi).ToList();
                        if(listReservasi.Count > 0)
                        {
                            ViewBag.Message = "Room already reserved for that day";
                            return View(reservasi);
                        }

                        reservasi.CreatedBy = "SYSTEM";
                        reservasi.CreatedDate = DateTime.Now;
                        db.tblT_Reservasi.Add(reservasi);
                        db.SaveChanges();

                        tblM_Ruangan room = db.tblM_Ruangan.Where(x => x.Ruangan_PK == reservasi.Ruangan_FK).FirstOrDefault();
                        room.Status_FK = 1;

                        db.SaveChanges();

                        TempData["Success"] = "Data Successfully saved to Database";
                        save.Commit();
                        return RedirectToAction("Index");
                    }

                    
                    return View(reservasi);
                }
                catch
                {
                    save.Rollback();
                    return View();
                }
            };
            
        }

        // GET: SystemParameter/Edit/5
        public ActionResult Edit(int id)
        {
            var rooms = db.tblM_Ruangan.Where(x => x.Status_FK != 3).ToList();
            if (rooms != null)
            {
                ViewBag.data = rooms;
            }
            tblT_Reservasi objData = new tblT_Reservasi();
            objData = db.tblT_Reservasi.Where(x => x.Reservasi_PK == id).FirstOrDefault();

            return View(objData);
        }

        // POST: SystemParameter/Edit/5
        [HttpPost]
        public ActionResult Edit(tblT_Reservasi reservasi)
        {
            using (var save = db.Database.BeginTransaction())
            {
                try
                {
                    var rooms = db.tblM_Ruangan.Where(x => x.Status_FK != 3).ToList();
                    if (rooms != null)
                    {
                        ViewBag.data = rooms;
                    }
                    if (ModelState.IsValid)
                    {
                        tblT_Reservasi newReservasi = db.tblT_Reservasi.Where(x => x.Reservasi_PK == reservasi.Reservasi_PK).FirstOrDefault();
                        reservasi.Ruangan_FK = newReservasi.Ruangan_FK;
                        if (reservasi.JamMulai > reservasi.JamSelesai)
                        {
                            ViewBag.Message = "Start can't be greater than End";
                            return View(reservasi);
                        }

                        var listReservasi = db.tblT_Reservasi.Where(x => x.Ruangan_FK == newReservasi.Ruangan_FK && x.TanggalReservasi == reservasi.TanggalReservasi).ToList();
                        if (listReservasi.Count > 0)
                        {
                            ViewBag.Message = "Room already reserved for that day";
                            return View(reservasi);
                        }

                        newReservasi.SubjectReservasi = reservasi.SubjectReservasi;
                        newReservasi.TanggalReservasi = reservasi.TanggalReservasi;
                        newReservasi.JamMulai = reservasi.JamMulai;
                        newReservasi.JamSelesai = reservasi.JamSelesai;
                        newReservasi.UpdatedBy = "SYSTEM";
                        newReservasi.UpdatedDate = DateTime.Now;
                        db.SaveChanges();

                        tblM_Ruangan room = db.tblM_Ruangan.Where(x => x.Ruangan_PK == newReservasi.Ruangan_FK).FirstOrDefault();
                        room.Status_FK = 1;

                        db.SaveChanges();

                        TempData["Success"] = "Data Successfully Updated";
                        save.Commit();
                        return RedirectToAction("Index");
                    }

                    return View(reservasi);
                }
                catch
                {
                    save.Rollback();
                    return View();
                }
            };
        }

        // GET: SystemParameter/Delete/5
        public ActionResult Delete(int id)
        {
            var rooms = db.tblM_Ruangan.Where(x => x.Status_FK != 3).ToList();
            if (rooms != null)
            {
                ViewBag.data = rooms;
            }
            tblT_Reservasi objData = new tblT_Reservasi();
            objData = db.tblT_Reservasi.Where(x => x.Reservasi_PK == id).FirstOrDefault();

            return View(objData);
        }

        // POST: SystemParameter/Delete/5
        [HttpPost]
        public ActionResult Delete(tblT_Reservasi reservasi)
        {
            using (var save = db.Database.BeginTransaction())
            {
                try
                {
                        tblT_Reservasi newReservasi = db.tblT_Reservasi.Where(x => x.Reservasi_PK == reservasi.Reservasi_PK).FirstOrDefault();
                        int? fk_ruangan = newReservasi.Ruangan_FK;
                        db.tblT_Reservasi.Remove(newReservasi);
                        db.SaveChanges();

                        tblM_Ruangan room = db.tblM_Ruangan.Where(x => x.Ruangan_PK == fk_ruangan).FirstOrDefault();
                        room.Status_FK = 2;

                        db.SaveChanges();

                        TempData["Success"] = "Data Successfully Deleted";
                        save.Commit();
                        return RedirectToAction("Index");

                }
                catch
                {
                    save.Rollback();
                    return View();
                }
            };
        }

    }

}
