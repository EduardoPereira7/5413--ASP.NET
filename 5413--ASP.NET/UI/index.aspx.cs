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

                ArtigoBLL artigoBLL = new ArtigoBLL();
                DataSet dataSet = artigoBLL.ObterTodosOsArtigos();

                cardsContainer.InnerHtml = "";

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string id = row["Id"].ToString();
                    string titulo = row["Titulo"].ToString();
                    string Subtitulo = row["Subtitulo"].ToString();
                    string likes = row["likes"].ToString();
                    DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                    // Criar o HTML do card para cada artigo e adicionar ao InnerHtml
                    string cardHtml = $@"
                    <div class='col-md-8'>
                        <div class='card bg-light mb-3 custom-card'>
                                <a href='PaginaArtigo.aspx?id={id}' class='card-link card-link-custom'>
                                <div class='card mb-3' style='border: 2px solid #000;'>
                                    <div class='card-header' style='font-weight: bold; background-color: #ccc;'>{titulo}</div>
                                    <div class='card-body' style='color: #213555;'>
                                        <h6 class='card-title'>{Subtitulo}</h6>
                                        <p class='card-text'>Publicado em: {dataPublicacao.ToShortDateString()}</p>
                                        <p class='card-text'>LIKES: {likes}</p>
                                    </div>
                                </div>
                                <a>
                        </div>
                    </div>";

                    cardsContainer.InnerHtml += cardHtml;
                }

                cardsContainer.Attributes["class"] = "d-flex justify-content-center flex-column align-items-center";
            }
        }//--------------------------------------------------------

 
    }
}

