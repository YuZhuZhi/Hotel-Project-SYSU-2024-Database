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
            panel1 = new AntdUI.Panel();
            input1 = new AntdUI.Input();
            input2 = new AntdUI.Input();
            input3 = new AntdUI.Input();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(input3);
            panel1.Controls.Add(input2);
            panel1.Controls.Add(input1);
            panel1.Location = new Point(38, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 224);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // input1
            // 
            input1.Location = new Point(96, 24);
            input1.Name = "input1";
            input1.Size = new Size(279, 49);
            input1.TabIndex = 0;
            input1.Text = "input1";
            // 
            // input2
            // 
            input2.Location = new Point(96, 89);
            input2.Name = "input2";
            input2.Size = new Size(279, 51);
            input2.TabIndex = 1;
            input2.Text = "input2";
            // 
            // input3
            // 
            input3.Location = new Point(96, 156);
            input3.Name = "input3";
            input3.Size = new Size(279, 50);
            input3.TabIndex = 2;
            input3.Text = "input3";
            // 
            // AddHotelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "AddHotelControl";
            Size = new Size(561, 265);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Input input3;
        private AntdUI.Input input2;
        private AntdUI.Input input1;
    }
}
