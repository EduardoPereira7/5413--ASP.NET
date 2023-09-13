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
    public partial class CriarArtigo : System.Web.UI.Page
    {
        protected int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCategorias();
                Utilizador user = (Utilizador)Session["Utilizador"];

                if (user != null && !user.Verificado)
                {
                    
                    DesabilitarCampos();
                    lblAviso1.Visible = true;
                    lblAviso2.Visible = true;
                }
            }
        }
        private void CarregarCategorias()
        {
             BLL.CategoriaBLL categoriaBLL = new BLL.CategoriaBLL();
             DataSet dsCategorias = categoriaBLL.ObterCategorias();

             ddlCategoria.DataSource = dsCategorias.Tables[0];
             ddlCategoria.DataTextField = "Nome"; 
             ddlCategoria.DataValueField = "Id"; 
             ddlCategoria.DataBind();
        }

        protected void btnCriarArtigo_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string subtitulo = txtSubtitulo.Text;
            string conteudo = txtConteudo.Text;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(subtitulo) || string.IsNullOrWhiteSpace(conteudo))
            {
                lblAvisoTitulo.Visible = true;
                lblAvisoSubTitulo.Visible = true;
                lblAvisoConteudo.Visible = true;
                return;
            }
            else
            {
                lblAvisoTitulo.Visible = false;
                lblAvisoSubTitulo.Visible = false;
                lblAvisoConteudo.Visible = false;
            }

            DateTime dataPublicacao = DateTime.Now;
            int categoriaId = Convert.ToInt32(ddlCategoria.SelectedValue);

            Utilizador user = (Utilizador)Session["Utilizador"];
            userId = user.Id;
            int utilizadorId = user.Id;

            bool acessibilidade = chkAcessibilidade.Checked ? false : true;


            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            bool sucesso = artigoBLL.CriarArtigo(titulo, subtitulo, conteudo, dataPublicacao, acessibilidade, categoriaId, utilizadorId);

            if (sucesso)
            {
                Session["FeedbackMessage"] = "<span>Artigo criado com sucesso!</span>";
            }
            else
            {
                Session["FeedbackMessage"] = "<span style='font-weight:bold; font-size:18px;'>Ocorreu um erro ao criar o artigo. Por favor, tente novamente.</span>";
            }

            Response.Redirect("UserDashboard.aspx");
        }
        private void DesabilitarCampos()
        {
            txtTitulo.Enabled = false;
            txtSubtitulo.Enabled = false;
            txtConteudo.Enabled = false;
            ddlCategoria.Enabled = false;
            chkAcessibilidade.Enabled = false;
            btnCriarArtigo.Enabled = false;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session.Remove("FeedbackMessage");
            Response.Redirect("UserDashboard.aspx");
        }
    }
}