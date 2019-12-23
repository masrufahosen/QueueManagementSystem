namespace QMS.ServiceProvider.WindowsClient
{
    partial class ServiceLogin
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbClientServiceBooth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbServices = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.Refrash = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Service Booth: ";
            // 
            // cbClientServiceBooth
            // 
            this.cbClientServiceBooth.FormattingEnabled = true;
            this.cbClientServiceBooth.Location = new System.Drawing.Point(306, 194);
            this.cbClientServiceBooth.Name = "cbClientServiceBooth";
            this.cbClientServiceBooth.Size = new System.Drawing.Size(265, 21);
            this.cbClientServiceBooth.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Service:";
            // 
            // cbServices
            // 
            this.cbServices.FormattingEnabled = true;
            this.cbServices.Items.AddRange(new object[] {
            "Select One"});
            this.cbServices.Location = new System.Drawing.Point(305, 147);
            this.cbServices.Name = "cbServices";
            this.cbServices.Size = new System.Drawing.Size(265, 21);
            this.cbServices.TabIndex = 9;
            this.cbServices.SelectionChangeCommitted += new System.EventHandler(this.cbServices_SelectionChangeCommitted);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(370, 249);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(201, 45);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Refrash
            // 
            this.Refrash.Location = new System.Drawing.Point(576, 147);
            this.Refrash.Name = "Refrash";
            this.Refrash.Size = new System.Drawing.Size(55, 23);
            this.Refrash.TabIndex = 13;
            this.Refrash.Text = "Refrash";
            this.Refrash.UseVisualStyleBackColor = true;
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(577, 192);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(54, 23);
            this.btnLoadAll.TabIndex = 14;
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // ServiceLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.Refrash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbClientServiceBooth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbServices);
            this.Controls.Add(this.btnLogin);
            this.Name = "ServiceLogin";
            this.Text = "Service Login";
            this.Load += new System.EventHandler(this.ServiceLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClientServiceBooth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbServices;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button Refrash;
        private System.Windows.Forms.Button btnLoadAll;
    }
}

