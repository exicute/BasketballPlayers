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
        Dictionary<string, string> teamNames_inexcel = new Dictionary<string, string>();

        DataTable thisTable;

        public MainForm()
        {
            InitializeComponent();

            foreach (string str in teamNames)
            {
                string tableName;
                string[] devidedStr = str.Split();
                if (devidedStr.Length < 3) tableName = devidedStr[0] + "_" + devidedStr[1] + "__.xlsx";
                else tableName = devidedStr[0] + "_" + devidedStr[1] + "_" + devidedStr[2] + ".xlsx";
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
            //string[] columnNames = new string[]{"Rk", "Unnamed: 1",  "Age", "G", "GS", "MP",  "FG", "FGA", "FG%", "3P", "3PA", "3P%", "2P",  "2PA", "2P%", "eFG%", "FT",
            //                                    "FTA", "FT%", "ORB", "DRB", "TRB", "AST", "STL", "BLK", "TOV", "PF", "PTS"};
            //DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[columnNames.Length];
            //for (int i = 0; i < columnNames.Length; i++)
            //{
            //    column[i] = new DataGridViewTextBoxColumn();
            //    column[i].HeaderText = columnNames[i];
            //    column[i].Name = columnNames[i];
            //    column[i].Width = 40;
            //}

            //TeamTable.Columns.AddRange(column);
            //TeamTable.Columns[1].Width = 90;
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
                            + $"//Players//{teamNames_inexcel[Convert.ToString(TeamList.SelectedItem)]}");
                TeamTable.DataSource = thisTable; 
            }
            catch(System.IO.IOException)
            {
            }
        }
    }
}
