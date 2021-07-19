using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registre_27
{
    public partial class Person : DevExpress.XtraEditors.XtraForm
    {
        public Person()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Person_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

            

            string sql = "insert into Person([nom]) values(@name)";


            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
            Program.sql_cmd.Parameters.AddWithValue("@name", textEdit1.Text);




            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            Program.sql_cmd.ExecuteNonQuery();
            Program.sql_con.Close();
            this.Close();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }

        }
    }
}