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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Utilizador user = (Utilizador)Session["Utilizador"];
            if (user.Tipo != "Admin")
            {
                // Exibir aviso
               // ClientScript.RegisterStartupScript(this.GetType(), "Acesso Negado", "alert('Aviso: Você está a tentar aceder a uma página restrita.');", true);

                // Redirecionar para a página "SemAcesso.aspx"
                Response.Redirect("index.aspx");
                return;
            }
            

            if (!Page.IsPostBack)
            {
                preencherUtilizadoresNaoVerificados();
                preencherTodosUtilizadores();
            }
        }
        protected void preencherGridView(GridView gridView, bool verificado)
        {
            BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();
            DataSet ds = b.obterUtilizadores(verificado);
            gridView.DataSource = ds;
            gridView.AllowPaging = true;
            gridView.PageSize = 5;
            gridView.AutoGenerateColumns = false;
            gridView.DataBind();
        }
        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int userId = Convert.ToInt32(btn.CommandArgument);

            // Chamar um método na BLL para alterar a verificação do utilizador com o userId
            BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();
            b.alterarVerificacao(userId, true);

            preencherUtilizadoresNaoVerificados();
            preencherTodosUtilizadores();
        }


        protected void preencherUtilizadoresNaoVerificados()
        {
            preencherGridView(listarNaoVerificados, false);
        }
        protected void preencherTodosUtilizadores()
        {
            preencherGridView(listarUtilizadores, true);
        }
        protected void listarNaoVerificados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listarNaoVerificados.PageIndex = e.NewPageIndex;
            preencherUtilizadoresNaoVerificados();
        }
        protected void listarUtilizadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listarUtilizadores.PageIndex = e.NewPageIndex;
            preencherTodosUtilizadores();
        }
        protected void esconderNaoVerificados_CheckedChanged(object sender, EventArgs e)
        {
            //codigo para esconder users nao verificados da tabela "Todos os Utilizadores"
        }
    }
}