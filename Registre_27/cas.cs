using Dapper;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
        private int id = 0;
        private string _nom = "";
        private string _hokm = "";
        private string _mahkama = "";

        public cas(int id , string numero, DateTime date_cas ,string description ,string prix , string note  , string afterhokm , string pername , string mahkama , string hokm)
        {

            InitializeComponent();
            select_Person();
            select_Mahkama();
            select_hokm();

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


            this.id = id;
            this.number1.Text = numero;
            DateTime dt = date_cas;
            this.description.Text = description;
            this.prix.Text = prix;
            this.note.Text = note;
            this.finish.Text = afterhokm;
            this._nom = pername;
            this._mahkama = mahkama;
            this._hokm = hokm;



            if (id != 0)
            {
                date1.EditValue = dt;
            }

            this.mahkama1.Properties.SearchMode = SearchMode.AutoComplete;
            this.hokm.Properties.SearchMode = SearchMode.AutoComplete;
            this.per1.Properties.SearchMode = SearchMode.AutoComplete;


        }


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
            select_Mahkama();
            select_hokm();

        }

        private void cas_Load(object sender, EventArgs e)
        {
            per1.Properties.Buttons[1].Click += addper;

            //this.date1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            //this.date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //this.date1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            //this.date1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            if (id != 0)
            {
                hokm.SelectedText = _hokm;
                hokm.ForeColor = Color.Red;
            }
            if (id != 0)
            {
                per1.Text = _nom;
                per1.ForeColor = Color.Red;
            }

            if (id != 0)
            {
                mahkama1.Text = _mahkama;
                mahkama1.ForeColor = Color.Red;
            }
        }

        private void select_Person()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id , nom from Person ";
                classPersonBindingSource.DataSource = Program.sql_con.Query<ClassPerson>(query, commandType: CommandType.Text);


                //per1.Properties.PopulateColumns();
                //per1.Properties.Columns["id"].Visible = false;

              

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

        private void select_Mahkama()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id , mahkama from Mahkama ";
                classMahkamaBindingSource.DataSource = Program.sql_con.Query<ClassMahkama>(query, commandType: CommandType.Text);


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


        private void addper(object sender, EventArgs e)
        {
            Person person = new Person();
            person.ShowDialog();
            select_Person();
            
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
                          

                            string sql = "insert into [cas]([numero] ,[date_cas],[_description],[prix],[note],[afterhokm] , [Person_id]  ,[mahkama]  ,[hokm]  ) VALUES(@numero,@date_cas,@_description , @prix  ,@note , @afterhokm ,@Person_id ,@mahkama ,@hokm  )";


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
                        else
                        {
                           


                            string sql = "update  [cas] set [numero]  = @numero ,[date_cas] =  @date_cas ,[_description]  = @_description,[prix]  = @prix ,[note]  = @note , [afterhokm] = @afterhokm , [Person_id] = @Person_id , [mahkama] =@mahkama , [hokm] = @hokm where id = @id";


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
                            Program.sql_cmd.Parameters.AddWithValue("@id", id);




                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();





                           // toastNotificationsManager1.ShowNotification("63e40279-d885-4efa-91fd-073fbda47ee2");


                            this.Close();
                        }


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