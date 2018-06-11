﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cotizador.Models;

namespace Cotizador.Controllers
{
    public class UsersController : Controller
    {
        CotizadorContext db = new CotizadorContext();
       [HttpGet] 
       public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(Usuarios User)
        {
            try
            {
                var Usuarios = db.Usuario.ToList().Where(x => x.Usuario.Equals(User.Usuario) && x.Clave.Equals(User.Clave)).ToArray();

                if (Usuarios[0] != null)
                {
                    Session["IsUserLogin"] = true;
                    Session["UserInfo"] = Usuarios[0];
                    return Json(new { Error = false }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new {Error = true }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch(Exception ex)
            {
                return Json(new {ErrorText= ex.Message, Error=true}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()//Cerrar Sesion en el Sistema
        {
            Session["IsUserLogin"] = false;
            Session["UserInfo"] = null;

            ViewBag.Mensaje = "Sesión Cerrada Correctamente";

            return RedirectToAction("Users", "Login");
        }
    }
}