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

        }
        private void select_cas()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select c.id ,  c.numero , p.nom ,  c.date_cas , m.mahkama , c._description , c.prix , c.afterhokm , c.note , h.mahkama as 'hokm'   from cas c inner join Person p on c.Person_id = p.id inner join Mahkama m on m.id = c.mahkama  inner join hokm h on h.id = c.hokm";
              //  classPersonBindingSource.DataSource = Program.sql_con.Query<ClassPerson>(query, commandType: CommandType.Text);


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


        private void add_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cas cas = new cas();
            cas.ShowDialog();
        }
    }
}