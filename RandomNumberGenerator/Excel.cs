//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;
//using Excel_ref = Microsoft.Office.Interop.Excel;

//namespace RandomNumberGenerator
//{
//    public partial class Excel : Form
//    {
//        public Excel()
//        {
//            InitializeComponent();
//        }


//        Excel_ref.Application _Excel_App = new Excel_ref.Application();

//        public static Excel_ref.Workbook _curr_WorkBook;
//        public static Excel_ref.Worksheet _curr_WorkSheet;
//        public static Excel_ref.Range _curr_range;
//        string _chosen_file = "";

//        private void btnGetExcel_Click(object sender, EventArgs e)
//        {

//            openFileDialog1.Filter = "Excel Files (*.xls)|*.xls|Excel 2007(*xlsx)|*.xlsx";
//            if (openFileDialog1.ShowDialog() == DialogResult.OK)
//            {
//                _chosen_file = openFileDialog1.FileName;
//            }
//            if (_chosen_file == string.Empty)
//            {
//                return;
//            }
//            txtWorkBook.Text = _chosen_file;
//            getExcelData(txtWorkBook.Text);
//        }

//        private void getExcelData(string get_File)
//        {
//            FileStream F_stream = File.Open(get_File, FileMode.Open, FileAccess.Read);

//            _Excel_App = new Excel_ref.Application();
//            _curr_WorkBook = _Excel_App.Workbooks.Open(openFileDialog1.FileName,
//                0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
//                "\t", false, false, 0, true, 1, 0);
//            //_curr_WorkBook = _Excel_App.Workbooks.Open(openFileDialog1.FileName,
//            //               0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
//            //               "\t", false, false, 0, true, 1, 0);
//            _curr_WorkSheet = (Excel_ref.Worksheet)_curr_WorkBook.Worksheets.get_Item(1);
//            _curr_range = _curr_WorkSheet.UsedRange;

//            string str;
//            int rCnt = 0, cCnt = 0;
//            for (rCnt = 1; rCnt <= _curr_range.Rows.Count; rCnt++)
//            {
//                for (cCnt = 1; cCnt <= _curr_range.Columns.Count; cCnt++)
//                {
//                    str = (string)(_curr_range.Cells[rCnt, cCnt] as Excel_ref.Range).Value2;
//                    MessageBox.Show(str);
//                }
//            }
//            MessageBox.Show("Read all cell!");
//            //Excel_ref.Sheets sheets = _curr_WorkBook.Worksheets;

//            //if (get_File.EndsWith(".xlsx"))
//            //{

//            //}

//        }
//    }
//}