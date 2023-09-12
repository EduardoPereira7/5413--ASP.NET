using _5413__ASP.NET.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else
            {
                Utilizador user = (Utilizador)Session["Utilizador"];
                userId = user.Id;
                carregarMeusArtigos();
                if (user.Admin)
                {
                    divCriarArtigo.Attributes["class"] = "col-md-6";
                    divAdminDashboard.Visible = true;
                    btnAdminDashboard.Visible= true;
                }
                else
                {
                    divCriarArtigo.Attributes["class"] = "col-md-12";
                }
                if (Session["FeedbackMessage"] != null)
                {
                    string feedbackMessage = Session["FeedbackMessage"].ToString();
                    feedbackTop.Text = feedbackMessage;
                    feedbackTop.CssClass = feedbackMessage.Contains("erro") ? "text-danger" : "text-success";
                    feedbackTop.Visible = true;
                    Session.Remove("FeedbackMessage");
                }
            }
        }

        protected void criarArtigo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CriarArtigo.aspx");
        }
        protected void carregarMeusArtigos()
        {
            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            DataSet dsArtigos = b.ObterArtigosDoUtilizador(userId);

            RepeaterArtigos.DataSource = dsArtigos;
            RepeaterArtigos.DataBind();
            secaoArtigos.Visible = true;
            if (dsArtigos.Tables[0].Rows.Count == 0)
            {
                feedback.Visible = true;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int artigoId = Convert.ToInt32(btnEditar.CommandArgument);

            Response.Redirect("EditarArtigo.aspx?id="+artigoId);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int artigoId = Convert.ToInt32(btn.CommandArgument);

            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            bool exclusaoBemSucedida = b.eliminarArtigo(artigoId);

            if (exclusaoBemSucedida)
            {
                Session["FeedbackMessage"] = "Artigo eliminado com sucesso!";
            }
            else
            {
                Session["FeedbackMessage"] = "Ocorreu um erro ao eliminar o artigo. Por favor, tente novamente.";
            }

            Response.Redirect("UserDashboard.aspx");
        }

        protected void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Button btnVer = (Button)sender;
            int artigoId = Convert.ToInt32(btnVer.CommandArgument);
            Response.Redirect("PaginaArtigo.aspx?id=" + artigoId);
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}