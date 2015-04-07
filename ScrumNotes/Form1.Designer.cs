namespace ScrumNotes
{
    partial class Form1
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
            this.bGo = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bGo
            // 
            this.bGo.Location = new System.Drawing.Point(323, 67);
            this.bGo.Name = "bGo";
            this.bGo.Size = new System.Drawing.Size(75, 23);
            this.bGo.TabIndex = 0;
            this.bGo.Text = "Go";
            this.bGo.UseVisualStyleBackColor = true;
            this.bGo.Click += new System.EventHandler(this.bGo_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(137, 51);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(100, 20);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.Text = "albertcrowley@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-mail";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(137, 87);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(55, 179);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(343, 264);
            this.rtbOutput.TabIndex = 5;
            this.rtbOutput.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(137, 124);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(100, 20);
            this.tbServer.TabIndex = 7;
            this.tbServer.Text = "imap.gmail.com";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 464);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.bGo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGo;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServer;
    }
}

