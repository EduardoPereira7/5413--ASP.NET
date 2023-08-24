using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class Utilizador
    {
        public int Id;
        public string Nome;
        public string Email;
        public string Password;
        public bool Verificado; // fica true após ser verificado pelo Admin
        public bool Admin; //admin ou normalUser

        public Utilizador() { }
        public Utilizador(string nome, string email, string password, bool verificado, bool admin) 
        {
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
            this.Verificado = verificado;
            this.Admin = admin;
        }
        public Utilizador(int Id, string nome, string email, string password, bool verificado, bool admin)
        {
            this.Id = Id;
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
            this.Verificado = verificado;
            this.Admin = admin;
        }
        public int getId()
        {
            return this.Id;
        }
        public string getNome()
        {
            return this.Nome;
        }
        public string getEmail()
        {
            return this.Email;
        }
        public string getPassword()
        {
            return this.Password;
        }
        public int getVerificacao()
        {
            if (this.Verificado == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public bool getadmin()
        {
            return this.Admin;
        }
    }
}