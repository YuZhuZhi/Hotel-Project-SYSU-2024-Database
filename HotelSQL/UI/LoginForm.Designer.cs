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
            HotelManagerLabel = new AntdUI.Label();
            LoginDescriptionLabel = new AntdUI.Label();
            WelcomLabel = new AntdUI.Label();
            LogInPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AccountLabel
            // 
            AccountLabel.BackColor = Color.Transparent;
            AccountLabel.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AccountLabel.ForeColor = SystemColors.GrayText;
            AccountLabel.Location = new Point(458, 172);
            AccountLabel.Name = "AccountLabel";
            AccountLabel.Size = new Size(84, 34);
            AccountLabel.TabIndex = 0;
            AccountLabel.Text = "账户：";
            AccountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLabel.ForeColor = Color.DimGray;
            PasswordLabel.Location = new Point(458, 256);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(84, 34);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "密码：";
            PasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogInButton
            // 
            LogInButton.Font = new Font("汉仪文黑-85W", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogInButton.Location = new Point(682, 348);
            LogInButton.Name = "LogInButton";
            LogInButton.Shape = AntdUI.TShape.Round;
            LogInButton.Size = new Size(134, 63);
            LogInButton.TabIndex = 2;
            LogInButton.Text = "登录";
            LogInButton.Type = AntdUI.TTypeMini.Primary;
            LogInButton.Click += LogInButton_Click;
            // 
            // AccountInput
            // 
            AccountInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AccountInput.ForeColor = SystemColors.ButtonShadow;
            AccountInput.Location = new Point(532, 165);
            AccountInput.Name = "AccountInput";
            AccountInput.Size = new Size(330, 50);
            AccountInput.TabIndex = 3;
            AccountInput.Text = "请输入账户名称";
            AccountInput.TextChanged += AccountInput_TextChanged;
            AccountInput.Click += AccountInput_Click;
            AccountInput.Enter += AccountInput_Enter;
            // 
            // PasswordInput
            // 
            PasswordInput.Font = new Font("汉仪文黑-85W", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordInput.ForeColor = SystemColors.ButtonShadow;
            PasswordInput.Location = new Point(532, 248);
            PasswordInput.Name = "PasswordInput";
            PasswordInput.Size = new Size(330, 50);
            PasswordInput.TabIndex = 4;
            PasswordInput.Text = "请输入密码";
            PasswordInput.TextChanged += PasswordInput_TextChanged;
            PasswordInput.Click += PasswordInput_Click;
            PasswordInput.Enter += PasswordInput_Enter;
            // 
            // ClearButton
            // 
            ClearButton.BorderWidth = 1F;
            ClearButton.DefaultBorderColor = SystemColors.ActiveBorder;
            ClearButton.Font = new Font("汉仪文黑-85W", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClearButton.ForeColor = Color.DarkGray;
            ClearButton.Location = new Point(519, 348);
            ClearButton.Name = "ClearButton";
            ClearButton.Shape = AntdUI.TShape.Round;
            ClearButton.Size = new Size(128, 63);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "清除";
            ClearButton.Click += ClearButton_Click;
            // 
            // LogInPanel
            // 
            LogInPanel.Back = Color.Transparent;
            LogInPanel.BackColor = Color.Transparent;
            LogInPanel.BackgroundImage = Properties.Resources.LoginPanelBackground;
            LogInPanel.BadgeBack = Color.Transparent;
            LogInPanel.BorderColor = Color.Aqua;
            LogInPanel.Controls.Add(HotelManagerLabel);
            LogInPanel.Controls.Add(LoginDescriptionLabel);
            LogInPanel.Controls.Add(WelcomLabel);
            LogInPanel.Controls.Add(ClearButton);
            LogInPanel.Controls.Add(PasswordInput);
            LogInPanel.Controls.Add(AccountInput);
            LogInPanel.Controls.Add(LogInButton);
            LogInPanel.Controls.Add(PasswordLabel);
            LogInPanel.Controls.Add(AccountLabel);
            LogInPanel.ForeColor = Color.Transparent;
            LogInPanel.HandCursor = Cursors.Default;
            LogInPanel.Location = new Point(148, 61);
            LogInPanel.Name = "LogInPanel";
            LogInPanel.padding = new Padding(10);
            LogInPanel.Radius = 10;
            LogInPanel.ShadowOpacityAnimation = true;
            LogInPanel.Size = new Size(938, 576);
            LogInPanel.TabIndex = 0;
            LogInPanel.Text = "panel1";
            // 
            // HotelManagerLabel
            // 
            HotelManagerLabel.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelManagerLabel.ForeColor = Color.White;
            HotelManagerLabel.Location = new Point(16, 17);
            HotelManagerLabel.Name = "HotelManagerLabel";
            HotelManagerLabel.Size = new Size(170, 23);
            HotelManagerLabel.TabIndex = 8;
            HotelManagerLabel.Text = "Hotel Manager";
            // 
            // LoginDescriptionLabel
            // 
            LoginDescriptionLabel.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginDescriptionLabel.ForeColor = Color.White;
            LoginDescriptionLabel.Location = new Point(67, 227);
            LoginDescriptionLabel.Name = "LoginDescriptionLabel";
            LoginDescriptionLabel.Size = new Size(274, 80);
            LoginDescriptionLabel.TabIndex = 7;
            LoginDescriptionLabel.Text = "Log in to manage your hotels, rooms and reservers.";
            LoginDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WelcomLabel
            // 
            WelcomLabel.Font = new Font("汉仪文黑-85W", 26.2499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomLabel.ForeColor = Color.White;
            WelcomLabel.Location = new Point(50, 137);
            WelcomLabel.Name = "WelcomLabel";
            WelcomLabel.Size = new Size(345, 129);
            WelcomLabel.TabIndex = 6;
            WelcomLabel.Text = "Welcome Back！";
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
        private AntdUI.Label LoginDescriptionLabel;
        private AntdUI.Label WelcomLabel;
        private AntdUI.Label HotelManagerLabel;
    }
}