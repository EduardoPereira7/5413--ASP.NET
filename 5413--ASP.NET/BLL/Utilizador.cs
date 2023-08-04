using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Verificado { get; set; } // fica true após ser verificado pelo Admin
        public string Tipo { get; set; } //admin ou normalUser
    }
}