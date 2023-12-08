namespace VKRFORM
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            saveFileDialog1 = new SaveFileDialog();
            toolStrip1 = new ToolStrip();
            DropDownButton_File = new ToolStripDropDownButton();
            downloadFile = new ToolStripMenuItem();
            Download_RM = new ToolStripMenuItem();
            Download_TableSPP = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            Save_TableSPP = new ToolStripMenuItem();
            Save_calculationResults = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            DropDownButton_Calculation = new ToolStripDropDownButton();
            StartCalculation = new ToolStripMenuItem();
            StopSalculation = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            DropDownButton_Open = new ToolStripDropDownButton();
            Open_tableSPP = new ToolStripMenuItem();
            Open_ResultsCuculation = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            DropDownButton_Help = new ToolStripDropDownButton();
            aboutProgram = new ToolStripMenuItem();
            userGuide = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage_tableSPP = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage_resultsCalculation = new TabPage();
            openFileDialog1 = new OpenFileDialog();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage_tableSPP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { DropDownButton_File, toolStripSeparator1, DropDownButton_Calculation, toolStripSeparator2, DropDownButton_Open, toolStripSeparator3, DropDownButton_Help });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1132, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // DropDownButton_File
            // 
            DropDownButton_File.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DropDownButton_File.DropDownItems.AddRange(new ToolStripItem[] { downloadFile, saveFile, Exit });
            DropDownButton_File.Image = (Image)resources.GetObject("DropDownButton_File.Image");
            DropDownButton_File.ImageTransparentColor = Color.Magenta;
            DropDownButton_File.Name = "DropDownButton_File";
            DropDownButton_File.Size = new Size(70, 24);
            DropDownButton_File.Text = "Файлы";
            // 
            // downloadFile
            // 
            downloadFile.DropDownItems.AddRange(new ToolStripItem[] { Download_RM, Download_TableSPP });
            downloadFile.Name = "downloadFile";
            downloadFile.Size = new Size(224, 26);
            downloadFile.Text = "Загрузить";
            // 
            // Download_RM
            // 
            Download_RM.Name = "Download_RM";
            Download_RM.Size = new Size(224, 26);
            Download_RM.Text = "Расчётную модель";
            // 
            // Download_TableSPP
            // 
            Download_TableSPP.Name = "Download_TableSPP";
            Download_TableSPP.Size = new Size(224, 26);
            Download_TableSPP.Text = "Таблицу СЭС";
            Download_TableSPP.Click += Download_TableSPP_Click;
            // 
            // saveFile
            // 
            saveFile.DropDownItems.AddRange(new ToolStripItem[] { Save_TableSPP, Save_calculationResults });
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(224, 26);
            saveFile.Text = "Сохранить";
            // 
            // Save_TableSPP
            // 
            Save_TableSPP.Name = "Save_TableSPP";
            Save_TableSPP.Size = new Size(227, 26);
            Save_TableSPP.Text = "Таблицу СЭС";
            Save_TableSPP.Click += Save_TableSPP_Click;
            // 
            // Save_calculationResults
            // 
            Save_calculationResults.Name = "Save_calculationResults";
            Save_calculationResults.Size = new Size(227, 26);
            Save_calculationResults.Text = "Результаты расчёта";
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(224, 26);
            Exit.Text = "Выход";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // DropDownButton_Calculation
            // 
            DropDownButton_Calculation.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DropDownButton_Calculation.DropDownItems.AddRange(new ToolStripItem[] { StartCalculation, StopSalculation });
            DropDownButton_Calculation.Image = (Image)resources.GetObject("DropDownButton_Calculation.Image");
            DropDownButton_Calculation.ImageTransparentColor = Color.Magenta;
            DropDownButton_Calculation.Name = "DropDownButton_Calculation";
            DropDownButton_Calculation.Size = new Size(79, 24);
            DropDownButton_Calculation.Text = "Расчёты";
            // 
            // StartCalculation
            // 
            StartCalculation.Name = "StartCalculation";
            StartCalculation.Size = new Size(223, 26);
            StartCalculation.Text = "Начать расчёт";
            // 
            // StopSalculation
            // 
            StopSalculation.Name = "StopSalculation";
            StopSalculation.Size = new Size(223, 26);
            StopSalculation.Text = "Остановить расчёт";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // DropDownButton_Open
            // 
            DropDownButton_Open.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DropDownButton_Open.DropDownItems.AddRange(new ToolStripItem[] { Open_tableSPP, Open_ResultsCuculation });
            DropDownButton_Open.Image = (Image)resources.GetObject("DropDownButton_Open.Image");
            DropDownButton_Open.ImageTransparentColor = Color.Magenta;
            DropDownButton_Open.Name = "DropDownButton_Open";
            DropDownButton_Open.Size = new Size(81, 24);
            DropDownButton_Open.Text = "Открыть";
            // 
            // Open_tableSPP
            // 
            Open_tableSPP.Name = "Open_tableSPP";
            Open_tableSPP.Size = new Size(227, 26);
            Open_tableSPP.Text = "Таблицу СЭС";
            // 
            // Open_ResultsCuculation
            // 
            Open_ResultsCuculation.Name = "Open_ResultsCuculation";
            Open_ResultsCuculation.Size = new Size(227, 26);
            Open_ResultsCuculation.Text = "Результаты расчёта";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // DropDownButton_Help
            // 
            DropDownButton_Help.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DropDownButton_Help.DropDownItems.AddRange(new ToolStripItem[] { aboutProgram, userGuide });
            DropDownButton_Help.Image = (Image)resources.GetObject("DropDownButton_Help.Image");
            DropDownButton_Help.ImageTransparentColor = Color.Magenta;
            DropDownButton_Help.Name = "DropDownButton_Help";
            DropDownButton_Help.Size = new Size(83, 24);
            DropDownButton_Help.Text = "Помощь";
            // 
            // aboutProgram
            // 
            aboutProgram.Name = "aboutProgram";
            aboutProgram.Size = new Size(278, 26);
            aboutProgram.Text = "О программе";
            // 
            // userGuide
            // 
            userGuide.Name = "userGuide";
            userGuide.Size = new Size(278, 26);
            userGuide.Text = "Руководство пользователя";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_tableSPP);
            tabControl1.Controls.Add(tabPage_resultsCalculation);
            tabControl1.Location = new Point(0, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1132, 432);
            tabControl1.TabIndex = 1;
            // 
            // tabPage_tableSPP
            // 
            tabPage_tableSPP.Controls.Add(dataGridView1);
            tabPage_tableSPP.Location = new Point(4, 29);
            tabPage_tableSPP.Name = "tabPage_tableSPP";
            tabPage_tableSPP.Padding = new Padding(3);
            tabPage_tableSPP.Size = new Size(1124, 399);
            tabPage_tableSPP.TabIndex = 0;
            tabPage_tableSPP.Text = "Таблица СЭС";
            tabPage_tableSPP.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1124, 399);
            dataGridView1.TabIndex = 0;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // tabPage_resultsCalculation
            // 
            tabPage_resultsCalculation.Location = new Point(4, 29);
            tabPage_resultsCalculation.Name = "tabPage_resultsCalculation";
            tabPage_resultsCalculation.Padding = new Padding(3);
            tabPage_resultsCalculation.Size = new Size(1124, 399);
            tabPage_resultsCalculation.TabIndex = 1;
            tabPage_resultsCalculation.Text = "Результаты расчёта";
            tabPage_resultsCalculation.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1132, 462);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "MainForm";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage_tableSPP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton DropDownButton_File;
        private ToolStripMenuItem downloadFile;
        private ToolStripMenuItem Download_RM;
        private ToolStripMenuItem Download_TableSPP;
        private ToolStripMenuItem saveFile;
        private ToolStripMenuItem Save_TableSPP;
        private ToolStripMenuItem Save_calculationResults;
        private ToolStripMenuItem Exit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton DropDownButton_Calculation;
        private ToolStripMenuItem StartCalculation;
        private ToolStripMenuItem StopSalculation;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton DropDownButton_Open;
        private ToolStripMenuItem Open_tableSPP;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripDropDownButton DropDownButton_Help;
        private ToolStripMenuItem aboutProgram;
        private ToolStripMenuItem userGuide;
        private ToolStripMenuItem Open_ResultsCuculation;
        private TabControl tabControl1;
        private TabPage tabPage_tableSPP;
        private TabPage tabPage_resultsCalculation;
        private DataGridView dataGridView1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}