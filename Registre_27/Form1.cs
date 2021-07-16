using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Registre_27
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("sss");
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

                    pdfViewer1.LoadDocument(openFileDialog1.FileName);

                }
                    // Load a document from the stream.
                    //FileStream stream = new FileStream("..\\..\\Demo.pdf", FileMode.Open);
                }
            
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


           
               // FileStream stream = new FileStream(filePath + @"\N° d'enregistrement _ 3393.pdf", FileMode.Open);
                this.pdfViewer1.LoadDocument(filePath+@"\N° d'enregistrement _ 3393.pdf");


           
        }
    }
}
