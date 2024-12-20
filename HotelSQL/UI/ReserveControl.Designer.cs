namespace HotelSQL.UI
{
    partial class ReserveControl
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
            DatePicker = new AntdUI.DatePicker();
            DurationInputNumber = new AntdUI.InputNumber();
            label2 = new AntdUI.Label();
            label1 = new AntdUI.Label();
            IDInput = new AntdUI.Input();
            HotelStarLabel = new AntdUI.Label();
            RoomNOLabel = new AntdUI.Label();
            RoomNOInput = new AntdUI.Input();
            HotelNOLabel = new AntdUI.Label();
            HotelNOInput = new AntdUI.Input();
            AddHotelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddHotelPanel
            // 
            AddHotelPanel.Controls.Add(DatePicker);
            AddHotelPanel.Controls.Add(DurationInputNumber);
            AddHotelPanel.Controls.Add(label2);
            AddHotelPanel.Controls.Add(label1);
            AddHotelPanel.Controls.Add(IDInput);
            AddHotelPanel.Controls.Add(HotelStarLabel);
            AddHotelPanel.Controls.Add(RoomNOLabel);
            AddHotelPanel.Controls.Add(RoomNOInput);
            AddHotelPanel.Controls.Add(HotelNOLabel);
            AddHotelPanel.Controls.Add(HotelNOInput);
            AddHotelPanel.Location = new Point(3, 3);
            AddHotelPanel.Name = "AddHotelPanel";
            AddHotelPanel.Size = new Size(537, 300);
            AddHotelPanel.TabIndex = 1;
            AddHotelPanel.Text = "panel1";
            // 
            // DatePicker
            // 
            DatePicker.DropDownArrow = true;
            DatePicker.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatePicker.ForeColor = SystemColors.ButtonShadow;
            DatePicker.Location = new Point(134, 189);
            DatePicker.Name = "DatePicker";
            DatePicker.Placement = AntdUI.TAlignFrom.TL;
            DatePicker.Size = new Size(300, 50);
            DatePicker.TabIndex = 13;
            DatePicker.Text = "请选择入住日期\r\n";
            DatePicker.ValueChanged += DatePicker_ValueChanged;
            DatePicker.Click += DatePicker_Click;
            // 
            // DurationInputNumber
            // 
            DurationInputNumber.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DurationInputNumber.Location = new Point(134, 245);
            DurationInputNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DurationInputNumber.Name = "DurationInputNumber";
            DurationInputNumber.Size = new Size(300, 50);
            DurationInputNumber.TabIndex = 12;
            DurationInputNumber.Text = "1";
            DurationInputNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 245);
            label2.Name = "label2";
            label2.Size = new Size(125, 50);
            label2.TabIndex = 11;
            label2.Text = "预定入住天数：";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 189);
            label1.Name = "label1";
            label1.Size = new Size(125, 50);
            label1.TabIndex = 10;
            label1.Text = "预定入住日期：";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // IDInput
            // 
            IDInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IDInput.ForeColor = SystemColors.ButtonShadow;
            IDInput.Location = new Point(134, 133);
            IDInput.Name = "IDInput";
            IDInput.Size = new Size(300, 50);
            IDInput.TabIndex = 9;
            IDInput.Text = "请输入身份证号";
            IDInput.Click += IDInput_Click;
            // 
            // HotelStarLabel
            // 
            HotelStarLabel.BackColor = Color.Transparent;
            HotelStarLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelStarLabel.Location = new Point(3, 133);
            HotelStarLabel.Name = "HotelStarLabel";
            HotelStarLabel.Size = new Size(125, 50);
            HotelStarLabel.TabIndex = 8;
            HotelStarLabel.Text = "预订人身份证：";
            HotelStarLabel.TextAlign = ContentAlignment.MiddleRight;
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
            // ReserveControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddHotelPanel);
            Name = "ReserveControl";
            Size = new Size(540, 300);
            AddHotelPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel AddHotelPanel;
        private AntdUI.Label HotelStarLabel;
        private AntdUI.Label RoomNOLabel;
        private AntdUI.Input RoomNOInput;
        private AntdUI.Label HotelNOLabel;
        private AntdUI.Input HotelNOInput;
        private AntdUI.Input IDInput;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private AntdUI.DatePicker DatePicker;
        private AntdUI.InputNumber DurationInputNumber;
    }
}
