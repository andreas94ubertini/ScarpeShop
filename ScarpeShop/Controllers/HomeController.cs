using ScarpeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace ScarpeShop.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            List<Prodotto> prodotti = Database.GetAllProducts();
            return View(prodotti);

        }

        public ActionResult ProductPage(int id)
        {
            Prodotto p = Database.GetProductById(id);
            return View(p);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Users user)
        {
            Users loggedUser = Database.GetUserByUsername(user.Username);
            if (loggedUser != null && loggedUser.Psw == user.Psw && loggedUser.Role == "admin")
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index");
            }
            else if (loggedUser != null && loggedUser.Psw == user.Psw)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


    }
}