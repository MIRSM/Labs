using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ExampleOfMVCPattern
{
    class DBCon
    {
        public static SqlConnection GETDBConnection()
        {
            string conString = "Data Source=DESKTOP-N625QE2;Initial Catalog=Warehause;Integrated Security=True";

            return new SqlConnection(conString);
        }
    }
}
