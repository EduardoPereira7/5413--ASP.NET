using _5413__ASP.NET.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class ArtigosUtilizador : System.Web.UI.Page
    {
        private int userId;
        private const int ArtigosPorPagina = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["indexAtualPagina"] = 0;
            }

            if (Request.QueryString["userId"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["userId"]);
                string nomeUtilizador = ObterNomeUtilizador(userId);
                h1Titulo.InnerText = "Artigos do Utilizador: ";
                h3NomeUtilizador.InnerText = nomeUtilizador;
                CarregarArtigosDoUtilizador();
            }
            else
            {
                Response.Redirect("index.aspx");
                return;
            }
        }

        protected void CarregarArtigosDoUtilizador()
        {
            int paginaAtual = (int)Session["indexAtualPagina"];
            int offset = paginaAtual * ArtigosPorPagina;

            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            DataSet dsArtigos = b.ObterArtigosDoUtilizador(userId, offset, ArtigosPorPagina);

            rptArtigos.DataSource = dsArtigos;
            rptArtigos.DataBind();
            mensagemArtigos.Visible = dsArtigos.Tables[0].Rows.Count == 0;

            int totalArtigos = b.ObterTotalArtigosDoUtilizador(userId);
            int totalPaginas = (int)Math.Ceiling((double)totalArtigos / ArtigosPorPagina);

            btnAnterior.Enabled = paginaAtual > 0;
            btnProximo.Enabled = paginaAtual < totalPaginas - 1;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int artigoID = Convert.ToInt32(((Button)sender).CommandArgument);
            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            bool eliminacaoBemSucedida = artigoBLL.eliminarArtigo(artigoID);

            if (eliminacaoBemSucedida)
            {
                feedbackTop.Text = "Artigo eliminado com sucesso!";
                feedbackTop.CssClass = "text-success";
            }
            else
            {
                feedbackTop.Text = "Ocorreu um erro ao eliminar o artigo. Por favor, tente novamente.";
                feedbackTop.CssClass = "text-danger";
            }
            feedbackTop.Visible = true; ;
            userId = Convert.ToInt32(Request.QueryString["userId"]);
            CarregarArtigosDoUtilizador();

            if (rptArtigos.Items.Count == 0 && (int)Session["indexAtualPagina"] > 0)
            {
                Session["indexAtualPagina"] = (int)Session["indexAtualPagina"] - 1;
                CarregarArtigosDoUtilizador();
            }
        }

        private string ObterNomeUtilizador(int userId)
        {
            BLL.UtilizadorBLL utilizadorBLL = new BLL.UtilizadorBLL();
            DataSet ds = utilizadorBLL.obterUtilizador(userId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string nome = row["Nome"].ToString();
                return nome;
            }
            return "Utilizador Desconhecido";
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            int paginaAtual = (int)Session["indexAtualPagina"];
            if (paginaAtual > 0)
            {
                paginaAtual--;
                Session["indexAtualPagina"] = paginaAtual;
                CarregarArtigosDoUtilizador();
            }
        }

        protected void btnProximo_Click(object sender, EventArgs e)
        {
            int paginaAtual = (int)Session["indexAtualPagina"];
            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            int totalArtigos = b.ObterTotalArtigosDoUtilizador(userId);
            int totalPaginas = (int)Math.Ceiling((double)totalArtigos / ArtigosPorPagina);

            if (paginaAtual < totalPaginas - 1)
            {
                paginaAtual++;
                Session["indexAtualPagina"] = paginaAtual;
                CarregarArtigosDoUtilizador();
            }
        }
    }
}