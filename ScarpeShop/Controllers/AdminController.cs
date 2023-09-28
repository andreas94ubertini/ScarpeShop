using ScarpeShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScarpeShop.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminPage()
        {

            Users user = Database.GetUserByUsername(System.Web.HttpContext.Current.User.Identity.ToString());
            ViewBag.User = user;
            List<Prodotto> prodotti = Database.GetAllProducts();
            return View(prodotti);

        }
        [HttpGet]
        public ActionResult Modify(int id)
        {
            Prodotto prodotto = Database.GetProductById(id);
            return View(prodotto);
        }
        [HttpPost]
        public ActionResult Modify(Prodotto p, HttpPostedFileBase CoverImg, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            if (ModelState.IsValid)
            {
                string coverImg = "";
                string img1 = "";
                string img2 = "";
                 if (CoverImg.ContentLength > 0)
                {
                    string ext = Path.GetExtension(CoverImg.FileName);
                    string nomeFile = CoverImg.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    CoverImg.SaveAs(pathToSave);
                    coverImg = CoverImg.FileName;
                }
                else
                {
                    coverImg = p.CoverImg;
                }
                if (Img1.ContentLength > 0)
                {
                    string ext = Path.GetExtension(Img1.FileName);
                    string nomeFile = Img1.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    Img1.SaveAs(pathToSave);
                    img1 = Img1.FileName;
                }
                else
                {
                    img1= p.Img1;
                }
                if (Img2.ContentLength > 0)
                {
                    string ext = Path.GetExtension(Img2.FileName);
                    string nomeFile = Img2.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    Img2.SaveAs(pathToSave);
                    img2 = Img2.FileName;
                }
                else
                {
                    img2 = p.Img2;
                }
                p.CoverImg = coverImg;
                p.Img1 = img1;
                p.Img2 = img2;
                Database.ModifyProduct(p.IdProdotto, p.Nome, p.Brand, p.Descrizione, p.CoverImg, p.Img1, p.Img2, p.Disp, p.Prezzo);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View(p);
            }
        }
        public ActionResult Delete(int id)
        {
            Database.RemoveProduct(id);

            return RedirectToAction("AdminPage");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Prodotto p, HttpPostedFileBase CoverImg, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            if (ModelState.IsValid)
            {
                string coverImg = "";
                string img1 = "";
                string img2 = "";
                if (CoverImg.ContentLength > 0)
                {
                    string ext = Path.GetExtension(CoverImg.FileName);
                    string nomeFile = CoverImg.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    CoverImg.SaveAs(pathToSave);
                    coverImg = CoverImg.FileName;
                }
                else
                {
                    coverImg = "...";
                }
                if (Img1.ContentLength > 0)
                {
                    string ext = Path.GetExtension(Img1.FileName);
                    string nomeFile = Img1.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    Img1.SaveAs(pathToSave);
                    img1 = Img1.FileName;
                }
                if (Img2.ContentLength > 0)
                {
                    string ext = Path.GetExtension(Img2.FileName);
                    string nomeFile = Img2.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/sample"), nomeFile);
                    Img2.SaveAs(pathToSave);
                    img2 = Img2.FileName;
                }
                p.CoverImg = coverImg;
                p.Img1 = img1;
                p.Img2 = img2;
                Database.InsertProduct(p.Nome, p.Brand, p.Descrizione, p.CoverImg, p.Img1, p.Img2, p.Disp, p.Prezzo);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View();
            }
        }
    }
}