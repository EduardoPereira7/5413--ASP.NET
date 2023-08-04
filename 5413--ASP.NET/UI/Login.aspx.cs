using _5413__ASP.NET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var utilizadorDAL = new UtilizadorDAL();
            var utilizador = utilizadorDAL.ObterUtilizadorPorEmail(txtEmail.Text);

            if (utilizador != null && utilizador.Password == txtPassword.Text)
            {
                // Efetuar o login - armazenar o ID do utilizador na sessão para mantê-lo autenticado
                Session["UtilizadorID"] = utilizador.Id;
                Response.Redirect("index.aspx");
            }
            else
            {
                // Login falhou, mostrar mensagem de erro
                lblLoginError.Text = "Credenciais inválidas ou conta não verificada. Por favor, tente novamente.";
            }
        }
    }
}