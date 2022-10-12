namespace UmowyMJ
{
    partial class UserControlRejestracja
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWroc = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonZaloguj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPowtorzHaslo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxKodAutoryzacyjny = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWroc
            // 
            this.buttonWroc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonWroc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWroc.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.buttonWroc.ForeColor = System.Drawing.Color.White;
            this.buttonWroc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonWroc.Location = new System.Drawing.Point(265, 395);
            this.buttonWroc.Name = "buttonWroc";
            this.buttonWroc.Size = new System.Drawing.Size(132, 47);
            this.buttonWroc.TabIndex = 6;
            this.buttonWroc.Text = "Wróć";
            this.buttonWroc.UseVisualStyleBackColor = false;
            this.buttonWroc.Click += new System.EventHandler(this.buttonWroc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UmowyMJ.Properties.Resources.account;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(351, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(289, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rejestracja użytkownika";
            // 
            // buttonZaloguj
            // 
            this.buttonZaloguj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonZaloguj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZaloguj.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.buttonZaloguj.ForeColor = System.Drawing.Color.White;
            this.buttonZaloguj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonZaloguj.Location = new System.Drawing.Point(424, 395);
            this.buttonZaloguj.Name = "buttonZaloguj";
            this.buttonZaloguj.Size = new System.Drawing.Size(132, 47);
            this.buttonZaloguj.TabIndex = 5;
            this.buttonZaloguj.Text = "Zarejestruj";
            this.buttonZaloguj.UseVisualStyleBackColor = false;
            this.buttonZaloguj.Click += new System.EventHandler(this.buttonStwórz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(312, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Haslo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(312, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Email";
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxHaslo.Location = new System.Drawing.Point(378, 272);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.PasswordChar = '*';
            this.textBoxHaslo.Size = new System.Drawing.Size(129, 21);
            this.textBoxHaslo.TabIndex = 2;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxLogin.Location = new System.Drawing.Point(378, 236);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(129, 21);
            this.textBoxLogin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(262, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Powtórz hasło";
            // 
            // textBoxPowtorzHaslo
            // 
            this.textBoxPowtorzHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxPowtorzHaslo.Location = new System.Drawing.Point(378, 308);
            this.textBoxPowtorzHaslo.Name = "textBoxPowtorzHaslo";
            this.textBoxPowtorzHaslo.PasswordChar = '*';
            this.textBoxPowtorzHaslo.Size = new System.Drawing.Size(129, 21);
            this.textBoxPowtorzHaslo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(239, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kod autoryzacyjny";
            // 
            // textBoxKodAutoryzacyjny
            // 
            this.textBoxKodAutoryzacyjny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBoxKodAutoryzacyjny.Location = new System.Drawing.Point(378, 345);
            this.textBoxKodAutoryzacyjny.Name = "textBoxKodAutoryzacyjny";
            this.textBoxKodAutoryzacyjny.PasswordChar = '*';
            this.textBoxKodAutoryzacyjny.Size = new System.Drawing.Size(129, 21);
            this.textBoxKodAutoryzacyjny.TabIndex = 4;
            // 
            // UserControlRejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxKodAutoryzacyjny);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPowtorzHaslo);
            this.Controls.Add(this.buttonWroc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonZaloguj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.textBoxLogin);
            this.Name = "UserControlRejestracja";
            this.Size = new System.Drawing.Size(853, 471);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWroc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonZaloguj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPowtorzHaslo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxKodAutoryzacyjny;
    }
}
