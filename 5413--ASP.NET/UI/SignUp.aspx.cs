using _5413__ASP.NET.BLL;
using _5413__ASP.NET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _5413__ASP.NET.UI
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var utilizadorDAL = new UtilizadorDAL();
            var utilizador = new Utilizador
            {
                Nome = txtFirstName.Text + " " + txtLastName.Text,
                Email = txtRegisterEmail.Text,
                Password = txtRegisterPassword.Text,
                Verificado = false,
                Tipo = "normalUser"
            };

            if (utilizadorDAL.AdicionarUtilizador(utilizador))
            {
                // Registo bem-sucedido, redirecionar para a página de login
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Registo falhou, mostrar mensagem de erro
                lblRegisterError.Text = "Ocorreu um erro ao registar. Por favor, tente novamente.";
            }
        }
    }
}