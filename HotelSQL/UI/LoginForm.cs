using AntdUI;
using HotelSQL.HotelManage;
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
        /*---------------------------Private Member--------------------------------*/

        private FormFloatButton floatButton;

        private int port = 5432;
        private string userName = "postgres";
        private string password = "password";

        /*----------------------------Public Functions-----------------------------*/

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
                floatButton.Close();
                this.Hide();

                try {
                    Form manageForm = new ManageForm(port, userName, password);
                    manageForm.ShowDialog();
                } catch (Exception) {
                    this.Show();
                    var databaseConfig = new Modal.Config(this, "数据库连接失败", "请点击右下角检查数据库连接参数") {
                        Icon = TType.Warn,
                        Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OnOk = (config) => {
                            return true;
                        }
                    };
                    AntdUI.Modal.open(databaseConfig);
                    return;
                }
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
            SetFloatButton();
            SetFloatButton();
            floatButton.Show();
        }

        private void SetFloatButton()
        {
            var buttons = new FloatButton.ConfigBtn[] {
                new FloatButton.ConfigBtn("DatabaseParams") {
                    Tooltip = "设置数据库连接参数",
                    Type = TTypeMini.Default,
                    //Icon = (Bitmap)Image.FromFile(@"..\..\..\Resources\DatabaseSetting.png"),
                    Icon = Properties.Resources.DatabaseSetting
                }
            };

            var callback = (FloatButton.ConfigBtn btn) => {
                switch (btn.Name) {
                    case "DatabaseParams":
                        var loginControl = new LoginControl();
                        var setConfig = new Modal.Config(this, "设置数据库连接参数", loginControl) {
                            Icon = TType.Info,
                            Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            OnOk = (setConfig) => {
                                #region Define Notification
                                var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                                    FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    AutoClose = 3,
                                    ShowInWindow = true,
                                };
                                #endregion
                                if (loginControl.IsValid()) {
                                    (port, userName, password) = loginControl.GetValues();
                                    AntdUI.Message.success(this, "数据库连接参数设置成功！", autoClose: 2);
                                    return true;
                                }
                                Notification.open(noteConfig);
                                return false;
                            }
                        };
                        AntdUI.Modal.open(setConfig);
                        break;
                }
            };

            var floatButtonConfig = new FloatButton.Config(this, buttons, callback);
            floatButton = floatButtonConfig.open();
            //floatButton = FloatButton.open(floatButtonConfig);
        }
    }
}
