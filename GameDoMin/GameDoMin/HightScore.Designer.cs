namespace GameDoMin
{
    partial class HightScore
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
            this.dgvHightScore = new System.Windows.Forms.DataGridView();
            this.MaNguoiChoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguoiChoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHightScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHightScore
            // 
            this.dgvHightScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHightScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNguoiChoi,
            this.TenNguoiChoi,
            this.ThoiGian});
            this.dgvHightScore.Location = new System.Drawing.Point(0, 0);
            this.dgvHightScore.Name = "dgvHightScore";
            this.dgvHightScore.Size = new System.Drawing.Size(479, 258);
            this.dgvHightScore.TabIndex = 0;
            // 
            // MaNguoiChoi
            // 
            this.MaNguoiChoi.DataPropertyName = "MaNguoiChoi";
            this.MaNguoiChoi.HeaderText = "Mã người chơi";
            this.MaNguoiChoi.Name = "MaNguoiChoi";
            this.MaNguoiChoi.ReadOnly = true;
            // 
            // TenNguoiChoi
            // 
            this.TenNguoiChoi.DataPropertyName = "TenNguoiChoi";
            this.TenNguoiChoi.HeaderText = "Tên Người Chơi";
            this.TenNguoiChoi.Name = "TenNguoiChoi";
            this.TenNguoiChoi.ReadOnly = true;
            this.TenNguoiChoi.Width = 230;
            // 
            // ThoiGian
            // 
            this.ThoiGian.DataPropertyName = "ThoiGian";
            this.ThoiGian.HeaderText = "Thời gian";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            // 
            // HightScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 261);
            this.Controls.Add(this.dgvHightScore);
            this.Name = "HightScore";
            this.Text = "HightScore";
            this.Load += new System.EventHandler(this.HightScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHightScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHightScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNguoiChoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguoiChoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
    }
}