using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEWTEST.Controllers
{
    public class DASHController : Controller
    {
        NEWTESTEntities db = new NEWTESTEntities();

        [Route("Dash")]
        public ActionResult Dash()
        {
            return View();
        }

        [Route("Dash/ListPrd")]
        public ActionResult ListPrd()
        {
            var listofData = db.TBL_PRODUCTS.ToList();
            return View(listofData);
        }

        [Route("Dash/CreatePrd")]
        public ActionResult CreatePrd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePrd(TBL_PRODUCTS model, HttpPostedFileBase postedFile)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                model.P_IMG = fileName;
                postedFile.SaveAs(path + fileName);
            }

            if (ModelState.IsValid)
            {
                model.P_STATUT = 1;
                db.TBL_PRODUCTS.Add(model);
                db.SaveChanges();
                return View();
            }
            return View();
        }

        [Route("Dash/EditPrd/{id}")]
        public ActionResult EditPrd(int id)
        {
            var data = db.TBL_PRODUCTS.Where(x => x.P_ID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditPrd(TBL_PRODUCTS Model, HttpPostedFileBase postedFile)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                Model.P_IMG = fileName;
                postedFile.SaveAs(path + fileName);
            }

            var data = db.TBL_PRODUCTS.Where(x => x.P_ID == Model.P_ID).FirstOrDefault();
            if (data != null)
            {
                data.P_NAME = Model.P_NAME;
                data.P_DISCRIPTION = Model.P_DISCRIPTION;
                data.P_IMG = Model.P_IMG;
                data.P_PRICE = Model.P_PRICE;
                data.P_STATUT = Model.P_STATUT;
                db.SaveChanges();
            }
            return RedirectToAction("ListPrd");
        }

        [Route("Dash/DetailPrd/{id}")]
        public ActionResult DetailPrd(int id)
        {
            var data = db.TBL_PRODUCTS.Where(x => x.P_ID == id).FirstOrDefault();
            return View(data);
        }

        [Route("Dash/DeletePrd/{id}")]
        public ActionResult DeletePrd(int id)
        {
            var data = db.TBL_PRODUCTS.Where(x => x.P_ID == id).FirstOrDefault();
            db.TBL_PRODUCTS.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ListPrd");
        }

        [Route("Dash/CreateInv")]
        public ActionResult CreateInv()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInv(TBL_INVOICES INVOICES, List<TBL_ORDERS> ORDERS)
        {
            if (ModelState.IsValid)
            {
                INVOICES.U_ID = (int)Session["UserID"];
                INVOICES.I_STATUT = 1;
                db.TBL_INVOICES.Add(INVOICES);
                db.SaveChanges();

                foreach (TBL_ORDERS Ord in ORDERS)
                {
                    Ord.I_ID = INVOICES.U_ID;
                    db.TBL_ORDERS.Add(Ord);
                }
                db.SaveChanges();

                return View();
            }
            return View();
        }

        [Route("Dash/EditInv/{id}")]
        public ActionResult EditInv(int id)
        {
            var data = db.TBL_INVOICES.Where(x => x.I_ID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditInv(TBL_INVOICES INVOICES, List<TBL_ORDERS> ORDERS)
        {
            var data = db.TBL_INVOICES.Where(x => x.I_ID == INVOICES.I_ID).FirstOrDefault();
            if (data != null)
            {
                data.I_STATUT = INVOICES.I_STATUT;
                db.SaveChanges();
            }
            return RedirectToAction("ListInv");
        }

        [Route("Dash/DeleteInv/{id}")]
        public ActionResult DeleteInv(int id)
        {
            var data = db.TBL_INVOICES.Where(x => x.I_ID == id).FirstOrDefault();
            db.TBL_INVOICES.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ListInv");
        }

        [Route("Dash/ListInv")]
        public ActionResult ListInv()
        {
            var listofData = db.TBL_INVOICES.ToList();
            return View(listofData);
        }

        [Route("Dash/DetailInv/{id}")]
        public ActionResult DetailInv(int id)
        {
            var data = (from user in db.TBL_USERS
                        join inv in db.TBL_INVOICES on user.U_ID equals inv.U_ID
                        join ord in db.TBL_ORDERS on inv.I_ID equals ord.I_ID
                        join prd in db.TBL_PRODUCTS on ord.P_ID equals prd.P_ID
                        select inv).ToList();
            return View(data);
        }
    }
}