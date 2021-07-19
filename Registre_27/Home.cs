using Dapper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;
using System.Globalization;
using System.Data.SqlClient;

namespace Registre_27
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Home()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;

          
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            //navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
           // navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void Home_Load(object sender, EventArgs e)
        {
            select_cas();

        }


        private void select_cas()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select c.id ,  c.numero , p.nom ,  c.date_cas , m.mahkama , c._description , c.prix , c.afterhokm , c.note , h.mahkama as 'hokm'   from cas c inner join Person p on c.Person_id = p.id inner join Mahkama m on m.id = c.mahkama  inner join hokm h on h.id = c.hokm where c.deleted = 0";
                classCasBindingSource1.DataSource = Program.sql_con.Query<classCas>(query, commandType: CommandType.Text);



                //holy scrypt
                CultureInfo dateUICulture = new CultureInfo("fr-FR");
                repositoryItemDateEdit1.Properties.CalendarDateTimeFormatInfo = dateUICulture.DateTimeFormat;
                repositoryItemDateEdit1.Properties.DisplayFormat.Format = dateUICulture.DateTimeFormat;
                this.repositoryItemDateEdit1.Properties.EditFormat.Format = dateUICulture.DateTimeFormat;

                //repositoryItemDateEdit1.Mask.MaskType = MaskType.DateTime;
                //repositoryItemDateEdit1.Mask.EditMask = "dd-MM-yyyy";
                //repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;


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


        private void add_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cas cas = new cas();
            cas.ShowDialog();
            select_cas();
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var rowM = gridView1.FocusedRowHandle;


           

                
                    popupMenuitem.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
             
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridView1.FocusedRowHandle;
            int cellid;
           


            cellid = int.Parse(gridView1.GetRowCellValue(row2, "id").ToString());
         string   cellnumero = gridView1.GetRowCellValue(row2, "numero").ToString();
         DateTime   celldate_cas = Convert.ToDateTime(gridView1.GetRowCellValue(row2, "date_cas"));
         string   celldescription = gridView1.GetRowCellValue(row2, "_description").ToString();
         string   cellprix = gridView1.GetRowCellValue(row2, "prix").ToString();
         string   cellnote = gridView1.GetRowCellValue(row2, "note").ToString();
         string   cellafterhokm = gridView1.GetRowCellValue(row2, "afterhokm").ToString();
         string   cellpername = gridView1.GetRowCellValue(row2, "nom").ToString();
         string   cellmahkama = gridView1.GetRowCellValue(row2, "mahkama").ToString();
         string cellhokm = gridView1.GetRowCellValue(row2, "hokm").ToString();



            cas cas = new cas(cellid, cellnumero, celldate_cas, celldescription, cellprix, cellnote , cellafterhokm , cellpername , cellmahkama , cellhokm);
            cas.ShowDialog();
            select_cas();

        }

        private void barButtonattachement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridView1.FocusedRowHandle;
            int cellid;



            cellid = int.Parse(gridView1.GetRowCellValue(row2, "id").ToString());

            Attachement attachement = new Attachement(cellid);
            attachement.ShowDialog();

        }

        private void barButtondelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var row2 = gridView1.FocusedRowHandle;
            int cellid;
            string numero;


            cellid = int.Parse(gridView1.GetRowCellValue(row2, "id").ToString());
            numero = (gridView1.GetRowCellValue(row2, "numero").ToString());

            if (MessageBox.Show(  "تأكيد حذف القضية؟  "+numero, "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update cas set deleted = -1 where id = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid.ToString()));

                        deleteCommand.ExecuteNonQuery();



                    }

                    select_cas();
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

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItemetat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridView1.FocusedRowHandle;
            int cellid;
            string cellhokm;



            cellid = int.Parse(gridView1.GetRowCellValue(row2, "id").ToString());
            cellhokm =(gridView1.GetRowCellValue(row2, "hokm").ToString());

            Etat etat = new Etat(cellid,cellhokm);
            etat.ShowDialog();
            select_cas();


        }
    }
}