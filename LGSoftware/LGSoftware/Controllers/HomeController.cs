using LGSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LGSoftware.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Register(string nome, string email, string senha, string usuario)
        {
            ViewBag.LoginAtual = null;
            var l = new Login();
            var ll = new List<Login>();
            var llantigo = (List<Login>)Session["ListaLogin"];
            if (nome != null && email != null && senha != null && usuario != null)
            {
                l.Id = llantigo.Count()+1;
                l.Nome = nome;
                l.Email = email;
                l.Senha = senha;
                l.Usuario = usuario;
                ll.Add(l);
                if(llantigo!=null)
                    ll.AddRange(llantigo);
                Session["ListaLogin"] = ll;
                Session["LoginAtual"] = l;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Conheca_Empresa(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }
        public ActionResult Login(string usuario_email, string senha)
        {
            ViewBag.LoginAtual = null;
            var Login = false;
            if (usuario_email != null && senha != null)
            {
                var ll = (List<Login>)Session["ListaLogin"];
                if (ll != null)
                {
                    var i = 0;

                    while (Login == false)
                    {
                        if (ll[i].Email == usuario_email && ll[i].Senha == senha)
                        {
                            Session["LoginAtual"] = ll[i];
                            Login = true;
                        }
                        else 
                        {
                            if (ll[i].Usuario == usuario_email && ll[i].Senha == senha)
                            {
                                Session["LoginAtual"] = ll[i];
                                Login = true;
                            }
                        }
                        i++;
                    }
                }
            }
            if (Login == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index(string nome, string preco, string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            var ll = (List<Login>)Session["ListaLogin"];
            if (ll == null)
            {
                ll = new List<Login>();
                l = new Login();
                l.Id = 1;
                l.Nome = "Camila";
                l.Email = "mila@teste.com";
                l.Senha = "111";
                l.Usuario = "JovemDeElite";
                ll.Add(l);
                Session["ListaLogin"] = ll;
            }
            if (nome != null && preco != null)
            {
                var prod = new Produto();
                prod.Nome = nome;
                prod.Preco = double.Parse(preco);
                Session["CarrinhoNovo"] = prod;
                return RedirectToAction("Carrinho");
            }
            else
                return View();
        }
        public ActionResult Contato(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else
                ViewBag.LoginAtual = null;
            return View();
        }

        public ActionResult SeusJogos(string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
            {
                l.produtosComprado = l.produtosComprado.OrderBy(x => x.Nome).ToList();
                ViewBag.LoginAtual = l;
            }
            else
            {
                ViewBag.LoginAtual = null;
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Carrinho(string Acao, string prodId, string deslog)
        {
            if (deslog != null)
            {
                Session["LoginAtual"] = null;
                ViewBag.LoginAtual = null;
                Session["CarrinhoAtual"] = null;
                ViewBag.CarrinhoAtual = null;
                Session["CarrinhoNovo"] = null;
                return RedirectToAction("Index");
            }
            var l = (Login)Session["LoginAtual"];
            if (l != null)
                ViewBag.LoginAtual = l;
            else {
                ViewBag.LoginAtual = null;
                return RedirectToAction("Login");
            }


            var prod_n = (Produto)Session["CarrinhoNovo"];
            var comp = (List<Compra>)Session["Carrinho"];

            if (Acao == "1")
            {
                if (comp != null)
                {
                    var c = comp.FirstOrDefault(x => x.Id_LoginComprador == l.Id && x.Status != 3);
                    c.produtos = c.produtos.Where(x => x.Id != int.Parse(prodId)).ToList();
                }
            }

            if (Acao == "2")
            {
                if (comp != null)
                {
                    var c = comp.FirstOrDefault(x => x.Id_LoginComprador == l.Id && x.Status != 3);
                    l.produtosComprado.AddRange(c.produtos);
                    c.Status = 3;
                    Session["CarrinhoAtual"] = null;
                    ViewBag.CarrinhoAtual = null;
                    Session["CarrinhoNovo"] = null;
                    Session["Carrinho"] = comp;
                    Session["LoginAtual"] = l;
                    return RedirectToAction("SeusJogos");
                }
            }
            if (prod_n != null) {
                if (comp != null)
                {
                    var c = comp.FirstOrDefault(x => x.Id_LoginComprador == l.Id && x.Status != 3);
                    if (c != null)
                    {
                        c.produtos.Add(prod_n);
                        c.Preco_total = c.Preco_total + prod_n.Preco;
                        Session["CarrinhoAtual"] = c;
                        ViewBag.CarrinhoAtual = c;
                        Session["CarrinhoNovo"] = null;
                    }
                    else {
                        c = new Compra();
                        c.Id_LoginComprador = l.Id;
                        c.Id = comp.Count() + 1;
                        c.Status = 1;
                        prod_n.Id = c.produtos.Count() + 1;
                        c.produtos.Add(prod_n);
                        c.Preco_total = prod_n.Preco;
                        comp.Add(c);
                        Session["CarrinhoAtual"] = c;
                        ViewBag.CarrinhoAtual = c;
                        Session["CarrinhoNovo"] = null;
                    }
                }
                else
                {
                    comp =  new List<Compra>();
                    var c = new Compra();
                    c.Id_LoginComprador = l.Id;
                    c.Id = comp.Count()+1;
                    c.Status = 1;
                    prod_n.Id = c.produtos.Count() + 1;
                    c.produtos.Add(prod_n);
                    c.Preco_total = prod_n.Preco;
                    comp.Add(c);
                    Session["CarrinhoAtual"] = c;
                    ViewBag.CarrinhoAtual = c;
                    Session["CarrinhoNovo"] = null;

                }
                Session["Carrinho"] = comp;
            }
            else
            {
                Compra c = new Compra();
                if (comp != null)
                {
                    c = comp.FirstOrDefault(x => x.Id_LoginComprador == l.Id && x.Status != 3);
                    if (c == null)
                    {
                        c = new Compra();
                    }
                }
                Session["CarrinhoAtual"] = c;
                ViewBag.CarrinhoAtual = c;
                Session["Carrinho"] = comp;
            }
            return View();
        }

    }
}