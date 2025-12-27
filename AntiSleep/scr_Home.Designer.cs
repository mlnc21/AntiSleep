namespace AntiSleep
{
    partial class scr_Home
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scr_Home));
            btn_Activate = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            cbx_MouseMoveVisible = new CheckBox();
            notifyIcon1 = new NotifyIcon(components);
            groupBox1 = new GroupBox();
            label1 = new Label();
            ntxt_intervall = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ntxt_intervall).BeginInit();
            SuspendLayout();
            // 
            // btn_Activate
            // 
            btn_Activate.Location = new Point(22, 159);
            btn_Activate.Name = "btn_Activate";
            btn_Activate.Size = new Size(282, 35);
            btn_Activate.TabIndex = 0;
            btn_Activate.Text = "Aktivieren";
            btn_Activate.UseVisualStyleBackColor = true;
            btn_Activate.Click += btn_Activate_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // cbx_MouseMoveVisible
            // 
            cbx_MouseMoveVisible.AutoSize = true;
            cbx_MouseMoveVisible.Location = new Point(20, 88);
            cbx_MouseMoveVisible.Name = "cbx_MouseMoveVisible";
            cbx_MouseMoveVisible.Size = new Size(143, 19);
            cbx_MouseMoveVisible.TabIndex = 1;
            cbx_MouseMoveVisible.Text = "Visible Mouse moving";
            cbx_MouseMoveVisible.UseVisualStyleBackColor = true;
            cbx_MouseMoveVisible.CheckedChanged += cbx_MouseMoveVisible_CheckedChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbx_MouseMoveVisible);
            groupBox1.Controls.Add(ntxt_intervall);
            groupBox1.Location = new Point(22, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(282, 130);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 33);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 5;
            label1.Text = "Intervall:";
            // 
            // ntxt_intervall
            // 
            ntxt_intervall.Location = new Point(20, 55);
            ntxt_intervall.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            ntxt_intervall.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            ntxt_intervall.Name = "ntxt_intervall";
            ntxt_intervall.Size = new Size(242, 23);
            ntxt_intervall.TabIndex = 4;
            ntxt_intervall.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            ntxt_intervall.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // scr_Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(326, 212);
            Controls.Add(groupBox1);
            Controls.Add(btn_Activate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "scr_Home";
            ShowInTaskbar = false;
            Text = "AntiSleep";
            TopMost = true;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ntxt_intervall).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Activate;
        private System.Windows.Forms.Timer timer1;
        private CheckBox cbx_MouseMoveVisible;
        private NotifyIcon notifyIcon1;
        private GroupBox groupBox1;
        private Label label1;
        private NumericUpDown ntxt_intervall;
    }
}
