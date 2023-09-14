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
        private int userId;
        private int artigosPorPagina = 8;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["indexAtualPagina"] = 0;
            }

            if (Session["Utilizador"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Utilizador user = (Utilizador)Session["Utilizador"];
            userId = user.Id;
            SetupDashboard(user);
            CarregarArtigos();
            MostrarMensagensFeedback();
        }//--------------------------------------------------------

        private void SetupDashboard(Utilizador user)
        {
            divCriarArtigo.Attributes["class"] = user.Admin ? "col-md-6" : "col-md-12";
            divAdminDashboard.Visible = user.Admin;
            btnAdminDashboard.Visible = user.Admin;
        }//--------------------------------------------------------

        private void CarregarArtigos()
        {
            int paginaAtual = (int)Session["indexAtualPagina"];
            int offset = paginaAtual * artigosPorPagina;

            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            DataSet dsArtigos = b.ObterArtigosDoUtilizador(userId, offset, artigosPorPagina);

            RepeaterArtigos.DataSource = dsArtigos;
            RepeaterArtigos.DataBind();
            secaoArtigos.Visible = true;

            int totalArtigos = b.ObterTotalArtigosDoUtilizador(userId);
            int totalPaginas = (int)Math.Ceiling((double)totalArtigos / artigosPorPagina);

            btnPrevious.Enabled = paginaAtual > 0;
            btnNext.Enabled = paginaAtual < totalPaginas - 1;
        }//--------------------------------------------------------

        private void MostrarMensagensFeedback()
        {
            if (Session["FeedbackMessage"] != null)
            {
                string feedbackMessage = Session["FeedbackMessage"].ToString();
                feedbackTop.Text = feedbackMessage;
                feedbackTop.CssClass = feedbackMessage.Contains("erro") ? "text-danger" : "text-success";
                feedbackTop.Visible = true;
                Session.Remove("FeedbackMessage");
            }
        }//--------------------------------------------------------

        protected void criarArtigo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CriarArtigo.aspx");
        }//--------------------------------------------------------

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int artigoId = Convert.ToInt32(btnEditar.CommandArgument);

            Response.Redirect($"EditarArtigo.aspx?id={artigoId}");
        }//--------------------------------------------------------

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int artigoId = Convert.ToInt32(btn.CommandArgument);

            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            bool exclusaoBemSucedida = b.eliminarArtigo(artigoId);

            Session["FeedbackMessage"] = exclusaoBemSucedida
                ? "Artigo eliminado com sucesso!"
                : "Ocorreu um erro ao eliminar o artigo. Por favor, tente novamente.";

            Response.Redirect("UserDashboard.aspx");
        }//--------------------------------------------------------

        protected void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }//--------------------------------------------------------

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Button btnVer = (Button)sender;
            int artigoId = Convert.ToInt32(btnVer.CommandArgument);
            Response.Redirect($"PaginaArtigo.aspx?id={artigoId}");
        }//--------------------------------------------------------

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            EsconderMensagensFeedback();
            int paginaAtual = (int)Session["indexAtualPagina"];
            if (paginaAtual > 0)
            {
                paginaAtual--;
                Session["indexAtualPagina"] = paginaAtual;
                CarregarArtigos();
            }
        }//--------------------------------------------------------

        protected void btnNext_Click(object sender, EventArgs e)
        {
            EsconderMensagensFeedback();
            int paginaAtual = (int)Session["indexAtualPagina"];
            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            int totalArtigos = b.ObterTotalArtigosDoUtilizador(userId);
            int totalPaginas = (int)Math.Ceiling((double)totalArtigos / artigosPorPagina);

            if (paginaAtual < totalPaginas - 1)
            {
                paginaAtual++;
                Session["indexAtualPagina"] = paginaAtual;
                CarregarArtigos();
            }
        }//--------------------------------------------------------

        private void EsconderMensagensFeedback()
        {
            if (feedbackTop.Visible)
            {
                feedbackTop.Visible = false;
            }
        }//--------------------------------------------------------
    }
}