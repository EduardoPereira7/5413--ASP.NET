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
            DateTime dataPublicacao = DateTime.Now;
            int categoriaId = Convert.ToInt32(ddlCategoria.SelectedValue);

            Utilizador user = (Utilizador)Session["Utilizador"];
            userId = user.Id;
            int utilizadorId = user.Id;

            bool acessibilidade = chkAcessibilidade.Checked ? false : true;


            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            bool sucesso = artigoBLL.CriarArtigo(titulo, subtitulo, conteudo, dataPublicacao, acessibilidade, categoriaId, utilizadorId);

            if (sucesso) //incompleto
            {
                // Redirecionar para a página de sucesso ou exibir mensagem ao utilizador
                Response.Redirect("UserDashboard.aspx");
            }
            else
            {
                // Exibir mensagem de erro ao utilizador
                Response.Redirect("index.aspx");
                //lblErro.Text = "Ocorreu um erro ao criar o artigo. Por favor, tente novamente.";
                //lblErro.Visible = true;
            }
        }
    }
}