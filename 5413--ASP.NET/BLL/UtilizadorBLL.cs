using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class UtilizadorBLL
    {
        public string sqlCommand;

        public bool criarUtilizador(string nome, string email, string password, bool verificado, string tipo)
        {
            Utilizador u = new Utilizador(nome,email,password,verificado,tipo);
            sqlCommand = "Insert into Utilizadores (Nome, Email, Password, Verificado, Tipo) " +
                 "values ('" + u.getNome() + "','" + u.getEmail() + "','" + u.getPassword() + "'," +
                 u.getVerificacao() + ",'" + u.getTipo() + "')";
            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlCommand);
        }
        public Utilizador LoginUtilizador(string email, string password)
        {
            DAL.DAL dal = new DAL.DAL();
            sqlCommand = "SELECT * FROM Utilizadores WHERE Email = '" + email + "' AND Password = '" + password + "'";
            DataSet ds = dal.obterDs(sqlCommand);

            // Verifica se a consulta retornou algum resultado (utilizador encontrado).
            if (ds.Tables[0].Rows.Count > 0)
            {
                // Se houver pelo menos uma linha de resultado, cria um objeto Utilizador com os dados obtidos do banco de dados.
                DataRow row = ds.Tables[0].Rows[0];
                Utilizador user = new Utilizador(
                    row["Nome"].ToString(),
                    row["Email"].ToString(),
                    row["Password"].ToString(),
                    Convert.ToBoolean(row["Verificado"]),
                    row["Tipo"].ToString()
                );
                return user;
            }
            return null;
        }
        public DataSet obterUtilizadores(bool verificacao)
        {
            if (verificacao)
            {
                sqlCommand = "select * from Utilizadores";
            }
            else
            {
                sqlCommand = "select * from Utilizadores where Verificado = 0";
            }
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlCommand);
        }

    }
}