using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class ArtigoBLL
    {
        public string sqlCommand;

        public DataSet ObterArtigosDoUtilizador(int utilizadorId)
        {
            string sqlSelect = $"SELECT A.*, C.Nome AS NomeCategoria " +
                      $"FROM Artigos AS A " +
                      $"INNER JOIN Categorias AS C ON A.CategoriaId = C.Id " +
                      $"WHERE A.UtilizadorId = {utilizadorId}";

            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }
        public DataSet ObterTodosOsArtigos()
        {
            string sqlSelect = $"SELECT * FROM Artigos";
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }
        public void eliminarArtigo(int artigoID)
        {
            string sql = "DELETE FROM Artigos WHERE Id = " + artigoID;
            DAL.DAL dal = new DAL.DAL();
            dal.crud(sql);
        }
        public bool CriarArtigo(string titulo, string subtitulo, string conteudo, DateTime dataPublicacao, bool acessibilidade, int categoriaId, int utilizadorId)
        {
            string sqlInsert = $@"
            INSERT INTO Artigos (Titulo, Subtitulo, Conteudo, DataPublicacao, Acessibilidade, CategoriaId, UtilizadorId)
            VALUES ('{titulo}', '{subtitulo}', '{conteudo}', '{dataPublicacao.ToString("yyyy-MM-dd HH:mm:ss")}', '{(acessibilidade ? "1" : "0")}', {categoriaId}, {utilizadorId})
            ";

            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlInsert);
        }
        public DataSet ObterArtigo(int artigoID)
        {
            string sql = $"SELECT A.*, C.Nome AS NomeCategoria " +
                 $"FROM Artigos AS A " +
                 $"INNER JOIN Categorias AS C ON A.CategoriaId = C.Id " +
                 $"WHERE A.Id = {artigoID}";
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sql);
        }
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
        }

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
        }

        public DataSet ObterArtigosPorPalavra(string palavra)
        {
            string sqlSelect = $@" select * from artigos where conteudo like '%" + palavra + "%';";

            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }
    }
}