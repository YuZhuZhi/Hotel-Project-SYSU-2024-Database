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
            AccountInput.Clear();
            AccountInput.ForeColor = null;
        }

        private void PasswordInput_Click(object sender, EventArgs e)
        {
            PasswordInput.Clear();
            PasswordInput.ForeColor = null;
            PasswordInput.UseSystemPasswordChar = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            PasswordInput_Click(sender, e);
            AccountInput_Click(sender, e);
            AntdUI.Message.info(this, "已清除输入！", autoClose: 2);
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if ((AccountInput.Text == "") && (PasswordInput.Text == "")) {
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
    }
}
