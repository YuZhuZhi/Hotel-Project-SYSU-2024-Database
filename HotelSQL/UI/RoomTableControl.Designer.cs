namespace HotelSQL.UI
{
    partial class RoomTableControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            TableOfRoom = new AntdUI.Table();
            RoomTablePagination = new AntdUI.Pagination();
            RoomTableDropdown = new AntdUI.Dropdown();
            SuspendLayout();
            // 
            // TableOfRoom
            // 
            TableOfRoom.Bordered = true;
            TableOfRoom.Empty = false;
            TableOfRoom.EmptyHeader = true;
            TableOfRoom.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TableOfRoom.Location = new Point(30, 20);
            TableOfRoom.Name = "TableOfRoom";
            TableOfRoom.Size = new Size(935, 575);
            TableOfRoom.TabIndex = 1;
            TableOfRoom.Text = "房间列表";
            TableOfRoom.CellButtonClick += TableOfRoom_CellButtonClick;
            TableOfRoom.SetRowStyle += TableOfRoom_SetRowStyle;
            // 
            // RoomTablePagination
            // 
            RoomTablePagination.Anchor = AnchorStyles.Bottom;
            RoomTablePagination.Current = 0;
            RoomTablePagination.Location = new Point(275, 600);
            RoomTablePagination.Name = "RoomTablePagination";
            RoomTablePagination.PageSize = 20;
            RoomTablePagination.Size = new Size(450, 50);
            RoomTablePagination.TabIndex = 2;
            RoomTablePagination.Text = "RoomTablePagination";
            RoomTablePagination.TextDesc = "";
            RoomTablePagination.Total = 100;
            RoomTablePagination.ValueChanged += RoomTablePagination_ValueChanged;
            // 
            // RoomTableDropdown
            // 
            RoomTableDropdown.BorderWidth = 1F;
            RoomTableDropdown.DropDownPadding = new Size(12, 12);
            RoomTableDropdown.Font = new Font("汉仪文黑-85W", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTableDropdown.Ghost = true;
            RoomTableDropdown.Items.AddRange(new object[] { "新增房间", "移除房间", "查看房间类型信息", "刷新" });
            RoomTableDropdown.Location = new Point(854, 600);
            RoomTableDropdown.Name = "RoomTableDropdown";
            RoomTableDropdown.Placement = AntdUI.TAlignFrom.Top;
            RoomTableDropdown.Shape = AntdUI.TShape.Round;
            RoomTableDropdown.ShowArrow = true;
            RoomTableDropdown.Size = new Size(111, 48);
            RoomTableDropdown.TabIndex = 5;
            RoomTableDropdown.Text = "更多操作\r\n";
            RoomTableDropdown.Trigger = AntdUI.Trigger.Hover;
            RoomTableDropdown.Type = AntdUI.TTypeMini.Info;
            RoomTableDropdown.SelectedValueChanged += RoomTableDropdown_SelectedValueChanged;
            // 
            // RoomTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(RoomTableDropdown);
            Controls.Add(RoomTablePagination);
            Controls.Add(TableOfRoom);
            Location = new Point(225, 14);
            Name = "RoomTableControl";
            Size = new Size(1000, 652);
            Load += RoomTableControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table TableOfRoom;
        private AntdUI.Pagination RoomTablePagination;
        private AntdUI.Dropdown RoomTableDropdown;
    }
}
