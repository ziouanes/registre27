using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Registre_27
{
    public partial class ReportRegistre : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportRegistre()
        {
            InitializeComponent();
        }

        public void InitData(string cellnumero,string celldate_cas, string celldescription, string cellprix, string cellnote, string cellafterhokm, string cellpername, string cellmahkama)
        {

            
            

            Parameters["parameternumber"].Value = cellnumero;
            Parameters["parametername"].Value = cellpername;
            Parameters["parameterdate"].Value = celldate_cas;
            Parameters["parametermahkama"].Value = cellmahkama;
            Parameters["parameterprix"].Value = cellprix;
            Parameters["parameteretat"].Value = cellafterhokm;
            Parameters["parameterdescription"].Value = celldescription;
            Parameters["parameternote"].Value = cellnote;


          

        }

    }   
}
