namespace UmowyMJ
{
    partial class UserControlStart
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
            this.buttonRejestracja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogowanie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRejestracja
            // 
            this.buttonRejestracja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonRejestracja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRejestracja.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.buttonRejestracja.ForeColor = System.Drawing.Color.White;
            this.buttonRejestracja.Location = new System.Drawing.Point(305, 305);
            this.buttonRejestracja.Name = "buttonRejestracja";
            this.buttonRejestracja.Size = new System.Drawing.Size(113, 52);
            this.buttonRejestracja.TabIndex = 5;
            this.buttonRejestracja.Text = "Rejestracja";
            this.buttonRejestracja.UseVisualStyleBackColor = false;
            this.buttonRejestracja.Click += new System.EventHandler(this.buttonRejestracja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(285, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Witaj w programie Umowy MJ !";
            // 
            // buttonLogowanie
            // 
            this.buttonLogowanie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(103)))), ((int)(((byte)(34)))));
            this.buttonLogowanie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogowanie.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.buttonLogowanie.ForeColor = System.Drawing.Color.White;
            this.buttonLogowanie.Location = new System.Drawing.Point(439, 305);
            this.buttonLogowanie.Name = "buttonLogowanie";
            this.buttonLogowanie.Size = new System.Drawing.Size(113, 52);
            this.buttonLogowanie.TabIndex = 3;
            this.buttonLogowanie.Text = "Logowanie";
            this.buttonLogowanie.UseVisualStyleBackColor = false;
            this.buttonLogowanie.Click += new System.EventHandler(this.buttonLogowanie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(272, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Program tylko i wyłącznie do użytku dla pracowników firmy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UmowyMJ.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(252, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // UserControlStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRejestracja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLogowanie);
            this.Name = "UserControlStart";
            this.Size = new System.Drawing.Size(853, 471);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRejestracja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogowanie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
