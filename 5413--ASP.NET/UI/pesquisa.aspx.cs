using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            for (int mes = 0; mes <= 12; mes++)
                meses.Add(mes);
            DD_Mes.DataSource = meses;
            DD_Mes.DataBind();
        }//--------------------------------------------------------

        protected void btn_Pesquizar_Click(object sender, EventArgs e)
        {
            string sAno = DD_Anos.SelectedValue;
            string sMes = DD_Mes.SelectedValue;
            List_ResultadosPesquisa.Items.Add(sAno + " " + sMes);

        }//--------------------------------------------------------
    }
}