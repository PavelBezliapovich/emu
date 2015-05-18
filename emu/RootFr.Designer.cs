namespace emu
{
    partial class RootFr
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootFr));
            this.label1 = new System.Windows.Forms.Label();
            this.rtProgram = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgRegisters = new System.Windows.Forms.DataGridView();
            this.lb = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stepButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPK = new System.Windows.Forms.TextBox();
            this.tbBR2 = new System.Windows.Forms.TextBox();
            this.tbBR1 = new System.Windows.Forms.TextBox();
            this.tbPP = new System.Windows.Forms.TextBox();
            this.tbEAX = new System.Windows.Forms.TextBox();
            this.tbEIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegisters)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Программа";
            // 
            // rtProgram
            // 
            this.rtProgram.Location = new System.Drawing.Point(26, 72);
            this.rtProgram.Name = "rtProgram";
            this.rtProgram.Size = new System.Drawing.Size(203, 164);
            this.rtProgram.TabIndex = 1;
            this.rtProgram.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgRegisters
            // 
            this.dgRegisters.AllowUserToAddRows = false;
            this.dgRegisters.AllowUserToDeleteRows = false;
            this.dgRegisters.AllowUserToResizeColumns = false;
            this.dgRegisters.AllowUserToResizeRows = false;
            this.dgRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRegisters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRegisters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegisters.Location = new System.Drawing.Point(26, 266);
            this.dgRegisters.Name = "dgRegisters";
            this.dgRegisters.ReadOnly = true;
            this.dgRegisters.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgRegisters.Size = new System.Drawing.Size(203, 246);
            this.dgRegisters.TabIndex = 3;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(12, 239);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(46, 13);
            this.lb.TabIndex = 5;
            this.lb.Text = "Память";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(871, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepButton,
            this.refreshButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(871, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stepButton
            // 
            this.stepButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepButton.Image = ((System.Drawing.Image)(resources.GetObject("stepButton.Image")));
            this.stepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(23, 22);
            this.stepButton.Text = "Шаг";
            this.stepButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.Text = "Сбросить";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(252, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 440);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // tbPK
            // 
            this.tbPK.Location = new System.Drawing.Point(453, 306);
            this.tbPK.Name = "tbPK";
            this.tbPK.Size = new System.Drawing.Size(100, 20);
            this.tbPK.TabIndex = 21;
            // 
            // tbBR2
            // 
            this.tbBR2.Location = new System.Drawing.Point(506, 379);
            this.tbBR2.Name = "tbBR2";
            this.tbBR2.Size = new System.Drawing.Size(48, 20);
            this.tbBR2.TabIndex = 20;
            // 
            // tbBR1
            // 
            this.tbBR1.Location = new System.Drawing.Point(421, 380);
            this.tbBR1.Name = "tbBR1";
            this.tbBR1.Size = new System.Drawing.Size(50, 20);
            this.tbBR1.TabIndex = 19;
            // 
            // tbPP
            // 
            this.tbPP.Location = new System.Drawing.Point(421, 431);
            this.tbPP.Name = "tbPP";
            this.tbPP.Size = new System.Drawing.Size(50, 20);
            this.tbPP.TabIndex = 18;
            // 
            // tbEAX
            // 
            this.tbEAX.Location = new System.Drawing.Point(280, 380);
            this.tbEAX.Name = "tbEAX";
            this.tbEAX.Size = new System.Drawing.Size(100, 20);
            this.tbEAX.TabIndex = 17;
            // 
            // tbEIP
            // 
            this.tbEIP.Location = new System.Drawing.Point(280, 264);
            this.tbEIP.Name = "tbEIP";
            this.tbEIP.Size = new System.Drawing.Size(100, 20);
            this.tbEIP.TabIndex = 16;
            // 
            // RootFr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 560);
            this.Controls.Add(this.tbPK);
            this.Controls.Add(this.tbBR2);
            this.Controls.Add(this.tbBR1);
            this.Controls.Add(this.tbPP);
            this.Controls.Add(this.tbEAX);
            this.Controls.Add(this.tbEIP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.dgRegisters);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtProgram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RootFr";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgRegisters)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtProgram;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgRegisters;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton stepButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbPK;
        private System.Windows.Forms.TextBox tbBR2;
        private System.Windows.Forms.TextBox tbBR1;
        private System.Windows.Forms.TextBox tbPP;
        private System.Windows.Forms.TextBox tbEAX;
        private System.Windows.Forms.TextBox tbEIP;
    }
}

