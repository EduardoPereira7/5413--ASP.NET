using _5413__ASP.NET.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.DAL
{
    public class UtilizadorDAL
    {
        private string connectionString = @"Data Source=MSIGAMINGPLUS;Initial Catalog=ASP.NET;Integrated Security=True;";

        public bool AdicionarUtilizador(Utilizador utilizador)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Utilizadores (Nome, Email, Password, Verificado, Tipo) " +
                            "VALUES (@Nome, @Email, @Password, @Verificado, @Tipo)";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nome", utilizador.Nome);
                command.Parameters.AddWithValue("@Email", utilizador.Email);
                command.Parameters.AddWithValue("@Password", utilizador.Password);
                command.Parameters.AddWithValue("@Verificado", utilizador.Verificado);
                command.Parameters.AddWithValue("@Tipo", utilizador.Tipo);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Utilizador ObterUtilizadorPorEmail(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Utilizadores WHERE Email = @Email";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var utilizador = new Utilizador
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        Verificado = Convert.ToBoolean(reader["Verificado"]),
                        Tipo = reader["Tipo"].ToString()
                    };
                    return utilizador;
                }

                return null;
            }
        }

        public Utilizador ObterUtilizadorPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Utilizadores WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var utilizador = new Utilizador
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        Verificado = Convert.ToBoolean(reader["Verificado"]),
                        Tipo = reader["Tipo"].ToString()
                    };
                    return utilizador;
                }

                return null;
            }
        }
    }
}