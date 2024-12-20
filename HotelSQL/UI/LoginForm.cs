using AntdUI;
using HotelSQL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSQL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AccountInput_Click(object sender, EventArgs e)
        {
            if (AccountInput.Text == "请输入账户名称") {
                AccountInput.Clear();
                AccountInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                AccountInput.ForeColor = null;
            }
        }

        private void PasswordInput_Click(object sender, EventArgs e)
        {
            if (PasswordInput.Text == "请输入密码") {
                PasswordInput.Clear();
                PasswordInput.ForeColor = null;
                PasswordInput.UseSystemPasswordChar = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            AccountInput.Clear();
            AccountInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AccountInput.ForeColor = null;

            PasswordInput.Clear();
            PasswordInput.ForeColor = null;
            PasswordInput.UseSystemPasswordChar = true;

            AntdUI.Message.info(this, "已清除输入！", autoClose: 2);
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (((AccountInput.Text == "") && (PasswordInput.Text == "")) ||
                ((AccountInput.Text == "DataBase") && (PasswordInput.Text == "password"))) {
                AntdUI.Message.success(this, "登录成功！", autoClose: 2);
                this.Hide();

                Form manageForm = new ManageForm();
                manageForm.ShowDialog();
                this.Close();
            }
            else {
                ClearButton_Click(sender, e);
                AntdUI.Message.error(this, "账户名或密码有误！", autoClose: 2);
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Enter:
                    LogInButton_Click(sender, e);
                    ClearButton_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.PageDown:
                    PasswordInput.Focus();
                    break;
                case Keys.PageUp:
                    AccountInput.Focus();
                    break;
                case Keys.Alt:
                    ClearButton_Click(sender, e);
                    break;
            }
        }

        private void AccountInput_Enter(object sender, EventArgs e)
        {
            AccountInput_Click(sender, e);
        }

        private void PasswordInput_Enter(object sender, EventArgs e)
        {
            PasswordInput_Click(sender, e);
        }

        private void AccountInput_TextChanged(object sender, EventArgs e)
        {
            if (AccountInput.Text == "DataBase") { AccountInput.Status = AntdUI.TType.Success; }
            else AccountInput.Status = AntdUI.TType.None;
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            if (PasswordInput.Text == "password") PasswordInput.Status = AntdUI.TType.Success;
            else PasswordInput.Status = AntdUI.TType.None;
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            var buttons = new FloatButton.ConfigBtn[] {
                new FloatButton.ConfigBtn("DatabaseParams") {
                    Tooltip = "数据库参数",
                    Type = TTypeMini.Default,
                    Icon = (Bitmap)Image.FromFile(@"..\..\..\Resources\DatabaseSetting.png"),
                    //Icon = Properties.Resources.DatabaseSetting.png
                }
            };

            var callback = (FloatButton.ConfigBtn btn) => {
                switch (btn.Name) {
                    case "DatabaseParams":

                        break;
                }
            };

            var floatButtonConfig = new FloatButton.Config(this, buttons, callback);
            FloatButton.open(floatButtonConfig);

        }
    }
}
