using System.Runtime.InteropServices;
using System.Globalization;
using AntiSleep.Localization;
using AntiSleep.Settings;

namespace AntiSleep
{
    public partial class scr_Home : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;

        private AppSettings settings;
        public bool isActive = false;
        public bool mouseMoveVisible = true;
        public int moveInterval = 1000; // Zeitintervall in Millisekunden
        public int moveDistance = 1; // Entfernung in Pixel
        public int moveDirection = 1; // Bewegungsrichtung
        
        public scr_Home()
        {
            InitializeComponent();
            // Einstellungen laden
            settings = AppSettings.Load();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gespeicherte Einstellungen anwenden
            mouseMoveVisible = settings.MouseMoveVisible;
            moveInterval = settings.MoveInterval;
            moveDistance = settings.MoveDistance;

            // Initialisiere UI-Texte
            UpdateUITexts();
            
            // Fluent UI Styling
            ApplyFluentUIStyle();
            
            cbx_MouseMoveVisible.Checked = mouseMoveVisible;
            ntxt_intervall.Value = moveInterval;
            timer1.Interval = moveInterval;

            // NotifyIcon konfigurieren
            notifyIcon1.Icon = this.Icon ?? SystemIcons.Application;
            notifyIcon1.Text = LocalizationManager.Get("StatusInactive");
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            notifyIcon1.BalloonTipClicked += NotifyIcon1_BalloonTipClicked;

            // Kontextmenü erstellen
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(LocalizationManager.Get("Open"), null, (s, e) => ShowForm());
            contextMenu.Items.Add(LocalizationManager.Get("ToggleActivation"), null, (s, e) => btn_Activate_Click(s, e));
            contextMenu.Items.Add("-");
            contextMenu.Items.Add(LocalizationManager.Get("Exit"), null, (s, e) => Application.Exit());
            notifyIcon1.ContextMenuStrip = contextMenu;

            notifyIcon1.ShowBalloonTip(3000, "AntiSleep", LocalizationManager.Get("ProgramStarted"), ToolTipIcon.Info);
        }

        private void UpdateUITexts()
        {
            // Update alle UI-Texte mit lokalisierten Strings
            btn_Activate.Text = LocalizationManager.Get("Activate");
            cbx_MouseMoveVisible.Text = LocalizationManager.Get("VisibleMouseMovement");
            groupBox1.Text = LocalizationManager.Get("Settings");
            label1.Text = LocalizationManager.Get("Interval");
        }

        private void ApplyFluentUIStyle()
        {
            // Fluent UI Farben
            this.BackColor = Color.FromArgb(243, 243, 243);
            
            // GroupBox Styling
            groupBox1.BackColor = Color.White;
            groupBox1.ForeColor = Color.FromArgb(32, 32, 32);
            
            // Button Styling - Fluent UI Accent Color
            btn_Activate.BackColor = Color.FromArgb(0, 120, 212);
            btn_Activate.ForeColor = Color.White;
            btn_Activate.FlatStyle = FlatStyle.Flat;
            btn_Activate.FlatAppearance.BorderSize = 0;
            btn_Activate.Cursor = Cursors.Hand;
            
            // NumericUpDown Styling
            ntxt_intervall.BackColor = Color.White;
            ntxt_intervall.ForeColor = Color.FromArgb(32, 32, 32);
            
            // CheckBox Styling
            cbx_MouseMoveVisible.ForeColor = Color.FromArgb(32, 32, 32);
        }

        private void btn_Activate_Click(object sender, EventArgs e)
        {
            if (!isActive)
            {
                btn_Activate.Text = LocalizationManager.Get("Deactivate");
                btn_Activate.BackColor = Color.FromArgb(197, 15, 31); // Fluent UI Red
                isActive = true;
                SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED);
                if (mouseMoveVisible) { timer1.Start(); }
                notifyIcon1.Text = LocalizationManager.Get("StatusActive");
                notifyIcon1.ShowBalloonTip(2000, "AntiSleep", LocalizationManager.Get("ModeActivated"), ToolTipIcon.Info);
            }
            else
            {
                btn_Activate.Text = LocalizationManager.Get("Activate");
                btn_Activate.BackColor = Color.FromArgb(0, 120, 212); // Fluent UI Blue
                timer1.Stop();
                isActive = false;
                SetThreadExecutionState(ES_CONTINUOUS);
                notifyIcon1.Text = LocalizationManager.Get("StatusInactive");
                notifyIcon1.ShowBalloonTip(2000, "AntiSleep", LocalizationManager.Get("ModeDeactivated"), ToolTipIcon.Info);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                if (moveDirection == 1)
                {
                    Cursor.Position = new Point(Cursor.Position.X - moveDistance, Cursor.Position.Y - moveDistance);
                    moveDirection = 2;
                }
                else if (moveDirection == 2)
                {
                    Cursor.Position = new Point(Cursor.Position.X + moveDistance, Cursor.Position.Y + moveDistance);
                    moveDirection = 1;
                }
            }
        }

        private void cbx_MouseMoveVisible_CheckedChanged(object sender, EventArgs e)
        {
            mouseMoveVisible = cbx_MouseMoveVisible.Checked;

            // Einstellung speichern
            settings.MouseMoveVisible = mouseMoveVisible;
            settings.Save();

            if (isActive)
            {
                if (mouseMoveVisible)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void NotifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.ShowBalloonTip(2000, "AntiSleep", LocalizationManager.Get("ProgramInBackground"), ToolTipIcon.Info);
            }
            base.OnFormClosing(e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            moveInterval = (int)ntxt_intervall.Value;
            timer1.Interval = moveInterval;

            // Einstellung speichern
            settings.MoveInterval = moveInterval;
            settings.Save();
        }
    }
}
