namespace UmowyMJ
{
    partial class UserControlRejestrRezerwacji
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRejestrRezerwacji = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.buttonStworzUmowe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRejestrRezerwacji
            // 
            this.labelRejestrRezerwacji.AutoSize = true;
            this.labelRejestrRezerwacji.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRejestrRezerwacji.Location = new System.Drawing.Point(345, 19);
            this.labelRejestrRezerwacji.Name = "labelRejestrRezerwacji";
            this.labelRejestrRezerwacji.Size = new System.Drawing.Size(162, 25);
            this.labelRejestrRezerwacji.TabIndex = 2;
            this.labelRejestrRezerwacji.Text = "Rejestr rezerwacji";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 60);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(822, 395);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonOdswiez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdswiez.ForeColor = System.Drawing.Color.White;
            this.buttonOdswiez.Location = new System.Drawing.Point(752, 15);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(85, 33);
            this.buttonOdswiez.TabIndex = 5;
            this.buttonOdswiez.Text = "Odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = false;
            this.buttonOdswiez.Click += new System.EventHandler(this.buttonOdswiez_Click);
            // 
            // buttonUsun
            // 
            this.buttonUsun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonUsun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsun.ForeColor = System.Drawing.Color.White;
            this.buttonUsun.Location = new System.Drawing.Point(662, 15);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(85, 33);
            this.buttonUsun.TabIndex = 6;
            this.buttonUsun.Text = "Usuń";
            this.buttonUsun.UseVisualStyleBackColor = false;
            this.buttonUsun.Visible = false;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // buttonStworzUmowe
            // 
            this.buttonStworzUmowe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonStworzUmowe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStworzUmowe.ForeColor = System.Drawing.Color.White;
            this.buttonStworzUmowe.Location = new System.Drawing.Point(549, 15);
            this.buttonStworzUmowe.Name = "buttonStworzUmowe";
            this.buttonStworzUmowe.Size = new System.Drawing.Size(108, 33);
            this.buttonStworzUmowe.TabIndex = 7;
            this.buttonStworzUmowe.Text = "Stwórz umowę";
            this.buttonStworzUmowe.UseVisualStyleBackColor = false;
            this.buttonStworzUmowe.Visible = false;
            this.buttonStworzUmowe.Click += new System.EventHandler(this.buttonStworzUmowe_Click);
            // 
            // UserControlRejestrRezerwacji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.buttonStworzUmowe);
            this.Controls.Add(this.buttonUsun);
            this.Controls.Add(this.buttonOdswiez);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelRejestrRezerwacji);
            this.Name = "UserControlRejestrRezerwacji";
            this.Size = new System.Drawing.Size(853, 471);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRejestrRezerwacji;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOdswiez;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonStworzUmowe;
    }
}
