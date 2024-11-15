namespace HotelSQL
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AccountLabel = new AntdUI.Label();
            PasswordLabel = new AntdUI.Label();
            LogInButton = new AntdUI.Button();
            AccountInput = new AntdUI.Input();
            PasswordInput = new AntdUI.Input();
            ClearButton = new AntdUI.Button();
            LogInPanel = new AntdUI.Panel();
            LogInPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AccountLabel
            // 
            AccountLabel.BackColor = Color.Transparent;
            AccountLabel.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            AccountLabel.ForeColor = Color.GhostWhite;
            AccountLabel.Location = new Point(86, 153);
            AccountLabel.Name = "AccountLabel";
            AccountLabel.Shadow = 10;
            AccountLabel.Size = new Size(84, 34);
            AccountLabel.TabIndex = 0;
            AccountLabel.Text = "账户：";
            AccountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            PasswordLabel.ForeColor = Color.Ivory;
            PasswordLabel.Location = new Point(86, 209);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Shadow = 10;
            PasswordLabel.Size = new Size(84, 34);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "密码：";
            PasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogInButton
            // 
            LogInButton.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LogInButton.Location = new Point(319, 283);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(134, 63);
            LogInButton.TabIndex = 2;
            LogInButton.Text = "登录";
            LogInButton.Type = AntdUI.TTypeMini.Primary;
            LogInButton.Click += LogInButton_Click;
            // 
            // AccountInput
            // 
            AccountInput.ForeColor = SystemColors.ButtonShadow;
            AccountInput.Location = new Point(164, 153);
            AccountInput.Name = "AccountInput";
            AccountInput.Size = new Size(315, 34);
            AccountInput.TabIndex = 3;
            AccountInput.Text = "请输入账户名称";
            AccountInput.Click += AccountInput_Click;
            AccountInput.Enter += AccountInput_Enter;
            // 
            // PasswordInput
            // 
            PasswordInput.ForeColor = SystemColors.ButtonShadow;
            PasswordInput.Location = new Point(164, 209);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.Size = new Size(315, 34);
            PasswordInput.TabIndex = 4;
            PasswordInput.Text = "请输入密码";
            PasswordInput.Click += PasswordInput_Click;
            PasswordInput.Enter += PasswordInput_Enter;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ClearButton.ForeColor = Color.SlateGray;
            ClearButton.Location = new Point(153, 283);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(128, 63);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "清除";
            ClearButton.Click += ClearButton_Click;
            // 
            // LogInPanel
            // 
            LogInPanel.Back = Color.Transparent;
            LogInPanel.BackColor = Color.Transparent;
            LogInPanel.BackgroundImage = Properties.Resources.FrostedGlass;
            LogInPanel.BadgeBack = Color.Transparent;
            LogInPanel.BorderColor = Color.Aqua;
            LogInPanel.Controls.Add(ClearButton);
            LogInPanel.Controls.Add(PasswordInput);
            LogInPanel.Controls.Add(AccountInput);
            LogInPanel.Controls.Add(LogInButton);
            LogInPanel.Controls.Add(PasswordLabel);
            LogInPanel.Controls.Add(AccountLabel);
            LogInPanel.ForeColor = Color.Transparent;
            LogInPanel.HandCursor = Cursors.Default;
            LogInPanel.Location = new Point(345, 149);
            LogInPanel.Name = "LogInPanel";
            LogInPanel.padding = new Padding(10);
            LogInPanel.Radius = 10;
            LogInPanel.ShadowOpacityAnimation = true;
            LogInPanel.Size = new Size(567, 446);
            LogInPanel.TabIndex = 0;
            LogInPanel.Text = "panel1";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BackGround;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(LogInPanel);
            KeyPreview = true;
            Name = "LoginForm";
            Text = "酒店管理系统——登录页";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            LogInPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label AccountLabel;
        private AntdUI.Label PasswordLabel;
        private AntdUI.Button LogInButton;
        private AntdUI.Input AccountInput;
        private AntdUI.Input PasswordInput;
        private AntdUI.Button ClearButton;
        private AntdUI.Panel LogInPanel;
    }
}