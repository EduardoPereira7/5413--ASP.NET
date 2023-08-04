using _5413__ASP.NET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UtilizadorID"] != null)
            {
                // Utilizador autenticado, esconder botões de login e sign-up e mostrar botão de logout
                loginLink.Visible = false;
                signUpLink.Visible = false;
                logoutLink.Visible = true;
                UserNameListItem.Visible = true;

                // Obter o nome do utilizador autenticado (pode obtê-lo da base de dados com base no ID)
                var utilizadorDAL = new UtilizadorDAL();
                var utilizador = utilizadorDAL.ObterUtilizadorPorId(Convert.ToInt32(Session["UtilizadorID"]));
                UserName.InnerText = utilizador.Nome;
            }
            else
            {
                // Utilizador não autenticado, esconder botão de logout
                logoutLink.Visible = false;
                UserNameListItem.Visible = false;
            }
        }
    }
}