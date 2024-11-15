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
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {

        }

        private void menu1_SelectChanged(object sender, AntdUI.MenuSelectEventArgs e)
        {
            switch (e.Value.Text) {
                case "首页":
                    if (Controls.ContainsKey("CarouselPanel")) break;
                    else Controls.Add(CarouselPanel);
                    break;
                case "酒店管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");

                    break;
                case "房间管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");
                    
                    break;
                case "订单管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");

                    break;
            }
        }
    }
}
