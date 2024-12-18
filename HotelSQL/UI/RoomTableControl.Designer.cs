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
            components = new System.ComponentModel.Container();
            TableOfRoom = new AntdUI.Table();
            bindRoom = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindRoom).BeginInit();
            SuspendLayout();
            // 
            // TableOfRoom
            // 
            TableOfRoom.Bordered = true;
            TableOfRoom.Empty = false;
            TableOfRoom.EmptyHeader = true;
            TableOfRoom.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TableOfRoom.Location = new Point(29, 21);
            TableOfRoom.Name = "TableOfRoom";
            TableOfRoom.Size = new Size(938, 636);
            TableOfRoom.TabIndex = 1;
            TableOfRoom.Text = "房间列表";
            TableOfRoom.SetRowStyle += TableOfRoom_SetRowStyle;
            // 
            // RoomTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(TableOfRoom);
            Location = new Point(225, 25);
            Name = "RoomTableControl";
            Size = new Size(1000, 750);
            ((System.ComponentModel.ISupportInitialize)bindRoom).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table TableOfRoom;
        private BindingSource bindRoom;
    }
}
