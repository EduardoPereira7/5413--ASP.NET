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
                // Guarda o valor na sessão atual
                Session["indexAtualPagina"] = 0;
            }

            int indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            CarregarArtigos(indexAtualPagina);
        }//--------------------------------------------------------

        private void CarregarArtigos(int indexAtualPagina)
        {
            ArtigoBLL artigoBLL = new ArtigoBLL();
            DataSet dataSet = artigoBLL.ObterTodosOsArtigos();

            int artigosPorPagina = 4; //Nr. de artigos por pag
            int indexInicial = indexAtualPagina * artigosPorPagina;

            if (indexInicial >= 0 && indexInicial < dataSet.Tables[0].Rows.Count)
            {
                int indexFinal = Math.Min(indexInicial + artigosPorPagina, dataSet.Tables[0].Rows.Count);

                cardsContainer.InnerHtml = "";

                for (int i = indexInicial; i < indexFinal; i++)
                {
                    DataRow row = dataSet.Tables[0].Rows[i];
                    string id = row["Id"].ToString();
                    string titulo = row["Titulo"].ToString();
                    string subtitulo = row["Subtitulo"].ToString();
                    string likes = row["Likes"].ToString();
                    DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                    string cardHtml = $@"
            <div class='col-md-8'>
                <div class='card bg-light mb-3 custom-card'>
                    <a href='PaginaArtigo.aspx?id={id}' class='card-link card-link-custom'>
                        <div class='card mb-3' style='border: 2px solid #000;'>
                            <div class='card-header' style='font-weight: bold; background-color: #ccc;'>{titulo}</div>
                            <div class='card-body' style='color: #213555;'>
                                <h6 class='card-title'>{subtitulo}</h6>
                                <p class='card-text'>Publicado em: {dataPublicacao.ToShortDateString()}</p>
                                <p class='card-text'>LIKES: {likes}</p>
                            </div>
                        </div>
                    </a>
                </div>
            </div>";

                    cardsContainer.InnerHtml += cardHtml;
                }
                //Enable/disable os botões conforme o index
                btnPrev.Enabled = indexAtualPagina > 0;
                btnNext.Enabled = indexInicial + artigosPorPagina < dataSet.Tables[0].Rows.Count;
                lblSemArtigos.Visible = false;
                btnPrev.Visible = true;
                btnNext.Visible = true;
            }
            else
            {
                lblSemArtigos.Visible = true;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Visible = false;
                btnNext.Visible = false;
            }
        }//--------------------------------------------------------

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            int indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            indexAtualPagina--;
            Session["indexAtualPagina"] = indexAtualPagina;
            CarregarArtigos(indexAtualPagina);
        }//--------------------------------------------------------

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            indexAtualPagina++;
            Session["indexAtualPagina"] = indexAtualPagina;
            CarregarArtigos(indexAtualPagina);
        }//--------------------------------------------------------
    }
}

