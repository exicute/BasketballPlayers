
namespace TestCPy
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TeamList = new System.Windows.Forms.ComboBox();
            this.TeamTable = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            this.teamPicture = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchField = new System.Windows.Forms.TextBox();
            this.statsComboBox = new System.Windows.Forms.ComboBox();
            this.numStats = new System.Windows.Forms.TextBox();
            this.morePrmtr = new System.Windows.Forms.CheckBox();
            this.lessPrmtr = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TeamTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamList
            // 
            this.TeamList.BackColor = System.Drawing.Color.LightCoral;
            this.TeamList.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamList.ForeColor = System.Drawing.SystemColors.Control;
            this.TeamList.FormattingEnabled = true;
            this.TeamList.Location = new System.Drawing.Point(23, 21);
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(388, 30);
            this.TeamList.TabIndex = 0;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // TeamTable
            // 
            this.TeamTable.AllowUserToAddRows = false;
            this.TeamTable.AllowUserToDeleteRows = false;
            this.TeamTable.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.TeamTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TeamTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TeamTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamTable.EnableHeadersVisualStyles = false;
            this.TeamTable.Location = new System.Drawing.Point(12, 111);
            this.TeamTable.Name = "TeamTable";
            this.TeamTable.ReadOnly = true;
            this.TeamTable.RowHeadersWidth = 51;
            this.TeamTable.RowTemplate.Height = 29;
            this.TeamTable.Size = new System.Drawing.Size(1310, 549);
            this.TeamTable.TabIndex = 1;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.SteelBlue;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.updateButton.Location = new System.Drawing.Point(23, 54);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(98, 37);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // teamPicture
            // 
            this.teamPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.teamPicture.Location = new System.Drawing.Point(12, 12);
            this.teamPicture.Name = "teamPicture";
            this.teamPicture.Size = new System.Drawing.Size(1310, 93);
            this.teamPicture.TabIndex = 3;
            this.teamPicture.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchButton.Location = new System.Drawing.Point(1214, 54);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(96, 37);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchField
            // 
            this.searchField.Font = new System.Drawing.Font("Franklin Gothic Demi", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchField.Location = new System.Drawing.Point(962, 21);
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(348, 28);
            this.searchField.TabIndex = 5;
            this.searchField.Text = "ВВЕДИТЕ ИМЯ";
            this.searchField.Click += new System.EventHandler(this.searchField_Click);
            // 
            // statsComboBox
            // 
            this.statsComboBox.FormattingEnabled = true;
            this.statsComboBox.Location = new System.Drawing.Point(740, 21);
            this.statsComboBox.Name = "statsComboBox";
            this.statsComboBox.Size = new System.Drawing.Size(118, 28);
            this.statsComboBox.TabIndex = 6;
            // 
            // numStats
            // 
            this.numStats.Font = new System.Drawing.Font("Franklin Gothic Demi", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numStats.Location = new System.Drawing.Point(864, 21);
            this.numStats.Name = "numStats";
            this.numStats.Size = new System.Drawing.Size(92, 28);
            this.numStats.TabIndex = 7;
            this.numStats.Text = "ЧИСЛО";
            this.numStats.Click += new System.EventHandler(this.numStats_Click);
            this.numStats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numStats_KeyPress);
            // 
            // morePrmtr
            // 
            this.morePrmtr.AutoSize = true;
            this.morePrmtr.BackColor = System.Drawing.Color.Transparent;
            this.morePrmtr.Checked = true;
            this.morePrmtr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.morePrmtr.ForeColor = System.Drawing.SystemColors.Control;
            this.morePrmtr.Location = new System.Drawing.Point(864, 54);
            this.morePrmtr.Name = "morePrmtr";
            this.morePrmtr.Size = new System.Drawing.Size(85, 24);
            this.morePrmtr.TabIndex = 8;
            this.morePrmtr.Text = "больше";
            this.morePrmtr.UseVisualStyleBackColor = false;
            this.morePrmtr.CheckedChanged += new System.EventHandler(this.morePrmtr_CheckedChanged);
            // 
            // lessPrmtr
            // 
            this.lessPrmtr.AutoSize = true;
            this.lessPrmtr.BackColor = System.Drawing.Color.Transparent;
            this.lessPrmtr.ForeColor = System.Drawing.SystemColors.Control;
            this.lessPrmtr.Location = new System.Drawing.Point(864, 81);
            this.lessPrmtr.Name = "lessPrmtr";
            this.lessPrmtr.Size = new System.Drawing.Size(87, 24);
            this.lessPrmtr.TabIndex = 9;
            this.lessPrmtr.Text = "меньше";
            this.lessPrmtr.UseVisualStyleBackColor = false;
            this.lessPrmtr.CheckedChanged += new System.EventHandler(this.lessPrmtr_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1332, 672);
            this.Controls.Add(this.lessPrmtr);
            this.Controls.Add(this.morePrmtr);
            this.Controls.Add(this.numStats);
            this.Controls.Add(this.statsComboBox);
            this.Controls.Add(this.searchField);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.TeamList);
            this.Controls.Add(this.teamPicture);
            this.Controls.Add(this.TeamTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Игроки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TeamTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TeamList;
        private System.Windows.Forms.DataGridView TeamTable;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.PictureBox teamPicture;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchField;
        private System.Windows.Forms.ComboBox statsComboBox;
        private System.Windows.Forms.TextBox numStats;
        private System.Windows.Forms.CheckBox morePrmtr;
        private System.Windows.Forms.CheckBox lessPrmtr;
    }
}

