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
    public partial class report : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {

        }



        public void PrintInvoice(string cellnumero,string celldate_cas , string celldescription , string cellprix , string cellnote , string cellafterhokm , string cellpername , string cellmahkama )
        {

            ReportRegistre reportRegistre = new ReportRegistre();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in reportRegistre.Parameters)
                p.Visible = false;


            reportRegistre.InitData(cellnumero, celldate_cas, celldescription, cellprix , cellnote , cellafterhokm  , cellpername  , cellmahkama);
            documentViewer1.DocumentSource = reportRegistre;

            reportRegistre.CreateDocument();

         
            

        }

        private void documentViewer3_Load(object sender, EventArgs e)
        {

        }
    }
}