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
    public partial class EditarArtigo : System.Web.UI.Page
    {
        protected DataSet ds;
        static int artigoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                artigoId = Convert.ToInt32(Request.QueryString["id"]); 
                ArtigoBLL artigoBLL = new ArtigoBLL();
                ds = artigoBLL.ObterArtigo(artigoId);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    // Preenche os campos do formulário com as informações do artigo
                    txtTitulo.Text = row["Titulo"].ToString();
                    txtSubtitulo.Text = row["Subtitulo"].ToString();
                    txtConteudo.Text = row["Conteudo"].ToString();

                    // Preenche o dropdown de categoria
                    CarregarCategorias();

                    // Seleciona a categoria correta
                    ddlCategoria.SelectedValue = row["CategoriaId"].ToString();

                    chkAcessibilidade.Checked = Convert.ToBoolean(row["Acessibilidade"]);
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
        protected void btnEditarArtigo_Click(object sender, EventArgs e)
        {
            string novoTitulo = txtTitulo.Text;
            string novoSubtitulo = txtSubtitulo.Text;
            string novoConteudo = txtConteudo.Text;
            int novaCategoriaId = Convert.ToInt32(ddlCategoria.SelectedValue);
            bool novaAcessibilidade = chkAcessibilidade.Checked;

            ArtigoBLL artigoBLL = new ArtigoBLL();

            artigoBLL.editarArtigo(artigoId, novoTitulo, novoSubtitulo, novoConteudo, novaCategoriaId, novaAcessibilidade);
            Response.Redirect("~/UI/UserDashboard.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/UserDashboard.aspx");
        }
    }
}