using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSQL.UI
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        public bool IsValid()
        {
            if (PortInput.Text == "请输入端口号，默认5432") ;
            else if (!int.TryParse(PortInput.Text, out int _)) return false;
            if (UserInput.Text == "请输入用户名，默认postgres") ;
            else if (UserInput.Text.Length == 0) return false;
            return true;
        }

        public (int port, string user, string password) GetValues()
        {
            int port = 5432;
            if (PortInput.Text != "请输入端口号，默认5432") {
                int.TryParse(PortInput.Text, out port);
            }
            string userName = "postgres";
            if (UserInput.Text != "请输入用户名，默认postgres") {
                if (UserInput.Text.All(char.IsLetterOrDigit)) userName = UserInput.Text;
            }
            string password = "password";
            if (PasswordInput.Text != "请输入密码，默认password") {
                if (PasswordInput.Text.All(char.IsLetterOrDigit)) password = PasswordInput.Text;
            }
            return (port, userName.Trim(), password.Trim());
        }

        private void PortInput_Click(object sender, EventArgs e)
        {
            if (PortInput.Text == "请输入端口号，默认5432") {
                PortInput.Clear();
                PortInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                PortInput.ForeColor = null;
                PortInput.Text = "5432";
            }
        }

        private void UserInput_Click(object sender, EventArgs e)
        {
            if (UserInput.Text == "请输入用户名，默认postgres") {
                UserInput.Clear();
                UserInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                UserInput.ForeColor = null;
                UserInput.Text = "postgres";
            }
        }

        private void PasswordInput_Click(object sender, EventArgs e)
        {
            if (PasswordInput.Text == "请输入密码，默认password") {
                PasswordInput.Clear();
                PasswordInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                PasswordInput.ForeColor = null;
            }
        }
    }
}
