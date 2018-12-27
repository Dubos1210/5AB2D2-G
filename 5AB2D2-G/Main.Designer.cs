namespace _5AB2D2_G
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.serialGroup = new System.Windows.Forms.GroupBox();
            this.serialRenew = new System.Windows.Forms.Button();
            this.serialBaud = new System.Windows.Forms.NumericUpDown();
            this.serialBtn = new System.Windows.Forms.Button();
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.blGroup = new System.Windows.Forms.GroupBox();
            this.DTRchk = new System.Windows.Forms.CheckBox();
            this.fireBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.serialGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialBaud)).BeginInit();
            this.blGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 124);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(287, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // serial
            // 
            this.serial.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serial_ErrorReceived);
            // 
            // tableLayout
            // 
            this.tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.18587F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.81413F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Controls.Add(this.serialGroup, 0, 0);
            this.tableLayout.Controls.Add(this.blGroup, 1, 0);
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Size = new System.Drawing.Size(286, 123);
            this.tableLayout.TabIndex = 1;
            // 
            // serialGroup
            // 
            this.serialGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialGroup.Controls.Add(this.serialRenew);
            this.serialGroup.Controls.Add(this.serialBaud);
            this.serialGroup.Controls.Add(this.serialBtn);
            this.serialGroup.Controls.Add(this.serialPorts);
            this.serialGroup.Location = new System.Drawing.Point(3, 3);
            this.serialGroup.Name = "serialGroup";
            this.serialGroup.Size = new System.Drawing.Size(137, 117);
            this.serialGroup.TabIndex = 2;
            this.serialGroup.TabStop = false;
            this.serialGroup.Text = "Порт";
            // 
            // serialRenew
            // 
            this.serialRenew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialRenew.Location = new System.Drawing.Point(93, 17);
            this.serialRenew.Name = "serialRenew";
            this.serialRenew.Size = new System.Drawing.Size(38, 23);
            this.serialRenew.TabIndex = 3;
            this.serialRenew.Text = "R";
            this.serialRenew.UseVisualStyleBackColor = true;
            this.serialRenew.Click += new System.EventHandler(this.serialRenew_Click);
            // 
            // serialBaud
            // 
            this.serialBaud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialBaud.Location = new System.Drawing.Point(11, 46);
            this.serialBaud.Maximum = new decimal(new int[] {
            256000,
            0,
            0,
            0});
            this.serialBaud.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.serialBaud.Name = "serialBaud";
            this.serialBaud.Size = new System.Drawing.Size(120, 20);
            this.serialBaud.TabIndex = 2;
            this.serialBaud.Value = new decimal(new int[] {
            38400,
            0,
            0,
            0});
            // 
            // serialBtn
            // 
            this.serialBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialBtn.Location = new System.Drawing.Point(11, 72);
            this.serialBtn.Name = "serialBtn";
            this.serialBtn.Size = new System.Drawing.Size(121, 23);
            this.serialBtn.TabIndex = 1;
            this.serialBtn.Text = "Тест";
            this.serialBtn.UseVisualStyleBackColor = true;
            this.serialBtn.Click += new System.EventHandler(this.serialBtn_Click);
            // 
            // serialPorts
            // 
            this.serialPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(10, 19);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(77, 21);
            this.serialPorts.TabIndex = 0;
            // 
            // blGroup
            // 
            this.blGroup.Controls.Add(this.DTRchk);
            this.blGroup.Controls.Add(this.fireBtn);
            this.blGroup.Controls.Add(this.openBtn);
            this.blGroup.Location = new System.Drawing.Point(146, 3);
            this.blGroup.Name = "blGroup";
            this.blGroup.Size = new System.Drawing.Size(137, 117);
            this.blGroup.TabIndex = 3;
            this.blGroup.TabStop = false;
            this.blGroup.Text = "Прошивка";
            // 
            // DTRchk
            // 
            this.DTRchk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTRchk.AutoSize = true;
            this.DTRchk.Enabled = false;
            this.DTRchk.Location = new System.Drawing.Point(7, 48);
            this.DTRchk.Name = "DTRchk";
            this.DTRchk.Size = new System.Drawing.Size(49, 17);
            this.DTRchk.TabIndex = 2;
            this.DTRchk.Text = "DTR";
            this.DTRchk.UseVisualStyleBackColor = true;
            // 
            // fireBtn
            // 
            this.fireBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fireBtn.Enabled = false;
            this.fireBtn.Location = new System.Drawing.Point(6, 72);
            this.fireBtn.Name = "fireBtn";
            this.fireBtn.Size = new System.Drawing.Size(125, 23);
            this.fireBtn.TabIndex = 1;
            this.fireBtn.Text = "FIRE!";
            this.fireBtn.UseVisualStyleBackColor = true;
            this.fireBtn.Click += new System.EventHandler(this.fireBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Location = new System.Drawing.Point(6, 19);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(128, 23);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "Открыть файл";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Binary files|*.bin|All files|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 146);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(303, 185);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(303, 185);
            this.Name = "MainForm";
            this.Text = "5AB2D2-G";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayout.ResumeLayout(false);
            this.serialGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serialBaud)).EndInit();
            this.blGroup.ResumeLayout(false);
            this.blGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.GroupBox serialGroup;
        private System.Windows.Forms.NumericUpDown serialBaud;
        private System.Windows.Forms.Button serialBtn;
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.GroupBox blGroup;
        private System.Windows.Forms.Button fireBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.CheckBox DTRchk;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button serialRenew;
    }
}

