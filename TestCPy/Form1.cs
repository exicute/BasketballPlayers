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
                                                "Milwaukee Bucks", "Minnesota Timberwolves", "New Orleans Pelicans", "New York Knicks", "Oklahoma City Thunder",
                                                "Orlando Magic", "Philadelphia 76ers", "Phoenix Suns", "Portland Trail Blazers", "Sacramento Kings",
                                                "San Antonio Spurs", "Toronto Raptors", "Utah Jazz", "Washington Wizards", "Denver Nuggets"};
        public Dictionary<string, string> statsList = new Dictionary<string, string>(){{"Rk", "A"}, {"Name", "B"},
                                            { "Age", "C"}, { "G", "D"}, { "GS", "E"}, { "MP", "F"}, { "FG","G"}, 
                                            { "FGA", "H"}, { "FG%", "I"}, { "3P", "J"}, { "3PA", "K"}, { "3P%", "L"}, { "2P", "M"},
                                            { "2PA", "N"}, { "2P%", "O"}, { "eFG%", "P"}, { "FT", "Q"}, { "FTA", "R"}, { "FT%", "S"},
                                            { "ORB", "T"}, { "DRB", "U"}, { "TRB", "V"}, { "AST", "W"}, { "STL", "X"}, { "BLK", "Y"}, 
                                            { "TOV", "Z"}, { "PF", "AA"}, { "PTS", "AB"}
                                            };
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

            statsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            foreach (string str in statsList.Keys)
            {
                if (str != "Rk" & str != "Name") statsComboBox.Items.Add(str);
            }

            TeamList.SelectedIndex = 0;
            statsComboBox.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo()
            {
                FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "//dist//BasketabllParser.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            var thisProcess = Process.Start(procInfo);
        }

        
        
        private void OpenTeamTable(string path)
        {
            DataSet db;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    db = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }
            }
            foreach (DataTable table in db.Tables) thisTable = table;
        }

        private void GetSearchRow(int rowNum, string team)
        {
            if (rowNum >= 0)
            {
                TeamList.SelectedItem = team;
                TeamTable.Rows[rowNum-2].Selected = true;
            }
        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                OpenTeamTable(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                            + $"//Players//{teamNames_inexcel[Convert.ToString(TeamList.SelectedItem)]}.xlsx");
                TeamTable.DataSource = thisTable;
                TeamTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Moccasin;
                TeamTable.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

                teamPicture.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                            + $"//Players//{teamNames_inexcel[Convert.ToString(TeamList.SelectedItem)]}.jpg");
            }
            catch(System.IO.IOException)
            {
            }
        }

        private void searchField_Click(object sender, EventArgs e)
        {
            searchField.Text = "";
            numStats.Text = "ЧИСЛО";
        }

        private void numStats_Click(object sender, EventArgs e)
        {
            searchField.Text = "ВВЕДИТЕ ИМЯ";
            numStats.Text = "";
        }

        private void numStats_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(Char.IsDigit(number) | e.KeyChar == ',' | e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void morePrmtr_CheckedChanged(object sender, EventArgs e)
        {
            if (morePrmtr.Checked == true)
            {
                lessPrmtr.Checked = false;
            }
        }

        private void lessPrmtr_CheckedChanged(object sender, EventArgs e)
        {
            if (lessPrmtr.Checked == true)
            {
                morePrmtr.Checked = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string xlFileName = null;

            Excel.Workbook xlWB;
            Excel.Worksheet xlSht;
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            for (int i = TeamTable.Rows.Count - 1; i >= 0; i--)
            {
                TeamTable.Rows.RemoveAt(i);
            }

            if (searchField.Text != "" & searchField.Text != "ВВЕДИТЕ ИМЯ")
            {
                string team = null;
                int breakInt = 0;
                int rowInt = -1;

                foreach (string str in teamNames)
                {
                    if (breakInt == 1) break;
                    try
                    {
                        xlFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                    + $"//Players//{teamNames_inexcel[str]}.xlsx";

                        xlWB = xlApp.Workbooks.Open(xlFileName);

                        xlSht = (Microsoft.Office.Interop.Excel.Worksheet)xlWB.Worksheets["stats"];

                        string Value1 = searchField.Text;

                        for (int n = 2; n < 20; n++)
                        {
                            try
                            {
                                string Value2 = xlSht.Range[$"B{n.ToString()}"].Value2.ToString();
                                if (Value1 == Value2)
                                {
                                    team = str;
                                    rowInt = n;
                                    breakInt = 1;
                                    break;
                                }
                            }
                            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { break; }
                        }
                        xlWB.Close();
                        xlApp.Quit();
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        continue;
                    }
                }

                GetSearchRow(rowInt, team);
            }


            if (numStats.Text != "" & numStats.Text != "ЧИСЛО")
            {
                string stolb = statsList[statsComboBox.SelectedItem.ToString()];
                double Value1 = Convert.ToDouble(numStats.Text);

                Excel.Workbook xlWB2;
                Excel.Worksheet xlSht2;

                File.Delete(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                + "//Players//stats_search_table.xlsx");
                object misValue = System.Reflection.Missing.Value;
                xlWB2 = xlApp.Workbooks.Add(misValue);
                xlWB2.SaveAs(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                + "\\Players\\stats_search_table.xlsx");
                xlWB2 = xlApp.Workbooks.Open(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            + "//Players//stats_search_table.xlsx");

                if (morePrmtr.Checked == true)
                {
                    int counter = 2;

                    foreach (string str in teamNames)
                    {
                        xlFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                    + $"//Players//{teamNames_inexcel[str]}.xlsx";

                        xlWB = xlApp.Workbooks.Open(xlFileName);

                        xlSht = (Excel.Worksheet)xlWB.Worksheets["stats"];
                        xlSht2 = (Excel.Worksheet)xlWB2.Worksheets[1];

                        foreach (string strRow in statsList.Keys)
                        {
                            xlSht2.Cells[1, statsList[strRow]] = strRow;
                        }

                        for (int n = 2; n < xlSht2.Rows.Count - 1; n++)
                        {
                            try
                            {
                                double Value2 = Convert.ToDouble(xlSht.Range[$"{stolb}{n.ToString()}"].Value2.ToString());
                                if (Value2 >= Value1)
                                {
                                    foreach (string strRow in statsList.Values)
                                    {
                                        xlSht2.Cells[counter, strRow] = xlSht.Cells[n, strRow];
                                    }
                                    counter += 1;
                                }
                            }
                            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { break; }
                        }

                        xlWB.Close();
                    }
                }

                if (lessPrmtr.Checked == true)
                {
                    int counter = 2;

                    foreach (string str in teamNames)
                    {
                        xlFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                    + $"//Players//{teamNames_inexcel[str]}.xlsx";

                        xlWB = xlApp.Workbooks.Open(xlFileName);
                        xlWB2 = xlApp.Workbooks.Open(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                    + "//Players//stats_search_table.xlsx");

                        xlSht = (Excel.Worksheet)xlWB.Worksheets["stats"];
                        xlSht2 = (Excel.Worksheet)xlWB2.Worksheets[1];

                        foreach (string strRow in statsList.Keys)
                        {
                            xlSht2.Cells[1, statsList[strRow]] = strRow;
                        }

                        for (int n = 2; n < xlSht2.Rows.Count-1; n++)
                        {
                            try
                            {
                                double Value2 = Convert.ToDouble(xlSht.Range[$"{stolb}{n.ToString()}"].Value2.ToString());
                                if (Value2 <= Value1)
                                {
                                    foreach (string strRow in statsList.Values)
                                    {
                                        xlSht2.Cells[counter, strRow] = xlSht.Cells[n, strRow];
                                    }
                                    counter += 1;
                                }
                            }
                            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { break; }
                        }

                        xlWB.Close();
                    }
                }
                xlWB2.Close(true);
                xlApp.Quit();

                OpenTeamTable(System.IO.Path.GetDirectoryName(Application.ExecutablePath)
                                + "//Players//stats_search_table.xlsx");
                TeamTable.DataSource = thisTable;
            }
        }
    }
}
