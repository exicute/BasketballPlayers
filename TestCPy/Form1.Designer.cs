
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TeamList = new System.Windows.Forms.ComboBox();
            this.TeamTable = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TeamTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamList
            // 
            this.TeamList.BackColor = System.Drawing.Color.LightCoral;
            this.TeamList.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamList.ForeColor = System.Drawing.SystemColors.Control;
            this.TeamList.FormattingEnabled = true;
            this.TeamList.Location = new System.Drawing.Point(24, 28);
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
            this.TeamTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.TeamTable.Location = new System.Drawing.Point(12, 85);
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
            this.updateButton.Location = new System.Drawing.Point(1217, 21);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(98, 45);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1310, 62);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.SteelBlue;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchButton.Location = new System.Drawing.Point(1035, 21);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(176, 45);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1332, 646);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.TeamList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TeamTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Игроки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TeamTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TeamList;
        private System.Windows.Forms.DataGridView TeamTable;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button searchButton;
    }
}

