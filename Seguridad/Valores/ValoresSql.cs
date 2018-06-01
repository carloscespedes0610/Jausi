using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p01.Valores
{
    public class ValoresSql
    {
        //SqlParameters
        public static string select_filter = "@SelectFilter";
        public static string where_filter = "@WhereFilter";
        public static string order_filter = "@OrderByFilter";

        // sql parametros Carlos
        public static string campos = "@"+nameof(campos);    //mismo nombre que los parametros del proced almacenado
        public static string filtrosWhere = "@"+nameof(filtrosWhere);



    }
}