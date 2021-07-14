using Dapper;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registre_27
{
    public partial class cas : DevExpress.XtraEditors.XtraForm
    {
        private int id;

        public cas()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            CultureInfo dateUICulture = new CultureInfo("fr-FR");
            date1.Properties.CalendarDateTimeFormatInfo = dateUICulture.DateTimeFormat;
            date1.Properties.DisplayFormat.Format = dateUICulture.DateTimeFormat;
            this.date1.Properties.EditFormat.Format = dateUICulture.DateTimeFormat;

            this.date1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            select_Person();
        }

        private void cas_Load(object sender, EventArgs e)
        {
            per1.Properties.Buttons[1].Click += addper;


            //this.date1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            //this.date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //this.date1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            //this.date1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        }

        private void select_Person()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id , nom from Person ";
                personBindingSource.DataSource = Program.sql_con.Query<ClassPerson>(query, commandType: CommandType.Text);


                per1.Properties.PopulateColumns();
                per1.Properties.Columns[0].Visible = false;
               

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

            private void addper(object sender, EventArgs e)
        {
            Person person = new Person();
            person.ShowDialog();
        }

        private void windowsUIButtonPanelMain_Click(object sender, EventArgs e)
        {





        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;

            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {
                try
                {








                    if (id == 0)
                    {
                        if (per1.ItemIndex == -1 || mahkama1.ItemIndex == -1 || number1.Text == "" || date1.Text == "" || description.Text == "" || note.Text == ""|| finish.Text == "" || prix.Text == "" || hokm.ItemIndex == -1)
                        {
                            XtraMessageBox.Show("champs obligatoires");

                        }
                        else
                        {
                          

                            string sql = "insert into [cas]([numero] ,[date_cas],[_description],[prix],[note],[afterhokm] , [Person_id]  ,[mahkama]  ,[hokm]  ) VALUES(@numero,@date_cas,@_description , @prix , @prix ,@note , @afterhokm ,@Person_id ,@mahkama ,@hokm  )";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@numero", number1.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@date_cas", date1.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@_description", description.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@prix", prix.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@note", note.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@afterhokm", finish.Text);

                            Program.sql_cmd.Parameters.AddWithValue("@Person_id", per1.EditValue);
                            Program.sql_cmd.Parameters.AddWithValue("@mahkama", mahkama1.EditValue);
                            Program.sql_cmd.Parameters.AddWithValue("@hokm", hokm.EditValue);



                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();


                           


                        
                            toastNotificationsManager1.ShowNotification("d7c78ffd-cf9e-4830-8b0e-e5d91ccef33c");


                            this.Close();

                        }




                    }
                    else
                    {

                        if (per1.ItemIndex == -1 || mahkama1.ItemIndex == -1 || number1.Text == "" || date1.Text == "" || description.Text == "" || note.Text == "" || finish.Text == "" || prix.Text == "" || hokm.ItemIndex == -1)
                        {
                            XtraMessageBox.Show("champs obligatoires");

                        }
                        //else
                        //{
                        //    DateTime dtconvocation = Convert.ToDateTime(textEditconvocation.EditValue);
                        //    DateTime dtjORNAL = Convert.ToDateTime(textEditJornal.EditValue);
                        //    DateTime dtpORTAIL = Convert.ToDateTime(textEditportai.EditValue);
                        //    DateTime dtop = Convert.ToDateTime(dateEditop.EditValue);


                        //    string sql = "update  [publication] set [Aop]  = @Aop ,[date_jornal] =  @date_jornal ,[date_portail]  = @date_portail,[date_convocation]  = @date_convocation ,[date_op]  = @date_op where id2 = @id2";


                        //    Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                        //    Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.Text + textEditaoodate.Text);
                        //    Program.sql_cmd.Parameters.AddWithValue("@date_jornal", dtjORNAL);
                        //    Program.sql_cmd.Parameters.AddWithValue("@date_portail", dtpORTAIL);
                        //    Program.sql_cmd.Parameters.AddWithValue("@date_convocation", dtconvocation);
                        //    Program.sql_cmd.Parameters.AddWithValue("@date_op", dtop);
                        //    Program.sql_cmd.Parameters.AddWithValue("@id2", id2);




                        //    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                        //    Program.sql_cmd.ExecuteNonQuery();
                        //    Program.sql_con.Close();





                        //    toastNotificationsManager1.ShowNotification("63e40279-d885-4efa-91fd-073fbda47ee2");


                        //    this.Close();
                        //}


                    }




                }








                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
                finally
                {
                    //this.Dispose();
                }

            }



            }
        }
}