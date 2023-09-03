using _5413__ASP.NET.BLL;
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
            if (!IsPostBack)
            {
                if (Session["Utilizador"] != null)
                {
                    Utilizador user = (Utilizador)Session["Utilizador"];
                    loginListItem.Visible = false;
                    SignUpListItem.Visible = false;
                    LogOutListItem.Visible = true;
                    UserNameListItem.Visible = true;
                    dashboard.Visible = true;
                    UserName.InnerHtml = "Olá, " + user.Nome + "!";

                    if (!user.Admin)
                    {
                        dashboard.HRef = "~/UI/UserDashboard.aspx";
                        UserName.Attributes["href"] = "~/UI/UserDashboard.aspx";
                    }
                    else
                    {
                        dashboard.HRef = "~/UI/AdminDashboard.aspx";
                        UserName.Attributes["href"] = "~/UI/AdminDashboard.aspx";
                    }
                }
                else
                {
                    loginListItem.Visible = true;
                    SignUpListItem.Visible = true;
                    LogOutListItem.Visible = false;
                    UserNameListItem.Visible = false;
                    dashboard.Visible = false;
                }
            }
        }
    }
}