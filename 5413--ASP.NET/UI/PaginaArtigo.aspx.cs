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
    public partial class PaginaArtigo : System.Web.UI.Page
    {
        protected DataSet ds;
        static int artigoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L_Restrito.Visible = false;
                preencherArtigo();
            }
        }//----------------------------------------------------------------------------


        protected void preencherArtigo()
        {
            artigoId = Convert.ToInt32(Request.QueryString["id"]);
            ArtigoBLL artigoBLL = new ArtigoBLL();
            ds = artigoBLL.ObterArtigo(artigoId);


            DataRow row = ds.Tables[0].Rows[0];

            L_Titulo.Text = row["Titulo"].ToString();
            L_SubTitulo.Text = row["Subtitulo"].ToString();
            string counteudo = row["Conteudo"].ToString();
            string acessibilidade = row["Acessibilidade"].ToString();

            if (acessibilidade == "False" && Session["Utilizador"] == null)
                L_Restrito.Visible = true;
            else
                divArtigo.InnerText = counteudo;

        }
    }
}