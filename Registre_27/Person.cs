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
    }
}