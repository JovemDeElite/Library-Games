using LGSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LGSoftware.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Fable(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index", "Home");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }

        public ActionResult Arma(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index", "Home");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }

        public ActionResult Overwatch(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index", "Home");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }

        public ActionResult Minecraft(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index", "Home");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }
    }
}