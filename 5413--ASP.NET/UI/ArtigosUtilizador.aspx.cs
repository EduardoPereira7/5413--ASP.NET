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
        protected int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["userId"] != null)
                {
                    userId = Convert.ToInt32(Request.QueryString["userId"]);
                    string nomeUtilizador = ObterNomeUtilizador(userId);
                    h1Titulo.InnerText = "Artigos do Utilizador: ";
                    h3NomeUtilizador.InnerText = nomeUtilizador;
                    CarregarArtigosDoUtilizador(userId);
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void CarregarArtigosDoUtilizador(int userId)
        {
            rptArtigos.DataSource = null;
            rptArtigos.DataBind();
            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            DataSet ds = artigoBLL.ObterArtigosDoUtilizador(userId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptArtigos.DataSource = ds.Tables[0];
                rptArtigos.DataBind();
                mensagemArtigos.Visible = false;
            }
            else
            {
                mensagemArtigos.Visible = true;
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int artigoID = Convert.ToInt32(((Button)sender).CommandArgument);
            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            artigoBLL.eliminarArtigo(artigoID);
            userId = Convert.ToInt32(Request.QueryString["userId"]);
            CarregarArtigosDoUtilizador(userId);
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
    }
}