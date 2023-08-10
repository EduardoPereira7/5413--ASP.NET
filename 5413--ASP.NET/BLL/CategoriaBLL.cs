using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class CategoriaBLL
    {
        public DataSet ObterCategorias()
        {
            string sqlSelect = "SELECT * FROM Categorias";

            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlSelect);
        }

    }
}