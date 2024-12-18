namespace HotelSQL.UI
{
    partial class HotelTableControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private BindingSource bindHotel;
        private AntdUI.Table TableOfHotel;

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
            TableOfHotel = new AntdUI.Table();
            bindHotel = new BindingSource(components);
            HotelTablePagination = new AntdUI.Pagination();
            ((System.ComponentModel.ISupportInitialize)bindHotel).BeginInit();
            SuspendLayout();
            // 
            // TableOfHotel
            // 
            TableOfHotel.Bordered = true;
            TableOfHotel.Empty = false;
            TableOfHotel.EmptyHeader = true;
            TableOfHotel.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TableOfHotel.Location = new Point(30, 20);
            TableOfHotel.Name = "TableOfHotel";
            TableOfHotel.Size = new Size(935, 575);
            TableOfHotel.TabIndex = 0;
            TableOfHotel.Text = "酒店列表";
            TableOfHotel.CellButtonClick += TableOfHotel_CellButtonClick;
            TableOfHotel.SetRowStyle += TableOfHotel_SetRowStyle;
            // 
            // HotelTablePagination
            // 
            HotelTablePagination.Current = 0;
            HotelTablePagination.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelTablePagination.ForeColor = Color.Silver;
            HotelTablePagination.Location = new Point(275, 600);
            HotelTablePagination.Name = "HotelTablePagination";
            HotelTablePagination.PageSize = 20;
            HotelTablePagination.Size = new Size(450, 50);
            HotelTablePagination.TabIndex = 3;
            HotelTablePagination.Text = "RoomTablePagination";
            HotelTablePagination.TextDesc = "";
            HotelTablePagination.Total = 100;
            HotelTablePagination.ValueChanged += HotelTablePagination_ValueChanged;
            // 
            // HotelTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(HotelTablePagination);
            Controls.Add(TableOfHotel);
            Location = new Point(225, 25);
            Name = "HotelTableControl";
            Size = new Size(1000, 652);
            ((System.ComponentModel.ISupportInitialize)bindHotel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Pagination HotelTablePagination;
    }
}
