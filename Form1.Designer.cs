namespace AnnWorkTemplate
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GenerateWordsButton = new System.Windows.Forms.Button();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PathFileTextBox = new System.Windows.Forms.TextBox();
            this.ReadExcelButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DatabaseNames = new System.Windows.Forms.DataGridView();
            this.MergeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseNames)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateWordsButton
            // 
            this.GenerateWordsButton.Location = new System.Drawing.Point(27, 168);
            this.GenerateWordsButton.Name = "GenerateWordsButton";
            this.GenerateWordsButton.Size = new System.Drawing.Size(133, 42);
            this.GenerateWordsButton.TabIndex = 3;
            this.GenerateWordsButton.Text = "Сформировать файлы";
            this.GenerateWordsButton.UseVisualStyleBackColor = true;
            this.GenerateWordsButton.Click += new System.EventHandler(this.GenerateWordsButton_Click);
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(205, 103);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.NumberTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Начальный номер \r\nудостоверения";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PathFileTextBox
            // 
            this.PathFileTextBox.Location = new System.Drawing.Point(205, 50);
            this.PathFileTextBox.Name = "PathFileTextBox";
            this.PathFileTextBox.ReadOnly = true;
            this.PathFileTextBox.Size = new System.Drawing.Size(200, 20);
            this.PathFileTextBox.TabIndex = 7;
            this.PathFileTextBox.TabStop = false;
            // 
            // ReadExcelButton
            // 
            this.ReadExcelButton.Location = new System.Drawing.Point(27, 45);
            this.ReadExcelButton.Name = "ReadExcelButton";
            this.ReadExcelButton.Size = new System.Drawing.Size(120, 29);
            this.ReadExcelButton.TabIndex = 1;
            this.ReadExcelButton.Text = "Выбрать файл";
            this.ReadExcelButton.UseVisualStyleBackColor = true;
            this.ReadExcelButton.Click += new System.EventHandler(this.ReadExcelButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DatabaseNames
            // 
            this.DatabaseNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatabaseNames.Location = new System.Drawing.Point(448, 45);
            this.DatabaseNames.Name = "DatabaseNames";
            this.DatabaseNames.Size = new System.Drawing.Size(301, 165);
            this.DatabaseNames.TabIndex = 6;
            this.DatabaseNames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabaseNames_CellContentClick);
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(272, 168);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(133, 42);
            this.MergeButton.TabIndex = 4;
            this.MergeButton.Text = "Объединить файлы";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.HelpToolStripMenuItem.Text = "Помощь";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 245);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.DatabaseNames);
            this.Controls.Add(this.ReadExcelButton);
            this.Controls.Add(this.PathFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.GenerateWordsButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать удостоверений";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseNames)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GenerateWordsButton;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathFileTextBox;
        private System.Windows.Forms.Button ReadExcelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView DatabaseNames;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
    }
}

