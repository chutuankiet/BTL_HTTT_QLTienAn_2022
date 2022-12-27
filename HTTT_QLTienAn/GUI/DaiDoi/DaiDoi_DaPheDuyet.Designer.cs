
namespace HTTT_QLTienAn.GUI.DaiDoi
{
    partial class DaiDoi_DaPheDuyet
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DaiDoi_DaPheDuyet));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvDaXacNhan_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvDaXacNhan = new DevExpress.XtraGrid.GridControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.chkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvChiTietDaXaNhan = new DevExpress.XtraGrid.GridControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXacNhan_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDaXaNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Cán bộ tiểu đoàn";
            this.gridColumn4.FieldName = "HoTend";
            this.gridColumn4.MinWidth = 29;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 137;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày đăng ký";
            this.gridColumn2.FieldName = "NgayDK";
            this.gridColumn2.MinWidth = 29;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 117;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã DS";
            this.gridColumn1.FieldName = "MaDS";
            this.gridColumn1.MinWidth = 29;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // dgvDaXacNhan_View
            // 
            this.dgvDaXacNhan_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.dgvDaXacNhan_View.GridControl = this.dgvDaXacNhan;
            this.dgvDaXacNhan_View.Name = "dgvDaXacNhan_View";
            this.dgvDaXacNhan_View.OptionsView.ShowGroupPanel = false;
            this.dgvDaXacNhan_View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvDaXacNhan_View_RowClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cán bộ đại đội";
            this.gridColumn3.FieldName = "HoTenc";
            this.gridColumn3.MinWidth = 29;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 126;
            // 
            // dgvDaXacNhan
            // 
            this.dgvDaXacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaXacNhan.Location = new System.Drawing.Point(2, 17);
            this.dgvDaXacNhan.MainView = this.dgvDaXacNhan_View;
            this.dgvDaXacNhan.Name = "dgvDaXacNhan";
            this.dgvDaXacNhan.Size = new System.Drawing.Size(490, 728);
            this.dgvDaXacNhan.TabIndex = 0;
            this.dgvDaXacNhan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDaXacNhan_View});
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dgvDaXacNhan);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(494, 747);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách đã duyệt";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoHeight = false;
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.ValueChecked = 1;
            this.chkEdit.ValueUnchecked = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ngày nghỉ";
            this.gridColumn9.FieldName = "NgayCatCom";
            this.gridColumn9.MinWidth = 29;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 296;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Lớp";
            this.gridColumn8.FieldName = "TenLop";
            this.gridColumn8.MinWidth = 29;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 128;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Họ tên";
            this.gridColumn7.FieldName = "HoTen";
            this.gridColumn7.MinWidth = 29;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 314;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn5});
            this.gridView2.GridControl = this.dgvChiTietDaXaNhan;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Loại nghỉ";
            this.gridColumn5.FieldName = "TenLoaiNghi";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 86;
            // 
            // dgvChiTietDaXaNhan
            // 
            this.dgvChiTietDaXaNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietDaXaNhan.Location = new System.Drawing.Point(2, 17);
            this.dgvChiTietDaXaNhan.MainView = this.gridView2;
            this.dgvChiTietDaXaNhan.Name = "dgvChiTietDaXaNhan";
            this.dgvChiTietDaXaNhan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.chkEdit});
            this.dgvChiTietDaXaNhan.Size = new System.Drawing.Size(603, 728);
            this.dgvChiTietDaXaNhan.TabIndex = 7;
            this.dgvChiTietDaXaNhan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvChiTietDaXaNhan);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(503, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(607, 747);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Chi tiết danh sách";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1113, 753);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // DaiDoi_DaPheDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DaiDoi_DaPheDuyet";
            this.Size = new System.Drawing.Size(1121, 760);
            this.Load += new System.EventHandler(this.DaiDoi_DaPheDuyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXacNhan_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDaXaNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDaXacNhan_View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl dgvDaXacNhan;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl dgvChiTietDaXaNhan;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}
