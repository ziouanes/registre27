using Dapper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        int id_case = 0;

        public Attachement()
        {
            InitializeComponent();
            valide_folder();

        }
        public Attachement(int id)
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            id_case = id;
            valide_folder();
            valide_folder2();

        }

        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void valide_folder()
        {
            string folderPath = filePath + @"\Regincase";

            try
            {
                if (Directory.Exists(folderPath))
                {
                    //The code will execute if the folder exists
                }
                //The below code will create a folder if the folder is not exists in C#.Net.            
                DirectoryInfo folder = Directory.CreateDirectory(folderPath);
                //File.SetAttributes(
                //            filePath + " /Regincase",
                //            FileAttributes.Hidden |
                //            FileAttributes.ReadOnly
                //            );
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }

        public void valide_folder2()
        {
            string folderPath = filePath + @"\Regincase\"+id_case;

            try
            {
                if (Directory.Exists(folderPath))
                {
                    //The code will execute if the folder exists
                }
                //The below code will create a folder if the folder is not exists in C#.Net.            
                DirectoryInfo folder = Directory.CreateDirectory(folderPath);
                //File.SetAttributes(
                //            filePath + " /Regincase",
                //            FileAttributes.Hidden |
                //            FileAttributes.ReadOnly
                //            );
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
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
                    string _sourcePath = openFileDialog1.FileName;
                    string _fileName = openFileDialog1.SafeFileName;
                    string _targetPath = filePath + @"\Regincase\"+id_case;

                    // Use Path class to manipulate file and directory paths.
                    //string sourceFile = System.IO.Path.Combine(_sourcePath, _fileName);
                    string destFile = System.IO.Path.Combine(_targetPath, _fileName);

                    // To copy a folder's contents to a new location:
                    // Create a new target folder.
                    // If the directory already exists, this method does not create a new directory.
                    System.IO.Directory.CreateDirectory(_targetPath);

                    // To copy a file to another location and
                    // overwrite the destination file if it already exists.
                    System.IO.File.Copy(_sourcePath, destFile, true);

                    // To copy all the files in one directory to another directory.
                    // Get the files in the source folder. (To recursively iterate through
                    // all subfolders under the current directory, see
                    // "How to: Iterate Through a Directory Tree.")
                    // Note: Check for target path was performed previously
                    //       in this code example.
                    if (System.IO.Directory.Exists(_sourcePath))
                    {
                        string[] files = System.IO.Directory.GetFiles(_sourcePath);

                        // Copy the files and overwrite destination files if they already exist.
                        foreach (string s in files)
                        {
                            // Use static Path methods to extract only the file name from the path.
                            _fileName = System.IO.Path.GetFileName(s);
                            destFile = System.IO.Path.Combine(_targetPath, _fileName);
                            System.IO.File.Copy(s, destFile, true);
                        }
                    }

                    string sql = "insert into atachement([_name],[cas]) values(@filename,@numero)";


                    Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                    Program.sql_cmd.Parameters.AddWithValue("@filename", _fileName);
                    Program.sql_cmd.Parameters.AddWithValue("@numero",id_case);
                   



                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                    Program.sql_cmd.ExecuteNonQuery();
                    Program.sql_con.Close();






                    // toastNotificationsManager1.ShowNotification("d7c78ffd-cf9e-4830-8b0e-e5d91ccef33c");



                    select_attachement();
                    MessageBox.Show("You have been succesfully copied.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                   
                }
            }
        }

        private void select_attachement()
        {

            try
            {

                //stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id   ,_name  , cas from atachement where cas = { id_case}";
                classAtachementBindingSource1.DataSource = Program.sql_con.Query<classAtachement>(query, commandType: CommandType.Text);



                


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


        private void Attachement_Load(object sender, EventArgs e)
        {
            select_attachement();
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gridControl1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var rowM = gridView1.FocusedRowHandle;





            popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
        }

        private void barButtonopen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridView1.FocusedRowHandle;
            string _name;



            _name =(gridView1.GetRowCellValue(row2, "_name").ToString());

            //MessageBox.Show(filePath + @"\Regincase\" + id_case + @"\" + _name + "");
            pdfViewer1.LoadDocument(filePath + @"\Regincase\" + id_case + @"\" + _name + "");
        }

        private void barButtondelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var row3 = gridView1.FocusedRowHandle;
            string cellid;
            cellid = gridView1.GetRowCellValue(row3, "id").ToString();
            string _name;



            _name = (gridView1.GetRowCellValue(row3, "_name").ToString());
            if (MessageBox.Show("تأكيد الحذف من قائمة المرفقات    ?", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("delete from  atachement where id = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

                        deleteCommand.ExecuteNonQuery();



                    }

                    select_attachement();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //this.Dispose();
                }
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(filePath + @"\Regincase\" + id_case + @"\" + _name + "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}