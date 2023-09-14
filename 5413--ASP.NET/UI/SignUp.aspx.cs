using _5413__ASP.NET.BLL;
using _5413__ASP.NET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _5413__ASP.NET.UI
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string Nome = txtFirstName.Text + " " + txtLastName.Text;
            string Email = txtRegisterEmail.Text;
            string Password = txtRegisterPassword.Text;

            lblRegisterError.Text = "";
            int validateCount = 0;

            if (Nome.Length > 4)
                validateCount++;
            else
            {
                lblRegisterError.Visible = true;
                lblRegisterError.Text = "Nome tem de ter mais de 5 caracteres, ";
            }

            string verificarEmail = ValidateEmail(Email);
            if (verificarEmail == "valido")
            {
                validateCount++;
            }
            else
            {
                lblRegisterError.Visible = true;
                lblRegisterError.Text = verificarEmail;
            }

            if (Password.Length > 4)
                validateCount++;
            else
            {
                lblRegisterError.Visible = true;
                lblRegisterError.Text += "Password  tem de ter mais  de 5 caracteres ";
            }

            if (validateCount > 2)
            {
                BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();

                if (b.criarUtilizador(Nome, Email, Password))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblRegisterError.Visible = true;
                    lblRegisterError.Text = "Ocorreu um erro ao registar. Por favor, tente novamente.";
                }
            }
        }//----------------------------------------------------------------------------------------------------



        protected string ValidateEmail(string email)
        {
            // Regular expression pattern for basic email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);
            // Use the Regex object to match the email
            if (!regex.IsMatch(email))
                return "Email invalido, ";

            BLL.UtilizadorBLL b = new BLL.UtilizadorBLL();

            if (b.verSeEmailJaExiste(email)>0)
                return "Este Email já foi utilizado";

            return "valido";

        }//----------------------------------------------------------------------------------------------------


    }
}