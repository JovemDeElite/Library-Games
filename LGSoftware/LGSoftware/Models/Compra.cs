using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LGSoftware.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int Id_LoginComprador { get; set; }
        public List<Produto> produtos { get; set; } = new List<Produto>();
        public double Preco_total { get; set; }
        public int Status { get; set; }
        //1 - aberta
        //2 - espera
        //3 - fechada
    }
}