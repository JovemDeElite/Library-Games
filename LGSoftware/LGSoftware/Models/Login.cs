using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LGSoftware.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<Produto> produtosComprado { get; set; } = new List<Produto>();
    }
}