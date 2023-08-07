using _5413__ASP.NET.BLL;
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
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;

            BLL.UtilizadorBLL bll = new BLL.UtilizadorBLL();
            Utilizador user = bll.LoginUtilizador(Email, Password);

            if (user != null)
            {
                // Login bem-sucedido, armazenar o utilizador na sessão e redirecionar
                Session["Utilizador"] = user;
                if (user.Tipo == "admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                lblLoginError.Visible = true;
                lblLoginError.Text = "Email ou password inválidos. Por favor, tente novamente.";
            }
        }
    }
}