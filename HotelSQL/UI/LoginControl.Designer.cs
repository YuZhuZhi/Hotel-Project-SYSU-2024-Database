namespace HotelSQL.UI
{
    partial class LoginControl
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
            DatabaseParamPanel = new AntdUI.Panel();
            PasswordInput = new AntdUI.Input();
            PasswordLabel = new AntdUI.Label();
            UserLabel = new AntdUI.Label();
            UserInput = new AntdUI.Input();
            PortLabel = new AntdUI.Label();
            PortInput = new AntdUI.Input();
            DatabaseParamPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DatabaseParamPanel
            // 
            DatabaseParamPanel.Controls.Add(PasswordInput);
            DatabaseParamPanel.Controls.Add(PasswordLabel);
            DatabaseParamPanel.Controls.Add(UserLabel);
            DatabaseParamPanel.Controls.Add(UserInput);
            DatabaseParamPanel.Controls.Add(PortLabel);
            DatabaseParamPanel.Controls.Add(PortInput);
            DatabaseParamPanel.Location = new Point(0, 0);
            DatabaseParamPanel.Name = "DatabaseParamPanel";
            DatabaseParamPanel.Size = new Size(560, 200);
            DatabaseParamPanel.TabIndex = 1;
            DatabaseParamPanel.Text = "panel1";
            // 
            // PasswordInput
            // 
            PasswordInput.AllowClear = true;
            PasswordInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordInput.ForeColor = SystemColors.ButtonShadow;
            PasswordInput.Location = new Point(134, 133);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.Size = new Size(300, 50);
            PasswordInput.TabIndex = 9;
            PasswordInput.Text = "请输入密码，默认password";
            PasswordInput.Click += PasswordInput_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(45, 133);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(83, 50);
            PasswordLabel.TabIndex = 8;
            PasswordLabel.Text = "密码：";
            PasswordLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UserLabel
            // 
            UserLabel.BackColor = Color.Transparent;
            UserLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLabel.Location = new Point(45, 77);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(83, 50);
            UserLabel.TabIndex = 7;
            UserLabel.Text = "用户名：";
            UserLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UserInput
            // 
            UserInput.AllowClear = true;
            UserInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserInput.ForeColor = SystemColors.ButtonShadow;
            UserInput.Location = new Point(134, 77);
            UserInput.Name = "UserInput";
            UserInput.Size = new Size(300, 50);
            UserInput.TabIndex = 4;
            UserInput.Text = "请输入用户名，默认postgres";
            UserInput.Click += UserInput_Click;
            // 
            // PortLabel
            // 
            PortLabel.BackColor = Color.Transparent;
            PortLabel.Font = new Font("汉仪文黑-85W", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortLabel.Location = new Point(45, 21);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(83, 50);
            PortLabel.TabIndex = 3;
            PortLabel.Text = "端口号：";
            PortLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PortInput
            // 
            PortInput.AllowClear = true;
            PortInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortInput.ForeColor = SystemColors.ButtonShadow;
            PortInput.Location = new Point(134, 21);
            PortInput.Name = "PortInput";
            PortInput.Size = new Size(300, 50);
            PortInput.TabIndex = 0;
            PortInput.Text = "请输入端口号，默认5432";
            PortInput.Click += PortInput_Click;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DatabaseParamPanel);
            Name = "LoginControl";
            Size = new Size(560, 200);
            DatabaseParamPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel DatabaseParamPanel;
        private AntdUI.Label PasswordLabel;
        private AntdUI.Label UserLabel;
        private AntdUI.Input UserInput;
        private AntdUI.Label PortLabel;
        private AntdUI.Input PortInput;
        private AntdUI.Input PasswordInput;
    }
}
