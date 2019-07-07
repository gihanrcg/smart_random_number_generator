
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel_ref = Microsoft.Office.Interop.Excel;


namespace RandomNumberGenerator
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        private static Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        private static Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\Private\MS_CLUB\AGM\SurveyReport.xlsx");
        private static Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

        Dictionary<int, string> sizeMap = new Dictionary<int, string>();

        public frmMain()
        {
            //dt = Excel.ReadExcelFile("Sheet1","D:\\Private\\MS_CLUB\\AGM\\SurveyReport.xlsx");
            InitializeComponent();
        }

   
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            progressBarInitialization();
            generateNo();                   
        }

        private void generateNo()
        {
            int startNumber = 0;
            int endNumber = sizeMap.Count;
            //int startNumber = Int32.Parse(txtStart.Value.ToString());
            //int endNumber = Int32.Parse(txtEnd.Value.ToString());

            runLoop(startNumber, endNumber);
            hideProgressBar();

            Random rand = new Random();
            int n = rand.Next(startNumber, endNumber + 1);

            if (isNumberAvailable(n))
            {
                lblResult.Text = n.ToString();
            }
            else
            {
                generateNo();
            }
            
        }

        private Boolean isNumberAvailable(int n)
        {
            if (sizeMap[n].Equals("M",StringComparison.InvariantCultureIgnoreCase))
            {
                if (txtM.Value > 0)
                {
                    return true;
                }
            }
            else if (sizeMap[n].Equals("XS", StringComparison.InvariantCultureIgnoreCase))
            {
                if (txtXs.Value > 0)
                {
                    return true;
                }
            }
            else if (sizeMap[n].Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                if (txtS.Value > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void hideProgressBar()
        {
            progressBar.Visible = false;
            progressBar.SendToBack();

        }
        private void progressBarInitialization()
        {
            progressBar.BringToFront();
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }

        private void runLoop(int start,int end)
        {
            for(int i = 0; i <= 100; i++)
            {
                Thread.Sleep(3);
                progressBar.Value = i;
                progressBar.Text = i.ToString() + "%";
                progressBar.Update();                
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                //Console.WriteLine(xlRange.Cells[i, 1].Value2.ToString() + " " + xlRange.Cells[i, 9].Value2.ToString());
                sizeMap.Add(Int32.Parse(xlRange.Cells[i, 1].Value2.ToString()), xlRange.Cells[i, 9].Value2.ToString());

                //for (int j = 1; j <= colCount; j++)
                //{
                //    MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
                //}
            }
        }

       

    }
}
