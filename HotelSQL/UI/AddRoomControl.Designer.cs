namespace HotelSQL.UI
{
    partial class AddRoomControl
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
            RoomTypeSelect = new AntdUI.Select();
            RoomTypeLabel = new AntdUI.Label();
            RoomNOLabel = new AntdUI.Label();
            RoomNOInput = new AntdUI.Input();
            HotelNOLabel = new AntdUI.Label();
            HotelNOInput = new AntdUI.Input();
            AddHotelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddHotelPanel
            // 
            AddHotelPanel.Controls.Add(RoomTypeSelect);
            AddHotelPanel.Controls.Add(RoomTypeLabel);
            AddHotelPanel.Controls.Add(RoomNOLabel);
            AddHotelPanel.Controls.Add(RoomNOInput);
            AddHotelPanel.Controls.Add(HotelNOLabel);
            AddHotelPanel.Controls.Add(HotelNOInput);
            AddHotelPanel.Location = new Point(0, 0);
            AddHotelPanel.Name = "AddHotelPanel";
            AddHotelPanel.Size = new Size(560, 200);
            AddHotelPanel.TabIndex = 1;
            AddHotelPanel.Text = "panel1";
            // 
            // RoomTypeSelect
            // 
            RoomTypeSelect.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeSelect.ForeColor = SystemColors.ButtonShadow;
            RoomTypeSelect.Location = new Point(134, 133);
            RoomTypeSelect.Name = "RoomTypeSelect";
            RoomTypeSelect.Size = new Size(300, 50);
            RoomTypeSelect.TabIndex = 9;
            RoomTypeSelect.Text = "请选择房间等级";
            RoomTypeSelect.TextChanged += RoomTypeSelect_TextChanged;
            // 
            // RoomTypeLabel
            // 
            RoomTypeLabel.BackColor = Color.Transparent;
            RoomTypeLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeLabel.Location = new Point(45, 133);
            RoomTypeLabel.Name = "RoomTypeLabel";
            RoomTypeLabel.Size = new Size(83, 50);
            RoomTypeLabel.TabIndex = 8;
            RoomTypeLabel.Text = "房间等级：";
            RoomTypeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RoomNOLabel
            // 
            RoomNOLabel.BackColor = Color.Transparent;
            RoomNOLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomNOLabel.Location = new Point(45, 77);
            RoomNOLabel.Name = "RoomNOLabel";
            RoomNOLabel.Size = new Size(83, 50);
            RoomNOLabel.TabIndex = 7;
            RoomNOLabel.Text = "房间号：";
            RoomNOLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RoomNOInput
            // 
            RoomNOInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomNOInput.ForeColor = SystemColors.ButtonShadow;
            RoomNOInput.Location = new Point(134, 77);
            RoomNOInput.Name = "RoomNOInput";
            RoomNOInput.Size = new Size(300, 50);
            RoomNOInput.TabIndex = 4;
            RoomNOInput.Text = "请输入房间号";
            RoomNOInput.Click += RoomNOInput_Click;
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
            // AddRoomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddHotelPanel);
            Name = "AddRoomControl";
            Size = new Size(560, 200);
            AddHotelPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel AddHotelPanel;
        private AntdUI.Label RoomTypeLabel;
        private AntdUI.Label RoomNOLabel;
        private AntdUI.Input RoomNOInput;
        private AntdUI.Label HotelNOLabel;
        private AntdUI.Input HotelNOInput;
        private AntdUI.Select RoomTypeSelect;
    }
}
