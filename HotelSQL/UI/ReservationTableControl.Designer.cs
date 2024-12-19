namespace HotelSQL.UI
{
    partial class ReservationTableControl
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
            TableOfReservation = new AntdUI.Table();
            bindReservation = new BindingSource(components);
            ReservationTablePagination = new AntdUI.Pagination();
            ReservationTableDropdown1 = new AntdUI.Dropdown();
            ((System.ComponentModel.ISupportInitialize)bindReservation).BeginInit();
            SuspendLayout();
            // 
            // TableOfReservation
            // 
            TableOfReservation.Bordered = true;
            TableOfReservation.Empty = false;
            TableOfReservation.EmptyHeader = true;
            TableOfReservation.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TableOfReservation.Location = new Point(30, 20);
            TableOfReservation.Name = "TableOfReservation";
            TableOfReservation.Size = new Size(935, 575);
            TableOfReservation.TabIndex = 1;
            TableOfReservation.Text = "酒店列表";
            // 
            // ReservationTablePagination
            // 
            ReservationTablePagination.Anchor = AnchorStyles.Bottom;
            ReservationTablePagination.Current = 0;
            ReservationTablePagination.Location = new Point(275, 600);
            ReservationTablePagination.Name = "ReservationTablePagination";
            ReservationTablePagination.PageSize = 20;
            ReservationTablePagination.Size = new Size(450, 50);
            ReservationTablePagination.TabIndex = 3;
            ReservationTablePagination.Text = "RoomTablePagination";
            ReservationTablePagination.TextDesc = "";
            ReservationTablePagination.Total = 100;
            ReservationTablePagination.ValueChanged += ReservationTablePagination_ValueChanged;
            // 
            // ReservationTableDropdown1
            // 
            ReservationTableDropdown1.BorderWidth = 1F;
            ReservationTableDropdown1.DropDownPadding = new Size(12, 12);
            ReservationTableDropdown1.Font = new Font("汉仪文黑-85W", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReservationTableDropdown1.Ghost = true;
            ReservationTableDropdown1.Items.AddRange(new object[] { "增加房间", "删除房间", "刷新" });
            ReservationTableDropdown1.Location = new Point(854, 600);
            ReservationTableDropdown1.Name = "ReservationTableDropdown1";
            ReservationTableDropdown1.Placement = AntdUI.TAlignFrom.Top;
            ReservationTableDropdown1.Shape = AntdUI.TShape.Round;
            ReservationTableDropdown1.ShowArrow = true;
            ReservationTableDropdown1.Size = new Size(111, 48);
            ReservationTableDropdown1.TabIndex = 6;
            ReservationTableDropdown1.Text = "更多操作\r\n";
            ReservationTableDropdown1.Trigger = AntdUI.Trigger.Hover;
            ReservationTableDropdown1.Type = AntdUI.TTypeMini.Info;
            // 
            // ReservationTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(ReservationTableDropdown1);
            Controls.Add(ReservationTablePagination);
            Controls.Add(TableOfReservation);
            Location = new Point(225, 14);
            Name = "ReservationTableControl";
            Size = new Size(1000, 652);
            Load += ReservationTableControl_Load;
            ((System.ComponentModel.ISupportInitialize)bindReservation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table TableOfReservation;
        private BindingSource bindReservation;
        private AntdUI.Pagination ReservationTablePagination;
        private AntdUI.Dropdown ReservationTableDropdown1;
    }
}
