using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleOfMVCPattern
{
    class Controller
    {

        
        public Controller()
        {
        }

        public bool Question(string name)
        {
            SqlCommand cmd = new SqlCommand($"SELECT Surname FROM Members WHERE First_Name = @name");
            cmd.Parameters.Add("@name", SqlDbType.NChar).Value = name;

            FormResult fr = new FormResult();
            return fr.GetAnswer(cmd);
        }
    }
}
