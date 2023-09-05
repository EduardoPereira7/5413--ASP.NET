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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["userId"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    h1Titulo.InnerText = "Artigos do Utilizador ID:" + userId.ToString();
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
            BLL.ArtigoBLL artigoBLL = new BLL.ArtigoBLL();
            DataSet ds = artigoBLL.ObterArtigosDoUtilizador(userId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder cardsHtml = new StringBuilder();
                int artigosPorLinha = 2;
                int contador = 0;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string titulo = row["Titulo"].ToString();
                    string subtitulo = row["Subtitulo"].ToString();
                    DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                    //Se o contador for zero começa uma nova linha
                    if (contador == 0)
                    {
                        cardsHtml.Append("<div class='row'>");
                    }

                    cardsHtml.Append($@"
                <div class='col-md-6'>
                    <a href='PaginaArtigo.aspx?id={id}' class='card-link card-link-custom'>
                        <div class='card mb-3'>
                            <div class='card-header'>{titulo}</div>
                            <div class='card-body'>
                                <h5 class='card-title'>{subtitulo}</h5>
                                <p class='card-text'>Publicado em: {dataPublicacao.ToShortDateString()}</p>
                            </div>
                        </div>
                    </a>
                </div>
            ");

                    //Se atingir o número de artigos por linha
                    if (contador == artigosPorLinha - 1)
                    {
                        cardsHtml.Append("</div>"); //Fecha a linha
                        contador = 0; //Reinicia o contador
                    }
                    else
                    {
                        contador++;
                    }
                }
                if (contador != 0)
                {
                    cardsHtml.Append("</div>");
                }
                cardsContainer.InnerHtml = cardsHtml.ToString();
            }
            else
            {
                cardsContainer.InnerHtml = "<p>Não há artigos para exibir.</p>";
            }
        }
    }
}