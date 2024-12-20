namespace HotelSQL.UI
{
    partial class AddRoomTypeControl
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
            AddHotelPanel = new AntdUI.Panel();
            PriceInputNumber = new AntdUI.InputNumber();
            RoomTypeInput = new AntdUI.Input();
            RoomTypeLabel = new AntdUI.Label();
            PriceLabel = new AntdUI.Label();
            HotelNOLabel = new AntdUI.Label();
            HotelNOInput = new AntdUI.Input();
            AddHotelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddHotelPanel
            // 
            AddHotelPanel.Controls.Add(PriceInputNumber);
            AddHotelPanel.Controls.Add(RoomTypeInput);
            AddHotelPanel.Controls.Add(RoomTypeLabel);
            AddHotelPanel.Controls.Add(PriceLabel);
            AddHotelPanel.Controls.Add(HotelNOLabel);
            AddHotelPanel.Controls.Add(HotelNOInput);
            AddHotelPanel.Location = new Point(0, 0);
            AddHotelPanel.Name = "AddHotelPanel";
            AddHotelPanel.Size = new Size(560, 200);
            AddHotelPanel.TabIndex = 2;
            AddHotelPanel.Text = "panel1";
            // 
            // PriceInputNumber
            // 
            PriceInputNumber.Font = new Font("汉仪文黑-85W", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PriceInputNumber.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            PriceInputNumber.Location = new Point(134, 133);
            PriceInputNumber.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            PriceInputNumber.Name = "PriceInputNumber";
            PriceInputNumber.Size = new Size(300, 50);
            PriceInputNumber.TabIndex = 10;
            PriceInputNumber.Text = "500";
            PriceInputNumber.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // RoomTypeInput
            // 
            RoomTypeInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeInput.ForeColor = SystemColors.ButtonShadow;
            RoomTypeInput.Location = new Point(134, 77);
            RoomTypeInput.Name = "RoomTypeInput";
            RoomTypeInput.Size = new Size(300, 50);
            RoomTypeInput.TabIndex = 9;
            RoomTypeInput.Text = "请输入房间类型名称";
            RoomTypeInput.Click += RoomTypeInput_Click;
            // 
            // RoomTypeLabel
            // 
            RoomTypeLabel.BackColor = Color.Transparent;
            RoomTypeLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeLabel.Location = new Point(45, 77);
            RoomTypeLabel.Name = "RoomTypeLabel";
            RoomTypeLabel.Size = new Size(83, 50);
            RoomTypeLabel.TabIndex = 8;
            RoomTypeLabel.Text = "房间等级：";
            RoomTypeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PriceLabel
            // 
            PriceLabel.BackColor = Color.Transparent;
            PriceLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PriceLabel.Location = new Point(45, 133);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(83, 50);
            PriceLabel.TabIndex = 7;
            PriceLabel.Text = "单晚价格：";
            PriceLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HotelNOLabel
            // 
            HotelNOLabel.BackColor = Color.Transparent;
            HotelNOLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOLabel.Location = new Point(45, 21);
            HotelNOLabel.Name = "HotelNOLabel";
            HotelNOLabel.Size = new Size(83, 50);
            HotelNOLabel.TabIndex = 3;
            HotelNOLabel.Text = "酒店地址：";
            HotelNOLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HotelNOInput
            // 
            HotelNOInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = SystemColors.ButtonShadow;
            HotelNOInput.Location = new Point(134, 21);
            HotelNOInput.Name = "HotelNOInput";
            HotelNOInput.Size = new Size(300, 50);
            HotelNOInput.TabIndex = 0;
            HotelNOInput.Text = "请输入五位数字";
            HotelNOInput.Click += HotelNOInput_Click;
            // 
            // AddRoomTypeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddHotelPanel);
            Name = "AddRoomTypeControl";
            Size = new Size(560, 200);
            AddHotelPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel AddHotelPanel;
        private AntdUI.Label RoomTypeLabel;
        private AntdUI.Label PriceLabel;
        private AntdUI.Label HotelNOLabel;
        private AntdUI.Input HotelNOInput;
        private AntdUI.InputNumber PriceInputNumber;
        private AntdUI.Input RoomTypeInput;
    }
}
