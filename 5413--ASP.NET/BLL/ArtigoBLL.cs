using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class ArtigoBLL
    {
        public string sqlCommand;
        public DataSet ObterArtigosDoUtilizador(int utilizadorId, int offset, int artigosPorPagina)
        {
            string sqlSelect = $"SELECT A.*, C.Nome AS NomeCategoria " +
                              $"FROM Artigos AS A " +
                              $"INNER JOIN Categorias AS C ON A.CategoriaId = C.Id " +
                              $"WHERE A.UtilizadorId = {utilizadorId} " +
                              $"ORDER BY DataPublicacao DESC " +
                              $"OFFSET {offset} ROWS " +
                              $"FETCH NEXT {artigosPorPagina} ROWS ONLY";
            //Offset com fetch - para paginar os artigos
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }
        public int ObterTotalArtigosDoUtilizador(int utilizadorId)
        {
            string sqlCount = $"SELECT COUNT(*) " +
                              $"FROM Artigos " +
                              $"WHERE UtilizadorId = {utilizadorId}";

            DAL.DAL dal = new DAL.DAL();
            return dal.countRows(sqlCount);
        }

        public DataSet ObterTodosOsArtigos()
        {
            string sqlSelect = $"SELECT * FROM Artigos ORDER BY DataPublicacao DESC";
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }//-------------------------------------------------------

        public bool eliminarArtigo(int artigoID)
        {
            string sql = "DELETE FROM Artigos WHERE Id = " + artigoID;
            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sql);
        }//-------------------------------------------------------

        public bool CriarArtigo(string titulo, string subtitulo, string conteudo, DateTime dataPublicacao, bool acessibilidade, int categoriaId, int utilizadorId)
        {
            string sqlInsert = $@"
            INSERT INTO Artigos (Titulo, Subtitulo, Conteudo, DataPublicacao, Acessibilidade, CategoriaId, UtilizadorId,likes)
            VALUES ('{titulo}', '{subtitulo}', '{conteudo}', '{dataPublicacao.ToString("yyyy-MM-dd HH:mm:ss")}', '{(acessibilidade ? "1" : "0")}', {categoriaId}, {utilizadorId} , 0)
            ";

            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlInsert);
        }//-------------------------------------------------------

        public DataSet ObterArtigo(int artigoID)
        {
            string sql = $"SELECT A.*, C.Nome AS NomeCategoria " +
                 $"FROM Artigos AS A " +
                 $"INNER JOIN Categorias AS C ON A.CategoriaId = C.Id " +
                 $"WHERE A.Id = {artigoID}";
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sql);
        }//-------------------------------------------------------

        public bool editarArtigo(int artigoId, string novoTitulo, string novoSubtitulo, string novoConteudo, int novaCategoriaId, bool novaAcessibilidade)
        {
            string sqlUpdate = $@"UPDATE Artigos
                SET Titulo = '{novoTitulo}',
                Subtitulo = '{novoSubtitulo}',
                Conteudo = '{novoConteudo}',
                CategoriaId = {novaCategoriaId},
                Acessibilidade = {(novaAcessibilidade ? "1" : "0")}
                WHERE Id = {artigoId}";

            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlUpdate);
        }//-------------------------------------------------------

        public DataSet ObterArtigosPorData(int ano, int mes)
        {
            string sqlSelect = $@"
            SELECT A.*, C.Nome AS NomeCategoria
            FROM Artigos AS A
            INNER JOIN Categorias AS C ON A.CategoriaId = C.Id
            WHERE YEAR(A.DataPublicacao) = {ano} AND MONTH(A.DataPublicacao) = {mes}
            ";

            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }//-------------------------------------------------------

        public DataSet ObterArtigosPorPalavra(string palavra)
        {
            string sqlSelect = $@" select * from artigos where conteudo like '%" + palavra + "%';";

            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }//-------------------------------------------------------

        public int Liked(int artigo, int user)
        {
            string sqlSelect = "SELECT * FROM likes WHERE ArtigoId = " + artigo
                + "AND UtilizadorId = " + user
                + " AND liked = 1;";

            DAL.DAL dal = new DAL.DAL();
            SqlConnection conn = new SqlConnection(dal.getconnString());
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sqlSelect;
            cmd.Connection = conn;
            object result = cmd.ExecuteScalar();
            int rowCount = Convert.ToInt32(result);

            conn.Close();
            return rowCount;
        }//-------------------------------------------------------
        public void likeArtigo(int artigo, int user)
        {

            DAL.DAL dal = new DAL.DAL();
            SqlConnection conn = new SqlConnection(dal.getconnString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            string sqlSelect = "insert into likes  values (" + user + "," + artigo + ",1);";
            cmd.CommandText = sqlSelect;            
            cmd.ExecuteNonQuery();

            sqlSelect = "UPDATE artigos SET [Likes] = [Likes] + 1 WHERE [Id] = " + artigo + ";";
            cmd.CommandText = sqlSelect;
            cmd.ExecuteNonQuery();

            conn.Close();
        }//-------------------------------------------------------

    }
}