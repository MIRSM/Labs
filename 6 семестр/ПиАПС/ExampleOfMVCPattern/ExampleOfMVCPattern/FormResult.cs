using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleOfMVCPattern
{
    public partial class FormResult : Form
    {
        SqlConnection connection;

        public FormResult()
        {
            InitializeComponent();
            connection = DBCon.GETDBConnection();
            connection.Open();
        }

        public bool GetAnswer(SqlCommand cmd)
        {
            cmd.Connection = connection;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    List<string> strList = new List<string>();
                    while (reader.Read())
                    {
                        strList.Add(reader.GetString(0));
                    }

                    foreach (var row in strList)
                    {
                        richTextBox1.AppendText(row + '\n');
                    }

                    ShowDialog();
                }
                else
                {
                    connection.Close();
                    return false;
                }

                connection.Close();
                return true;
            }
        }

        private void FormResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
