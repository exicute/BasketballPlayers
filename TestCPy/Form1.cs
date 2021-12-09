using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestCPy
{
    public partial class MainForm : Form
    {
        string[] teamNames = new string[] {"Atlanta Hawks", "Boston Celtics", "Brooklyn Nets", "Charlotte Hornets", "Chicago Bulls",
                                                "Cleveland Cavaliers", "Dallas Mavericks", "Detroit Pistons", "Golden State Warriors", "Houston Rockets",
                                                "Indiana Pacers", "Los Angeles Lakers", "Los Angeles Clippers", "Memphis Grizzlies", "Miami Heat",
                                                "Milwaukee Bucks", "Minnesota Timberwolves", "New Orlean Pelicans", "New York Knicks", "Oklahoma City Thunder",
                                                "Orlando Magic", "Philadelphia 76ers", "Phoenix Suns", "Portland Trail Blazers", "Sacramento Kings",
                                                "San Antonio Spurs", "Toronto Raptors", "Utah Jazz", "Washington Wizards", "Denver Nuggets"};
        public Dictionary<string, string> teamNames_inexcel = new Dictionary<string, string>();

        DataTable thisTable;

        public MainForm()
        {
            InitializeComponent();

            foreach (string str in teamNames)
            {
                string tableName;
                string[] devidedStr = str.Split();
                if (devidedStr.Length < 3) tableName = devidedStr[0] + "_" + devidedStr[1] + "__";
                else tableName = devidedStr[0] + "_" + devidedStr[1] + "_" + devidedStr[2];
                teamNames_inexcel[str] = tableName;
            }

            TeamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            foreach (string str in teamNames)
            {
                TeamList.Items.Add(str);
            }
            TeamList.SelectedIndex = 0;    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo()
            {
                FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "//dist//BasketabllParser.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(procInfo);
        }

        private void OpenTeamTable(string path)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            foreach (DataTable table in db.Tables) thisTable = table;
        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                OpenTeamTable(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                            + $"//Players//{teamNames_inexcel[Convert.ToString(TeamList.SelectedItem)]}.xlsx");
                TeamTable.DataSource = thisTable;
                TeamTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Moccasin;
                TeamTable.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                
            }
            catch(System.IO.IOException)
            {
            }
        }

        private void searchField_Click(object sender, EventArgs e)
        {
            searchField.Text = "";
        }

        private void searchField_MouseLeave(object sender, EventArgs e)
        {
            if (searchField.Text == "") searchField.Text = "ВВЕДИТЕ ИМЯ";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Excel.Workbook xlWB;
            Excel.Worksheet xlSht;
            Excel.Application xlApp = new Excel.Application();

            for (int i = TeamTable.Rows.Count - 1; i >= 0; i--)
            {
                TeamTable.Rows.RemoveAt(i);
            }
            foreach (string str in teamNames)
            {
                try
                {
                    string xlFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                + $"//Players//{teamNames_inexcel[str]}.xlsx";

                    xlWB = xlApp.Workbooks.Open(xlFileName);

                    xlSht = (Microsoft.Office.Interop.Excel.Worksheet)xlWB.Worksheets["stats"];

                    string Value1 = searchField.Text;
                    string Value2 = xlSht.Range["B"].Value.ToString();

                    if (Value1 == Value2)
                    {
                        TeamTable.Rows.Add(Value2);
                    }
                    xlWB.Close(true);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    continue;
                }
            }
            xlApp.Quit();
        }
    }
}
