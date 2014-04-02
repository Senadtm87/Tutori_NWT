using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Boo1.Controllers
{
    public class KorisnikController : Controller
    {
        //
        // GET: /Korisnik/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.KorisnikModel user)
        {
            if (ModelState.IsValid)
             {
            if (IsValid(user.username, user.password))
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login podaci netacni");
            }
              }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Models.KorisnikModel user)
        {

            if (ModelState.IsValid)
            {
                using (var db = new GlavniDbEntities ())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.password);

                    var sysUser = db.korisnicis.Create();

                    sysUser.username = user.username;
                    sysUser.password = user.password;
                    sysUser.passwords = crypto.Salt;
                    sysUser.korisnikid = Guid.NewGuid();

                    db.korisnicis.Add(sysUser);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                ModelState.AddModelError("", "Registracija podaci netacni");
            }
            return View();

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            return View();
        }




        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            using (var db = new GlavniDbEntities())
            {
                var user = db.korisnicis.FirstOrDefault(u => u.username == username);

                if (user != null)
                {
                    
                    if (user.password == crypto.Compute(password, user.passwords))
                    {
                        isValid = true;
                    }
                }

            }

            return isValid;
        }

    }
}
