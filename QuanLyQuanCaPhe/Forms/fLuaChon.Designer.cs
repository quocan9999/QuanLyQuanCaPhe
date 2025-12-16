namespace QuanLyQuanCaPhe.Forms
{
    partial class fLuaChon
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnQuanTriHeThong = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Location = new System.Drawing.Point(86, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FORM LỰA CHỌN";
            // 
            // btnQuanTriHeThong
            // 
            this.btnQuanTriHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanTriHeThong.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnQuanTriHeThong.Location = new System.Drawing.Point(108, 80);
            this.btnQuanTriHeThong.Name = "btnQuanTriHeThong";
            this.btnQuanTriHeThong.Size = new System.Drawing.Size(216, 56);
            this.btnQuanTriHeThong.TabIndex = 1;
            this.btnQuanTriHeThong.Text = "Quản trị hệ thống";
            this.btnQuanTriHeThong.UseVisualStyleBackColor = true;
            // 
            // btnMain
            // 
            this.btnMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMain.Location = new System.Drawing.Point(108, 165);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(216, 66);
            this.btnMain.TabIndex = 2;
            this.btnMain.Text = "Quản lý quán coffee";
            this.btnMain.UseVisualStyleBackColor = true;
            // 
            // fLuaChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnQuanTriHeThong);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(450, 300);
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "fLuaChon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLuaChon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnQuanTriHeThong;
        private System.Windows.Forms.Button btnMain;
    }
}