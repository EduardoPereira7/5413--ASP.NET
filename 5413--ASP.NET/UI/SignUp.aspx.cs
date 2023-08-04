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
            string Nome = txtFirstName.Text + " " + txtLastName.Text;
            string Email = txtRegisterEmail.Text;
            string Password = txtRegisterPassword.Text;
            bool Verificado = false;
            string Tipo = "normalUser";

            BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();
            if (b.criarUtilizador(Nome, Email, Password, Verificado, Tipo))
            {
                // Registo bem-sucedido, redirecionar para a página de login
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Registo falhou, mostrar mensagem de erro
                lblRegisterError.Visible = true;
                lblRegisterError.Text = "Ocorreu um erro ao registar. Por favor, tente novamente.";
            }
        }
    }
}