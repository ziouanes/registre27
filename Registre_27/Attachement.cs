using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registre_27
{
    public partial class Attachement : DevExpress.XtraEditors.XtraForm
    {
        public Attachement()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog1 = new OpenFileDialog())
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                openFileDialog1.InitialDirectory = filePath;
                openFileDialog1.Filter = "pdf files (*.pdf) | *.pdf";


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string ss = openFileDialog1.FileName;
                    // pdfViewer1.LoadDocument(openFileDialog1.FileName);
                    using (FolderBrowserDialog ofd = new FolderBrowserDialog())
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            FileInfo fileInfo = new FileInfo(ss);
                            string mm = Path.Combine(ofd.SelectedPath, fileInfo.Name);
                            File.Copy(ss, mm, true);
                            MessageBox.Show("You have been succesfully copied.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    // Load a document from the stream.
                    //FileStream stream = new FileStream("..\\..\\Demo.pdf", FileMode.Open);
                }
            }
        }

        private void Attachement_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var rowM = gridView1.FocusedRowHandle;





            popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
        }
    }
}