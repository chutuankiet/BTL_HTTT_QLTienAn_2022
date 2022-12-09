
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenLoaiNghi = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiNghi = new System.Windows.Forms.ComboBox();
            this.btnThemloainghi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lbSang = new System.Windows.Forms.Label();
            this.lbTrua = new System.Windows.Forms.Label();
            this.lbToi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiNghi.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 102);
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
            this.label1.Location = new System.Drawing.Point(205, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Số buổi sáng:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "Số buổi trưa:";
            // 
            // txtTenLoaiNghi
            // 
            this.txtTenLoaiNghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenLoaiNghi.Location = new System.Drawing.Point(356, 141);
            this.txtTenLoaiNghi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLoaiNghi.Name = "txtTenLoaiNghi";
            this.txtTenLoaiNghi.Size = new System.Drawing.Size(271, 22);
            this.txtTenLoaiNghi.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 247);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Số buổi tối:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tên loại nghỉ: ";
            // 
            // cbLoaiNghi
            // 
            this.cbLoaiNghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLoaiNghi.FormattingEnabled = true;
            this.cbLoaiNghi.Location = new System.Drawing.Point(356, 99);
            this.cbLoaiNghi.Name = "cbLoaiNghi";
            this.cbLoaiNghi.Size = new System.Drawing.Size(271, 24);
            this.cbLoaiNghi.TabIndex = 56;
            this.cbLoaiNghi.SelectedIndexChanged += new System.EventHandler(this.cbLoaiNghi_SelectedIndexChanged);
            // 
            // btnThemloainghi
            // 
            this.btnThemloainghi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThemloainghi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemloainghi.ImageOptions.Image")));
            this.btnThemloainghi.Location = new System.Drawing.Point(660, 99);
            this.btnThemloainghi.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemloainghi.Name = "btnThemloainghi";
            this.btnThemloainghi.Size = new System.Drawing.Size(165, 37);
            this.btnThemloainghi.TabIndex = 44;
            this.btnThemloainghi.Text = "Thêm loại nghỉ";
            this.btnThemloainghi.Click += new System.EventHandler(this.btnThemloainghi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(660, 172);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 37);
            this.btnXoa.TabIndex = 57;
            this.btnXoa.Text = "Xóa loại nghỉ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(352, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 24);
            this.label5.TabIndex = 45;
            this.label5.Text = "Thêm loại nghỉ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbToi);
            this.panel1.Controls.Add(this.lbTrua);
            this.panel1.Controls.Add(this.lbSang);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textEdit1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThemloainghi);
            this.panel1.Controls.Add(this.cbLoaiNghi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTenLoaiNghi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 309);
            this.panel1.TabIndex = 58;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 309);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(867, 403);
            this.groupControl1.TabIndex = 59;
            this.groupControl1.Text = "Chỉnh sửa Chi tiết cắt cơm";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Green;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(221, 385);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(207, 51);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Xác nhận";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.check});
            this.gridControl1.Size = new System.Drawing.Size(863, 384);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày cắt cơm";
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "NgayCatCom";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Buổi sáng";
            this.gridColumn2.ColumnEdit = this.check;
            this.gridColumn2.FieldName = "BuoiSang";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // check
            // 
            this.check.AutoHeight = false;
            this.check.Name = "check";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Buổi trưa";
            this.gridColumn3.ColumnEdit = this.check;
            this.gridColumn3.FieldName = "BuoiTrua";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Buổi tối";
            this.gridColumn4.ColumnEdit = this.check;
            this.gridColumn4.FieldName = "BuoiToi";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 94;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "Số ngày cắt cơm:";
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textEdit1.Location = new System.Drawing.Point(356, 187);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(271, 22);
            this.textEdit1.TabIndex = 59;
            // 
            // lbSang
            // 
            this.lbSang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSang.AutoSize = true;
            this.lbSang.Location = new System.Drawing.Point(305, 247);
            this.lbSang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSang.Name = "lbSang";
            this.lbSang.Size = new System.Drawing.Size(20, 21);
            this.lbSang.TabIndex = 60;
            this.lbSang.Text = "0";
            // 
            // lbTrua
            // 
            this.lbTrua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTrua.AutoSize = true;
            this.lbTrua.Location = new System.Drawing.Point(506, 247);
            this.lbTrua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTrua.Name = "lbTrua";
            this.lbTrua.Size = new System.Drawing.Size(16, 17);
            this.lbTrua.TabIndex = 61;
            this.lbTrua.Text = "0";
            // 
            // lbToi
            // 
            this.lbToi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbToi.AutoSize = true;
            this.lbToi.Location = new System.Drawing.Point(698, 247);
            this.lbToi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbToi.Name = "lbToi";
            this.lbToi.Size = new System.Drawing.Size(16, 17);
            this.lbToi.TabIndex = 62;
            this.lbToi.Text = "0";
            // 
            // ThemLoaiNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 712);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ThemLoaiNghi";
            this.Text = "ThemLoaiNghi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemLoaiNghi_FormClosing);
            this.Load += new System.EventHandler(this.ThemLoaiNghi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiNghi.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTenLoaiNghi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiNghi;
        private DevExpress.XtraEditors.SimpleButton btnThemloainghi;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit check;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label lbToi;
        private System.Windows.Forms.Label lbTrua;
        private System.Windows.Forms.Label lbSang;
    }
}