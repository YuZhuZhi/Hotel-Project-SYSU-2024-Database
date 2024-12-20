namespace HotelSQL.UI
{
    partial class AddHotelControl
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
            HotelStarLabel = new AntdUI.Label();
            HotelNameLabel = new AntdUI.Label();
            HotelStarInputNumber = new AntdUI.InputNumber();
            HotelNameInput = new AntdUI.Input();
            HotelNOLabel = new AntdUI.Label();
            HotelNOInput = new AntdUI.Input();
            AddHotelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddHotelPanel
            // 
            AddHotelPanel.Controls.Add(HotelStarLabel);
            AddHotelPanel.Controls.Add(HotelNameLabel);
            AddHotelPanel.Controls.Add(HotelStarInputNumber);
            AddHotelPanel.Controls.Add(HotelNameInput);
            AddHotelPanel.Controls.Add(HotelNOLabel);
            AddHotelPanel.Controls.Add(HotelNOInput);
            AddHotelPanel.Location = new Point(0, 0);
            AddHotelPanel.Name = "AddHotelPanel";
            AddHotelPanel.Size = new Size(560, 200);
            AddHotelPanel.TabIndex = 0;
            AddHotelPanel.Text = "panel1";
            // 
            // HotelStarLabel
            // 
            HotelStarLabel.BackColor = Color.Transparent;
            HotelStarLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelStarLabel.Location = new Point(45, 133);
            HotelStarLabel.Name = "HotelStarLabel";
            HotelStarLabel.Size = new Size(83, 50);
            HotelStarLabel.TabIndex = 8;
            HotelStarLabel.Text = "酒店星级：";
            HotelStarLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HotelNameLabel
            // 
            HotelNameLabel.BackColor = Color.Transparent;
            HotelNameLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNameLabel.Location = new Point(45, 77);
            HotelNameLabel.Name = "HotelNameLabel";
            HotelNameLabel.Size = new Size(83, 50);
            HotelNameLabel.TabIndex = 7;
            HotelNameLabel.Text = "酒店名字：";
            HotelNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HotelStarInputNumber
            // 
            HotelStarInputNumber.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelStarInputNumber.Location = new Point(134, 133);
            HotelStarInputNumber.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            HotelStarInputNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            HotelStarInputNumber.Name = "HotelStarInputNumber";
            HotelStarInputNumber.Size = new Size(300, 50);
            HotelStarInputNumber.TabIndex = 6;
            HotelStarInputNumber.Text = "3";
            HotelStarInputNumber.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // HotelNameInput
            // 
            HotelNameInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNameInput.ForeColor = SystemColors.ButtonShadow;
            HotelNameInput.Location = new Point(134, 77);
            HotelNameInput.Name = "HotelNameInput";
            HotelNameInput.Size = new Size(300, 50);
            HotelNameInput.TabIndex = 4;
            HotelNameInput.Text = "请输入拼音";
            HotelNameInput.Click += HotelNameInput_Click;
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
            // AddHotelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddHotelPanel);
            Name = "AddHotelControl";
            Size = new Size(560, 200);
            AddHotelPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel AddHotelPanel;
        private AntdUI.Input HotelNOInput;
        private AntdUI.Label HotelNOLabel;
        private AntdUI.Input HotelNameInput;
        private AntdUI.InputNumber HotelStarInputNumber;
        private AntdUI.Label HotelStarLabel;
        private AntdUI.Label HotelNameLabel;
    }
}
