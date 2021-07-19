using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class Etat : DevExpress.XtraEditors.XtraForm
    {
        public Etat()
        {
            InitializeComponent();
            select_hokm();

        }

        int _id = 0;
        string _hokm = "";

        public Etat(int id , string hokm)
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            _id = id;
            _hokm = hokm;

            select_hokm();

            this.lookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;

            lookUpEdit1.Text = _hokm;
            lookUpEdit1.ForeColor = Color.Red;
        }

        private void select_hokm()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id , mahkama from hokm ";
                classhokmBindingSource.DataSource = Program.sql_con.Query<Classhokm>(query, commandType: CommandType.Text);


                //per1.Properties.PopulateColumns();
                //per1.Properties.Columns[1].Visible = false;

               


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

        private void Etat_Load(object sender, EventArgs e)
        {
        

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update cas set hokm = @hokm where id = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@hokm", (lookUpEdit1.EditValue));
                        deleteCommand.Parameters.AddWithValue("@id", (_id));

                        deleteCommand.ExecuteNonQuery();



                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //this.Dispose();
                }

            this.Close();
        }

    }
}