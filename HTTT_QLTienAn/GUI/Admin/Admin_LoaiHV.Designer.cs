
namespace HTTT_QLTienAn.GUI.Admin
{
    partial class Admin_LoaiHV
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
            this.Thêm = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemLHV = new DevExpress.XtraEditors.SimpleButton();
            this.txtThemTenLHV = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtMaTCA = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSuaMaLHV = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuaTenLHV = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSuaLHV = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvLHV = new DevExpress.XtraGrid.GridControl();
            this.dgvLHV_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtTCA = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Thêm)).BeginInit();
            this.Thêm.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThemTenLHV.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTCA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaMaLHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaTenLHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHV_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTCA.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Thêm
            // 
            this.Thêm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Thêm.Location = new System.Drawing.Point(2, 17);
            this.Thêm.Name = "Thêm";
            this.Thêm.SelectedTabPage = this.xtraTabPage1;
            this.Thêm.Size = new System.Drawing.Size(1161, 199);
            this.Thêm.TabIndex = 0;
            this.Thêm.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtTCA);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Controls.Add(this.btnThemLHV);
            this.xtraTabPage1.Controls.Add(this.txtThemTenLHV);
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1159, 174);
            this.xtraTabPage1.Text = "Thêm";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mã tiêu chuẩn ăn";
            // 
            // btnThemLHV
            // 
            this.btnThemLHV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemLHV.Location = new System.Drawing.Point(467, 52);
            this.btnThemLHV.Name = "btnThemLHV";
            this.btnThemLHV.Size = new System.Drawing.Size(113, 76);
            this.btnThemLHV.TabIndex = 14;
            this.btnThemLHV.Text = "Thêm";
            this.btnThemLHV.Click += new System.EventHandler(this.btnThemLHV_Click);
            // 
            // txtThemTenLHV
            // 
            this.txtThemTenLHV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtThemTenLHV.EditValue = "";
            this.txtThemTenLHV.Location = new System.Drawing.Point(71, 53);
            this.txtThemTenLHV.Name = "txtThemTenLHV";
            this.txtThemTenLHV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThemTenLHV.Size = new System.Drawing.Size(323, 22);
            this.txtThemTenLHV.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên loại học viên";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtMaTCA);
            this.xtraTabPage2.Controls.Add(this.label4);
            this.xtraTabPage2.Controls.Add(this.txtSuaMaLHV);
            this.xtraTabPage2.Controls.Add(this.label1);
            this.xtraTabPage2.Controls.Add(this.txtSuaTenLHV);
            this.xtraTabPage2.Controls.Add(this.label13);
            this.xtraTabPage2.Controls.Add(this.btnSuaLHV);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1159, 174);
            this.xtraTabPage2.Text = "Sửa";
            // 
            // txtMaTCA
            // 
            this.txtMaTCA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaTCA.EditValue = "";
            this.txtMaTCA.Location = new System.Drawing.Point(66, 142);
            this.txtMaTCA.Name = "txtMaTCA";
            this.txtMaTCA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaTCA.Size = new System.Drawing.Size(323, 22);
            this.txtMaTCA.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Mã tiêu chuẩn ăn";
            // 
            // txtSuaMaLHV
            // 
            this.txtSuaMaLHV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSuaMaLHV.EditValue = "";
            this.txtSuaMaLHV.Enabled = false;
            this.txtSuaMaLHV.Location = new System.Drawing.Point(67, 29);
            this.txtSuaMaLHV.Name = "txtSuaMaLHV";
            this.txtSuaMaLHV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuaMaLHV.Size = new System.Drawing.Size(323, 22);
            this.txtSuaMaLHV.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã loại học viên";
            // 
            // txtSuaTenLHV
            // 
            this.txtSuaTenLHV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSuaTenLHV.EditValue = "";
            this.txtSuaTenLHV.Location = new System.Drawing.Point(67, 86);
            this.txtSuaTenLHV.Name = "txtSuaTenLHV";
            this.txtSuaTenLHV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuaTenLHV.Size = new System.Drawing.Size(323, 22);
            this.txtSuaTenLHV.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "Tên loại học viên";
            // 
            // btnSuaLHV
            // 
            this.btnSuaLHV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaLHV.Location = new System.Drawing.Point(463, 66);
            this.btnSuaLHV.Name = "btnSuaLHV";
            this.btnSuaLHV.Size = new System.Drawing.Size(126, 78);
            this.btnSuaLHV.TabIndex = 21;
            this.btnSuaLHV.Text = "Sửa";
            this.btnSuaLHV.Click += new System.EventHandler(this.btnSuaLHV_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dgvLHV);
            this.groupControl1.Location = new System.Drawing.Point(2, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1170, 375);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Thông tin loại học viên";
            // 
            // dgvLHV
            // 
            this.dgvLHV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLHV.Location = new System.Drawing.Point(2, 28);
            this.dgvLHV.MainView = this.dgvLHV_View;
            this.dgvLHV.Name = "dgvLHV";
            this.dgvLHV.Size = new System.Drawing.Size(1166, 347);
            this.dgvLHV.TabIndex = 0;
            this.dgvLHV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvLHV_View});
            // 
            // dgvLHV_View
            // 
            this.dgvLHV_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.dgvLHV_View.GridControl = this.dgvLHV;
            this.dgvLHV_View.Name = "dgvLHV_View";
            this.dgvLHV_View.OptionsView.ShowGroupPanel = false;
            this.dgvLHV_View.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvLHV_View_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã loại học viên";
            this.gridColumn1.FieldName = "MaLHV";
            this.gridColumn1.MinWidth = 29;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên loại học viên";
            this.gridColumn2.FieldName = "TenLHV";
            this.gridColumn2.MinWidth = 29;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 107;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mã tiêu chuẩn ăn";
            this.gridColumn3.FieldName = "MaTCA";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.Thêm);
            this.groupControl3.Location = new System.Drawing.Point(6, 384);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1165, 218);
            this.groupControl3.TabIndex = 10;
            this.groupControl3.Text = "Chỉnh sửa thông tin đơn vị";
            // 
            // txtTCA
            // 
            this.txtTCA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTCA.EditValue = "";
            this.txtTCA.Location = new System.Drawing.Point(71, 109);
            this.txtTCA.Name = "txtTCA";
            this.txtTCA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTCA.Size = new System.Drawing.Size(323, 22);
            this.txtTCA.TabIndex = 28;
            // 
            // Admin_LoaiHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl3);
            this.Name = "Admin_LoaiHV";
            this.Size = new System.Drawing.Size(1174, 605);
            this.Load += new System.EventHandler(this.Admin_LoaiHV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Thêm)).EndInit();
            this.Thêm.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThemTenLHV.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTCA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaMaLHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuaTenLHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHV_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTCA.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl Thêm;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnThemLHV;
        private DevExpress.XtraEditors.TextEdit txtThemTenLHV;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtSuaMaLHV;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSuaTenLHV;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.SimpleButton btnSuaLHV;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvLHV;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvLHV_View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TextEdit txtMaTCA;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTCA;
    }
}
