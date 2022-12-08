
namespace HTTT_QLTienAn.GUI
{
    partial class ThemLoaiNghi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemLoaiNghi));
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cbLoaiNghi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToi = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrua = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSang = new DevExpress.XtraEditors.TextEdit();
            this.txtTenLoaiNghi = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnThemloainghi = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtToi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiNghi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(319, 352);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 37);
            this.btnXoa.TabIndex = 57;
            this.btnXoa.Text = "Xóa loại nghỉ";
            // 
            // cbLoaiNghi
            // 
            this.cbLoaiNghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLoaiNghi.FormattingEnabled = true;
            this.cbLoaiNghi.Location = new System.Drawing.Point(213, 99);
            this.cbLoaiNghi.Name = "cbLoaiNghi";
            this.cbLoaiNghi.Size = new System.Drawing.Size(271, 24);
            this.cbLoaiNghi.TabIndex = 56;
            this.cbLoaiNghi.SelectedIndexChanged += new System.EventHandler(this.cbLoaiNghi_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 305);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Số buổi tối:";
            // 
            // txtToi
            // 
            this.txtToi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtToi.Location = new System.Drawing.Point(213, 302);
            this.txtToi.Name = "txtToi";
            this.txtToi.Size = new System.Drawing.Size(271, 22);
            this.txtToi.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 261);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "Số buổi trưa:";
            // 
            // txtTrua
            // 
            this.txtTrua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTrua.Location = new System.Drawing.Point(213, 258);
            this.txtTrua.Name = "txtTrua";
            this.txtTrua.Size = new System.Drawing.Size(271, 22);
            this.txtTrua.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Loại nghỉ có sẵn:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 216);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Số buổi sáng:";
            // 
            // txtSang
            // 
            this.txtSang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSang.Location = new System.Drawing.Point(213, 213);
            this.txtSang.Name = "txtSang";
            this.txtSang.Size = new System.Drawing.Size(271, 22);
            this.txtSang.TabIndex = 49;
            // 
            // txtTenLoaiNghi
            // 
            this.txtTenLoaiNghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenLoaiNghi.Location = new System.Drawing.Point(213, 169);
            this.txtTenLoaiNghi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLoaiNghi.Name = "txtTenLoaiNghi";
            this.txtTenLoaiNghi.Size = new System.Drawing.Size(271, 22);
            this.txtTenLoaiNghi.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tên loại nghỉ: ";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 218);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 17);
            this.label11.TabIndex = 46;
            // 
            // btnThemloainghi
            // 
            this.btnThemloainghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThemloainghi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemloainghi.ImageOptions.Image")));
            this.btnThemloainghi.Location = new System.Drawing.Point(65, 352);
            this.btnThemloainghi.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemloainghi.Name = "btnThemloainghi";
            this.btnThemloainghi.Size = new System.Drawing.Size(165, 37);
            this.btnThemloainghi.TabIndex = 44;
            this.btnThemloainghi.Text = "Thêm loại nghỉ";
            this.btnThemloainghi.Click += new System.EventHandler(this.btnThemloainghi_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(209, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 24);
            this.label5.TabIndex = 45;
            this.label5.Text = "Thêm loại nghỉ";
            // 
            // ThemLoaiNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 439);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.cbLoaiNghi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtToi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSang);
            this.Controls.Add(this.txtTenLoaiNghi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnThemloainghi);
            this.Controls.Add(this.label5);
            this.Name = "ThemLoaiNghi";
            this.Text = "ThemLoaiNghi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemLoaiNghi_FormClosing);
            this.Load += new System.EventHandler(this.ThemLoaiNghi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtToi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiNghi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private System.Windows.Forms.ComboBox cbLoaiNghi;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtToi;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTrua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSang;
        private DevExpress.XtraEditors.TextEdit txtTenLoaiNghi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.SimpleButton btnThemloainghi;
        private System.Windows.Forms.Label label5;
    }
}