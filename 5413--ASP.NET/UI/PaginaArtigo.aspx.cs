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
    public partial class PaginaArtigo : System.Web.UI.Page
    {
        protected DataSet ds;
        static int artigoId;
        static int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                userId = 0;
                L_Restrito.Visible = false;
                artigoId = Convert.ToInt32(Request.QueryString["id"]);

                if (Session["Utilizador"] is BLL.Utilizador utilizador)
                    userId = utilizador.Id;

                //botão like invisivel se artigo já liked ou user não logado
                if ( userId==0 || vereficarLiked() > 0)
                    Bt_like.Visible = false;

                preencherArtigo();
            }
        }//----------------------------------------------------------------------------

        protected void preencherArtigo()
        {
            
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
                encherDiv(counteudo);
        }//----------------------------------------------------------------------------

        protected void encherDiv(string text)
        {
            string[] paragraphs = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string paragraph in paragraphs)
            {
                divArtigo.InnerHtml += "<p>";
                divArtigo.InnerHtml += paragraph;
                divArtigo.InnerHtml += "</p>";
            }
        }//----------------------------------------------------------------------------

        protected void Bt_like_Click(object sender, EventArgs e)
        {
            ArtigoBLL artigoBLL = new ArtigoBLL();
            artigoBLL.likeArtigo(artigoId, userId);
            Bt_like.Visible=false;
        }//----------------------------------------------------------------------------

        protected int vereficarLiked()
        {
            ArtigoBLL artigoBLL = new ArtigoBLL();
            return artigoBLL.Liked(artigoId,userId);
        }//----------------------------------------------------------------------------
    }
}