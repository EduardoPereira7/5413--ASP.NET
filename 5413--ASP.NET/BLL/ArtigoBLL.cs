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
        public void eliminarArtigo(int artigoID)
        {
            string sql = "DELETE FROM Artigos WHERE Id = " + artigoID;
            DAL.DAL dal = new DAL.DAL();
            dal.crud(sql);
        }
    }
}