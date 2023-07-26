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
            if (!IsPostBack)
            {
                /* Verificar se o utilizador está logado
                if ()
                
                    // Utilizador com login, esconder "Login" e "Sign up", mostrar "Log Out"
                    loginLink.Visible = false;
                    signUpLink.Visible = false;
                    logoutLink.Visible = true;
                }
                else
                {
                */
                    // Utilizador sem login, esconder "Log Out", mostrar "Login" e "Sign up"
                    loginLink.Visible = true;
                    signUpLink.Visible = true;
                    logoutLink.Visible = false;
                //}

            }
        }
    }
}