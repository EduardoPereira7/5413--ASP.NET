using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5413__ASP.NET.UI
{
    public partial class editarUtilizador : System.Web.UI.Page
    {
        protected DataSet ds;
        static int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userID = int.Parse(Request.QueryString["id"]);
                preencheUtilizador(userID);
            }
            
        }

        protected void preencheUtilizador(int userID)
        {
            BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();
            ds = b.obterUtilizador(userID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtNome.Text = row["Nome"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPassword.Text = string.Empty;
                
                chkVerificado.Checked = Convert.ToBoolean(row["Verificado"]);
                chkAdmin.Checked = Convert.ToBoolean(row["Admin"]);
            }
        }

        protected void btnEditarUtilizador_Click(object sender, EventArgs e)
        {
            string novoNome = txtNome.Text;
            string novoEmail = txtEmail.Text;
            string novaPassword;
            if (chkNaoAlterarSenha.Checked)
            {
                BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();
                ds = b.obterUtilizador(userID);
                DataRow row = ds.Tables[0].Rows[0];
                novaPassword = row["Password"].ToString();
            }
            else
            {
                novaPassword = txtPassword.Text;
            }
            int novoVerificado = chkVerificado.Checked ? 1 : 0;
            int novoAdmin = chkAdmin.Checked ? 1 : 0;

            if (string.IsNullOrWhiteSpace(novoNome) || string.IsNullOrWhiteSpace(novoEmail))
            {
                lblAvisoNome.Visible = true;
                lblAvisoEmail.Visible = true;
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(novaPassword) && !chkNaoAlterarSenha.Checked)
                {
                    lblAvisoPassword.Visible = true;
                    return;
                }
                else
                {
                    lblAvisoNome.Visible = false;
                    lblAvisoEmail.Visible = false;
                    lblAvisoPassword.Visible = false;
                }
                
            }

            BLL.UtilizadorBLL utilizadorBLL = new BLL.UtilizadorBLL();
            bool edicaoBemSucedida = utilizadorBLL.editarUtilizador(userID, novoNome, novoEmail, novaPassword, novoVerificado, novoAdmin);

            if (edicaoBemSucedida)
            {
                Session["FeedbackMessage"] = "Utilizador editado com sucesso!";
            }
            else
            {
                Session["FeedbackMessage"] = "Ocorreu um erro ao editar o utilizador. Por favor, tente novamente.";
            }
            
            Response.Redirect("~/UI/AdminDashboard.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AdminDashboard.aspx");
        }

        protected void chkNaoAlterarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNaoAlterarSenha.Checked)
            {
                txtPassword.Enabled = false;
                txtPassword.Text = string.Empty;
            }
            else
            {
                txtPassword.Enabled = true;
            }
        }
    }
}