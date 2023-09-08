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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preencherDatas();
            }

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
            DataSet dataSet = artigoBLL.ObterArtigosPorData(anoSelecionado, mesSelecionado);

            afixaArtigos(dataSet);
        }//--------------------------------------------------------

        protected void btn_PesquisarPalavra_Click(object sender, EventArgs e)
        {
            string pesquisa = T_pesquisa.Text;
            L_alert.Visible = false;

            if (pesquisa.Length < 3)
            {
                L_alert.Visible = true;
                L_alert.Text = "São necessarias mais de 2 letras";
            }
            else
            {

                ArtigoBLL artigoBLL = new ArtigoBLL();
                DataSet dataSet = artigoBLL.ObterArtigosPorPalavra(pesquisa);
                T_pesquisa.Text = string.Empty;
                afixaArtigos(dataSet);

            }
        }//--------------------------------------------------------

        protected void afixaArtigos(DataSet dataSet)
        {
            CardsContainer.InnerHtml = string.Empty;
            if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                L_alert.Visible = true;
                CardsContainer.InnerHtml = "";
                L_alert.Text = "Não foram encontrados resultados";
                return;
            }

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string id = row["Id"].ToString();
                string titulo = row["Titulo"].ToString();
                string Subtitulo = row["Subtitulo"].ToString();
                string likes = row["likes"].ToString();
                DateTime dataPublicacao = Convert.ToDateTime(row["DataPublicacao"]);

                // Criar o HTML do card para cada artigo e adicionar ao InnerHtml
                string cardHtml = $@"
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
                    </div>";

                CardsContainer.InnerHtml += cardHtml;
            }

            CardsContainer.Attributes["class"] = "d-flex justify-content-center flex-column align-items-center";
        }//--------------------------------------------------------
    }
}