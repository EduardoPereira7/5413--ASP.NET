using _5413__ASP.NET.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class pesquisa1 : System.Web.UI.Page
    {
        int indexAtualPagina;

        int artigosPorPagina = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preencherDatas();
                Session["indexAtualPagina"] = 0;
            }
            indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            
            
        }//--------------------------------------------------------

        protected void preencherDatas()
        {
            int anoCorrente = DateTime.Now.Year;

            List<int> anos = new List<int>();
            for (int ano = anoCorrente; ano >= anoCorrente - 10; ano--)
                anos.Add(ano);

            DD_Anos.DataSource = anos;
            DD_Anos.DataBind();


            List<int> meses = new List<int>();
            for (int mes = 1; mes <= 12; mes++)
                meses.Add(mes);
            DD_Mes.DataSource = meses;
            DD_Mes.DataBind();
        }//--------------------------------------------------------

        protected void btn_Pesquizar_Click(object sender, EventArgs e)
        {

            L_alert.Visible = false;
            int anoSelecionado = Convert.ToInt32(DD_Anos.SelectedValue);
            int mesSelecionado = Convert.ToInt32(DD_Mes.SelectedValue);

            ArtigoBLL artigoBLL = new ArtigoBLL();
            Session["MeuDataSet"] = artigoBLL.ObterArtigosPorData(anoSelecionado, mesSelecionado);
            

            afixaArtigos(indexAtualPagina);
        }//--------------------------------------------------------

        protected void btn_PesquisarPalavra_Click(object sender, EventArgs e)
        {
            string pesquisa = T_pesquisa.Text;
            L_alert.Visible = false;

            if (pesquisa.Length < 3)
            {
                L_alert.Visible = true;
                L_alert.Text = "São necessárias mais de 2 letras";
            }
            else
            {

                ArtigoBLL artigoBLL = new ArtigoBLL();
                Session["MeuDataSet"] = artigoBLL.ObterArtigosPorPalavra(pesquisa);
                T_pesquisa.Text = string.Empty;
                afixaArtigos(indexAtualPagina);

            }
        }//--------------------------------------------------------

        protected void afixaArtigos(int indexAtualPagina)
        {
            DataSet dataSet = (DataSet)Session["MeuDataSet"];
            int indexInicial = indexAtualPagina * artigosPorPagina;

            if (indexInicial >= 0 && indexInicial < dataSet.Tables[0].Rows.Count)
            {
                int indexFinal = Math.Min(indexInicial + artigosPorPagina, dataSet.Tables[0].Rows.Count);
                CardsContainer.InnerHtml = string.Empty;
                
                L_alert.Visible = false;
                for (int i = indexInicial; i < indexFinal; i++)
                {
                    DataRow row = dataSet.Tables[0].Rows[i];
                    string id = row["Id"].ToString();
                    string titulo = row["Titulo"].ToString();
                    string Subtitulo = row["Subtitulo"].ToString();
                    string likes = row["likes"].ToString();
                    DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                    string cardHtml = $@"
                    <div class='card bg-light mb-3 custom-card'>
                            <a href='PaginaArtigo.aspx?id={id}' class='card-link card-link-custom'>
                            <div class='card mb-3' style='border: 2px solid #000;'>
                                <div class='card-header' style='font-weight: bold; background-color: #ccc;'>{titulo}</div>
                                <div class='card-body' style='color: #213555;'>
                                    <h6 class='card-title'>{Subtitulo}</h6>
                                    <p class='card-text'>Publicado em: {dataPublicacao.ToShortDateString()}</p>
                                    <p class='card-text'>Gostos: {likes}</p>
                                </div>
                            </div>
                            <a>
                    </div>";

                    CardsContainer.InnerHtml += cardHtml;
                }
                CardsContainer.Attributes["class"] = "d-flex justify-content-center flex-column align-items-center";
                btnPrev.Visible = true;
                btnNext.Visible = true;
                btnPrev.Enabled = indexAtualPagina > 0;
                btnNext.Enabled = indexInicial + artigosPorPagina < dataSet.Tables[0].Rows.Count;
            }
            else
            {
                L_alert.Visible = true;
                btnPrev.Visible = false;
                btnNext.Visible = false;
                CardsContainer.InnerHtml = "";
                L_alert.Text = "Não foram encontrados resultados";
                return;

            }
        }//--------------------------------------------------------

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            int indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            indexAtualPagina--;
            Session["indexAtualPagina"] = indexAtualPagina;
            afixaArtigos(indexAtualPagina);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int indexAtualPagina = Convert.ToInt32(Session["indexAtualPagina"]);
            indexAtualPagina++;
            Session["indexAtualPagina"] = indexAtualPagina;
            
            afixaArtigos(indexAtualPagina);
        }
    }
}