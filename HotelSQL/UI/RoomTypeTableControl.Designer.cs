namespace HotelSQL.UI
{
    partial class RoomTypeTableControl
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
            TableOfRoomType = new AntdUI.Table();
            RoomTypePagination = new AntdUI.Pagination();
            SuspendLayout();
            // 
            // TableOfRoomType
            // 
            TableOfRoomType.Location = new Point(26, 3);
            TableOfRoomType.Name = "TableOfRoomType";
            TableOfRoomType.Size = new Size(685, 320);
            TableOfRoomType.SwitchSize = 10;
            TableOfRoomType.TabIndex = 0;
            TableOfRoomType.Text = "table1";
            TableOfRoomType.CellButtonClick += TableOfRoomType_CellButtonClick;
            TableOfRoomType.SetRowStyle += TableOfRoomType_SetRowStyle;
            // 
            // RoomTypePagination
            // 
            RoomTypePagination.Location = new Point(307, 329);
            RoomTypePagination.Name = "RoomTypePagination";
            RoomTypePagination.Size = new Size(221, 37);
            RoomTypePagination.TabIndex = 1;
            RoomTypePagination.Text = "pagination1";
            RoomTypePagination.ValueChanged += RoomTypePagination_ValueChanged;
            // 
            // RoomTypeTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RoomTypePagination);
            Controls.Add(TableOfRoomType);
            Name = "RoomTypeTableControl";
            Size = new Size(796, 369);
            Load += RoomTypeTableControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table TableOfRoomType;
        private AntdUI.Pagination RoomTypePagination;
    }
}
