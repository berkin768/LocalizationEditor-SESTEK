namespace LocalizationEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.workingDirectoryLabel = new System.Windows.Forms.Label();
            this.workingDirectory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchBox = new LocalizationEditor.UserControl.PlaceHolderTextBox();
            this.crossButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.emptyLabel = new System.Windows.Forms.Label();
            this.emptyComboBox = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.duplicatedLabel = new System.Windows.Forms.Label();
            this.duplicatedComboBox = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.addNewLineButton = new System.Windows.Forms.Button();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // workingDirectoryLabel
            // 
            this.workingDirectoryLabel.AutoSize = true;
            this.workingDirectoryLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.workingDirectoryLabel.Location = new System.Drawing.Point(20, 46);
            this.workingDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workingDirectoryLabel.Name = "workingDirectoryLabel";
            this.workingDirectoryLabel.Size = new System.Drawing.Size(173, 24);
            this.workingDirectoryLabel.TabIndex = 0;
            this.workingDirectoryLabel.Text = "Working Directory :";
            // 
            // workingDirectory
            // 
            this.workingDirectory.AccessibleName = "workingDirectory";
            this.workingDirectory.AutoSize = true;
            this.workingDirectory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.workingDirectory.Location = new System.Drawing.Point(219, 46);
            this.workingDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workingDirectory.Name = "workingDirectory";
            this.workingDirectory.Size = new System.Drawing.Size(0, 24);
            this.workingDirectory.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.workingDirectoryLabel);
            this.panel1.Controls.Add(this.workingDirectory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 84);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.searchBox);
            this.panel4.Controls.Add(this.crossButton);
            this.panel4.Location = new System.Drawing.Point(1284, 39);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 41);
            this.panel4.TabIndex = 7;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(15, 6);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceHolderText = "";
            this.searchBox.Size = new System.Drawing.Size(243, 27);
            this.searchBox.TabIndex = 6;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // crossButton
            // 
            this.crossButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.crossButton.FlatAppearance.BorderSize = 0;
            this.crossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crossButton.Image = ((System.Drawing.Image)(resources.GetObject("crossButton.Image")));
            this.crossButton.Location = new System.Drawing.Point(257, 6);
            this.crossButton.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.crossButton.Name = "crossButton";
            this.crossButton.Size = new System.Drawing.Size(33, 28);
            this.crossButton.TabIndex = 5;
            this.crossButton.UseVisualStyleBackColor = true;
            this.crossButton.Click += new System.EventHandler(this.crossButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.conditionLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 869);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1600, 98);
            this.panel2.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.emptyLabel);
            this.panel7.Controls.Add(this.emptyComboBox);
            this.panel7.Location = new System.Drawing.Point(189, 8);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(169, 82);
            this.panel7.TabIndex = 7;
            // 
            // emptyLabel
            // 
            this.emptyLabel.AllowDrop = true;
            this.emptyLabel.AutoSize = true;
            this.emptyLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emptyLabel.ForeColor = System.Drawing.Color.Red;
            this.emptyLabel.Location = new System.Drawing.Point(4, 23);
            this.emptyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(0, 24);
            this.emptyLabel.TabIndex = 4;
            // 
            // emptyComboBox
            // 
            this.emptyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emptyComboBox.FormattingEnabled = true;
            this.emptyComboBox.Location = new System.Drawing.Point(4, 53);
            this.emptyComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.emptyComboBox.Name = "emptyComboBox";
            this.emptyComboBox.Size = new System.Drawing.Size(160, 24);
            this.emptyComboBox.TabIndex = 3;
            this.emptyComboBox.SelectedIndexChanged += new System.EventHandler(this.emptyComboBox_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.duplicatedLabel);
            this.panel6.Controls.Add(this.duplicatedComboBox);
            this.panel6.Location = new System.Drawing.Point(12, 8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(171, 82);
            this.panel6.TabIndex = 6;
            // 
            // duplicatedLabel
            // 
            this.duplicatedLabel.AllowDrop = true;
            this.duplicatedLabel.AutoSize = true;
            this.duplicatedLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.duplicatedLabel.ForeColor = System.Drawing.Color.Red;
            this.duplicatedLabel.Location = new System.Drawing.Point(8, 26);
            this.duplicatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.duplicatedLabel.Name = "duplicatedLabel";
            this.duplicatedLabel.Size = new System.Drawing.Size(0, 24);
            this.duplicatedLabel.TabIndex = 3;
            // 
            // duplicatedComboBox
            // 
            this.duplicatedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.duplicatedComboBox.FormattingEnabled = true;
            this.duplicatedComboBox.Location = new System.Drawing.Point(7, 54);
            this.duplicatedComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.duplicatedComboBox.Name = "duplicatedComboBox";
            this.duplicatedComboBox.Size = new System.Drawing.Size(160, 24);
            this.duplicatedComboBox.TabIndex = 2;
            this.duplicatedComboBox.SelectedIndexChanged += new System.EventHandler(this.duplicatedComboBox_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.saveButton);
            this.panel5.Controls.Add(this.addNewLineButton);
            this.panel5.Location = new System.Drawing.Point(1065, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(519, 90);
            this.panel5.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.Location = new System.Drawing.Point(264, 10);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(252, 76);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addNewLineButton
            // 
            this.addNewLineButton.Location = new System.Drawing.Point(4, 10);
            this.addNewLineButton.Margin = new System.Windows.Forms.Padding(4);
            this.addNewLineButton.Name = "addNewLineButton";
            this.addNewLineButton.Size = new System.Drawing.Size(252, 76);
            this.addNewLineButton.TabIndex = 4;
            this.addNewLineButton.Text = "New Line";
            this.addNewLineButton.UseVisualStyleBackColor = true;
            this.addNewLineButton.Click += new System.EventHandler(this.addNewLineButton_Click);
            // 
            // conditionLabel
            // 
            this.conditionLabel.AutoSize = true;
            this.conditionLabel.Location = new System.Drawing.Point(730, 44);
            this.conditionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(0, 17);
            this.conditionLabel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1600, 785);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Size = new System.Drawing.Size(1600, 785);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 967);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "LocalizationEditor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label workingDirectoryLabel;
        private System.Windows.Forms.Label workingDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label duplicatedLabel;
        private System.Windows.Forms.ComboBox duplicatedComboBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button crossButton;
        private UserControl.PlaceHolderTextBox searchBox;
        private System.Windows.Forms.Button addNewLineButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label emptyLabel;
        private System.Windows.Forms.ComboBox emptyComboBox;
        private System.Windows.Forms.Panel panel6;
    }
}

