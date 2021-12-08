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

namespace TestCPy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] columnNames = new string[]{"Rk", "Unnamed: 1",  "Age", "G", "GS", "MP",  "FG", "FGA", "FG%", "3P", "3PA", "3P%", "2P",  "2PA", "2P%", "eFG%", "FT",
                                                "FTA", "FT%", "ORB", "DRB", "TRB", "AST", "STL", "BLK", "TOV", "PF", "PTS"};
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[columnNames.Length];
            for (int i = 0; i < columnNames.Length; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
                column[i].HeaderText = columnNames[i];
                column[i].Name = columnNames[i];
                column[i].Width = 40;
            }

            TeamTable.Columns.AddRange(column);
            TeamTable.Columns[1].Width = 90;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo()
            {
                FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "//dist//BasketabllParser.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(procInfo);
        }
    }
}
