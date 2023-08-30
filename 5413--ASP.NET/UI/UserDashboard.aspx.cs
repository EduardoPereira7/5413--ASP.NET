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
        }

        protected void criarArtigo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CriarArtigo.aspx");
        }

        protected void gerirMeusArtigos_Click(object sender, EventArgs e)
        {
            secaoArtigos.Visible = true;
            carregarMeusArtigos();
        }
        protected void carregarMeusArtigos()
        {
            Utilizador user = (Utilizador)Session["Utilizador"];

            // Atribuir o ID do utilizador à variável userId
            userId = user.Id;


            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            DataSet dsArtigos = b.ObterArtigosDoUtilizador(userId);

            RepeaterArtigos.DataSource = dsArtigos;
            RepeaterArtigos.DataBind();

            if (dsArtigos.Tables[0].Rows.Count == 0)
            {
                feedback.Visible = true;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int artigoId = Convert.ToInt32(btnEditar.CommandArgument);

            Response.Redirect($"EditarArtigo.aspx?id={artigoId}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int artigoId = Convert.ToInt32(btn.CommandArgument);

            // Chamar um método na BLL para eliminar o utilizador com o userId
            BLL.ArtigoBLL b = new BLL.ArtigoBLL();
            b.eliminarArtigo(artigoId);

            carregarMeusArtigos();
        }
    }
}