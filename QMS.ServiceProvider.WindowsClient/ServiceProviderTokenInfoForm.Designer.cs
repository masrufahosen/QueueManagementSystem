namespace QMS.ServiceProvider.WindowsClient
{
    partial class ServiceProviderTokenInfoForm
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.gvWaitingToken = new System.Windows.Forms.DataGridView();
            this.lblTokenNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaitingToken)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(525, 392);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(122, 48);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Call Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPass
            // 
            this.btnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPass.Location = new System.Drawing.Point(397, 392);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(122, 48);
            this.btnPass.TabIndex = 1;
            this.btnPass.Text = "Pass This";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // gvWaitingToken
            // 
            this.gvWaitingToken.AllowUserToAddRows = false;
            this.gvWaitingToken.AllowUserToDeleteRows = false;
            this.gvWaitingToken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvWaitingToken.Location = new System.Drawing.Point(0, 45);
            this.gvWaitingToken.Name = "gvWaitingToken";
            this.gvWaitingToken.ReadOnly = true;
            this.gvWaitingToken.Size = new System.Drawing.Size(263, 393);
            this.gvWaitingToken.TabIndex = 2;
            // 
            // lblTokenNumber
            // 
            this.lblTokenNumber.AutoSize = true;
            this.lblTokenNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenNumber.Location = new System.Drawing.Point(303, 128);
            this.lblTokenNumber.Name = "lblTokenNumber";
            this.lblTokenNumber.Size = new System.Drawing.Size(200, 153);
            this.lblTokenNumber.TabIndex = 3;
            this.lblTokenNumber.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Waiting List";
            // 
            // btnRefreshGrid
            // 
            this.btnRefreshGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshGrid.Location = new System.Drawing.Point(269, 392);
            this.btnRefreshGrid.Name = "btnRefreshGrid";
            this.btnRefreshGrid.Size = new System.Drawing.Size(122, 48);
            this.btnRefreshGrid.TabIndex = 5;
            this.btnRefreshGrid.Text = "Refresh Grid";
            this.btnRefreshGrid.UseVisualStyleBackColor = true;
            this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
            // 
            // ServiceProviderTokenInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 452);
            this.Controls.Add(this.btnRefreshGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTokenNumber);
            this.Controls.Add(this.gvWaitingToken);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnNext);
            this.Name = "ServiceProviderTokenInfoForm";
            this.Text = "ServiceProviderTokenInfoForm";
            this.Load += new System.EventHandler(this.ServiceProviderTokenInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvWaitingToken)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.DataGridView gvWaitingToken;
        private System.Windows.Forms.Label lblTokenNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshGrid;
    }
}