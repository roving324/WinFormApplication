namespace MainForms
{
    partial class M02_PasswordChang
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPerPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChangPW = new System.Windows.Forms.TextBox();
            this.btnPWChang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(78, 35);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(179, 21);
            this.txtUserID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "기존 P/W";
            // 
            // txtPerPW
            // 
            this.txtPerPW.Location = new System.Drawing.Point(78, 62);
            this.txtPerPW.Name = "txtPerPW";
            this.txtPerPW.Size = new System.Drawing.Size(179, 21);
            this.txtPerPW.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "변경 P/W";
            // 
            // txtChangPW
            // 
            this.txtChangPW.Location = new System.Drawing.Point(78, 89);
            this.txtChangPW.Name = "txtChangPW";
            this.txtChangPW.Size = new System.Drawing.Size(179, 21);
            this.txtChangPW.TabIndex = 1;
            // 
            // btnPWChang
            // 
            this.btnPWChang.Location = new System.Drawing.Point(155, 126);
            this.btnPWChang.Name = "btnPWChang";
            this.btnPWChang.Size = new System.Drawing.Size(102, 36);
            this.btnPWChang.TabIndex = 2;
            this.btnPWChang.Text = "비밀번호 변경";
            this.btnPWChang.UseVisualStyleBackColor = true;
            this.btnPWChang.Click += new System.EventHandler(this.btnPWChang_Click);
            // 
            // M02_PasswordChang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 185);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnPWChang);
            this.Controls.Add(this.txtPerPW);
            this.Controls.Add(this.txtChangPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "M02_PasswordChang";
            this.Text = "비밀번호 변경";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPerPW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChangPW;
        private System.Windows.Forms.Button btnPWChang;
    }
}