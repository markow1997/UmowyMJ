namespace UmowyMJ
{
    partial class UmowyMJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UmowyMJ));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.polaczenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polaczenieTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakonczProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usługaMuzycznaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usługaOświetleniowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RejestrZawartychUmowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejestrRezerwacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGlowny = new System.Windows.Forms.Panel();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polaczenieToolStripMenuItem,
            this.umowyToolStripMenuItem,
            this.RejestrZawartychUmowToolStripMenuItem,
            this.rejestrRezerwacjiToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // polaczenieToolStripMenuItem
            // 
            this.polaczenieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polaczenieTestToolStripMenuItem,
            this.zakonczProgramToolStripMenuItem});
            this.polaczenieToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.polaczenieToolStripMenuItem.Name = "polaczenieToolStripMenuItem";
            this.polaczenieToolStripMenuItem.Size = new System.Drawing.Size(81, 43);
            this.polaczenieToolStripMenuItem.Text = "Połączenie";
            // 
            // polaczenieTestToolStripMenuItem
            // 
            this.polaczenieTestToolStripMenuItem.Name = "polaczenieTestToolStripMenuItem";
            this.polaczenieTestToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.polaczenieTestToolStripMenuItem.Text = "Sprawdź połączenie z bazą danych";
            this.polaczenieTestToolStripMenuItem.Click += new System.EventHandler(this.polaczenieTestToolStripMenuItem_Click);
            // 
            // zakonczProgramToolStripMenuItem
            // 
            this.zakonczProgramToolStripMenuItem.Name = "zakonczProgramToolStripMenuItem";
            this.zakonczProgramToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.zakonczProgramToolStripMenuItem.Text = "Zakończ program";
            this.zakonczProgramToolStripMenuItem.Click += new System.EventHandler(this.zakonczProgramToolStripMenuItem_Click);
            // 
            // umowyToolStripMenuItem
            // 
            this.umowyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usługaMuzycznaToolStripMenuItem,
            this.usługaOświetleniowaToolStripMenuItem});
            this.umowyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.umowyToolStripMenuItem.Name = "umowyToolStripMenuItem";
            this.umowyToolStripMenuItem.Size = new System.Drawing.Size(123, 43);
            this.umowyToolStripMenuItem.Text = "Formularz umowy";
            // 
            // usługaMuzycznaToolStripMenuItem
            // 
            this.usługaMuzycznaToolStripMenuItem.Name = "usługaMuzycznaToolStripMenuItem";
            this.usługaMuzycznaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.usługaMuzycznaToolStripMenuItem.Text = "Usługa muzyczna";
            this.usługaMuzycznaToolStripMenuItem.Click += new System.EventHandler(this.usługaMuzycznaToolStripMenuItem_Click);
            // 
            // usługaOświetleniowaToolStripMenuItem
            // 
            this.usługaOświetleniowaToolStripMenuItem.Name = "usługaOświetleniowaToolStripMenuItem";
            this.usługaOświetleniowaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.usługaOświetleniowaToolStripMenuItem.Text = "Usługa oświetleniowa";
            this.usługaOświetleniowaToolStripMenuItem.Click += new System.EventHandler(this.usługaOświetleniowaToolStripMenuItem_Click);
            // 
            // RejestrZawartychUmowToolStripMenuItem
            // 
            this.RejestrZawartychUmowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.RejestrZawartychUmowToolStripMenuItem.Name = "RejestrZawartychUmowToolStripMenuItem";
            this.RejestrZawartychUmowToolStripMenuItem.Size = new System.Drawing.Size(160, 43);
            this.RejestrZawartychUmowToolStripMenuItem.Text = "Rejestr zawartych umów";
            this.RejestrZawartychUmowToolStripMenuItem.Click += new System.EventHandler(this.RejestrZawartychUmowToolStripMenuItem_Click);
            // 
            // rejestrRezerwacjiToolStripMenuItem
            // 
            this.rejestrRezerwacjiToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rejestrRezerwacjiToolStripMenuItem.Name = "rejestrRezerwacjiToolStripMenuItem";
            this.rejestrRezerwacjiToolStripMenuItem.Size = new System.Drawing.Size(122, 43);
            this.rejestrRezerwacjiToolStripMenuItem.Text = "Rejestr rezerwacji";
            this.rejestrRezerwacjiToolStripMenuItem.Click += new System.EventHandler(this.rejestrRezerwacjiToolStripMenuItem_Click);
            // 
            // panelGlowny
            // 
            this.panelGlowny.AutoSize = true;
            this.panelGlowny.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGlowny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelGlowny.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelGlowny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGlowny.Location = new System.Drawing.Point(0, 47);
            this.panelGlowny.Name = "panelGlowny";
            this.panelGlowny.Size = new System.Drawing.Size(853, 471);
            this.panelGlowny.TabIndex = 1;
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonWyloguj.BackgroundImage = global::UmowyMJ.Properties.Resources.Logout;
            this.buttonWyloguj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWyloguj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWyloguj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonWyloguj.Location = new System.Drawing.Point(809, 10);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(32, 28);
            this.buttonWyloguj.TabIndex = 0;
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            this.buttonWyloguj.Visible = false;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // UmowyMJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(853, 518);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.panelGlowny);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UmowyMJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UmowyMJ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem polaczenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polaczenieTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakonczProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem umowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RejestrZawartychUmowToolStripMenuItem;
        private System.Windows.Forms.Panel panelGlowny;
        public System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.ToolStripMenuItem usługaMuzycznaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usługaOświetleniowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejestrRezerwacjiToolStripMenuItem;
    }
}

