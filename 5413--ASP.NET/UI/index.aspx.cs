using _5413__ASP.NET.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int numCardsPerRow = 2; // Número de cards por linha

                ArtigoBLL artigoBLL = new ArtigoBLL();
                DataSet dataSet = artigoBLL.ObterTodosOsArtigos(); // Substitua 'ano' e 'mes' pelos valores desejados

                StringBuilder cardsHtml = new StringBuilder();
                cardsHtml.Append("<div class='row'>"); // Abre a primeira linha

                int cardCounter = 0;

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    // Se o contador de cards atingir o número desejado por linha, fecha a linha e abre uma nova
                    if (cardCounter == numCardsPerRow)
                    {
                        cardsHtml.Append("</div><div class='row'>");
                        cardCounter = 0;
                    }

                    string id = row["Id"].ToString();
                    string titulo = row["Titulo"].ToString();
                    string Subtitulo = row["Subtitulo"].ToString();
                    DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                    cardsHtml.Append($@"
                     <div class='col-md-6'>
                        <a href='PaginaArtigo.aspx?id={id}' class='card-link card-link-custom'>
                            <div class='card mb-3'>
                                <div class='card-header'>{titulo}</div>
                                <div class='card-body'>
                                    <h5 class='card-title'>{Subtitulo}</h5>
                                    <p class='card-text'>Publicado em: {dataPublicacao.ToShortDateString()}</p>
                                </div>
                            </div>
                        </a>
                    </div>
                    ");

                    cardCounter++;
                }

                cardsHtml.Append("</div>"); // Fecha a última linha

                // Adicionar os cards ao LiteralControl
                LiteralControl cardsLiteral = new LiteralControl(cardsHtml.ToString());
                cardsContainer.Controls.Add(cardsLiteral); // CardsContainer é um controle de conteúdo em sua página
            }
        }//--------------------------------------------------------

 
    }
}

