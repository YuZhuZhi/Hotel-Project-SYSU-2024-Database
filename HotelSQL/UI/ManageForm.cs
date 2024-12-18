using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;

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
            postgre = new(passWord: "wjy20040416");
            manager = new(postgre, true);
        }

        private void HotelMenu_SelectChanged(object sender, AntdUI.MenuSelectEventArgs e)
        {
            switch (e.Value.Text) {
                case "首页":
                    if (Controls.ContainsKey("HotelTableControl")) Controls.RemoveByKey("HotelTableControl");
                    if (Controls.ContainsKey("RoomTableControl")) Controls.RemoveByKey("RoomTableControl");

                    if (Controls.ContainsKey("CarouselPanel")) break;
                    else Controls.Add(CarouselPanel);
                    break;

                case "酒店管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");
                    if (Controls.ContainsKey("RoomTableControl")) Controls.RemoveByKey("RoomTableControl");

                    if (hotelTableControl is null) {
                        hotelTableControl = new HotelTableControl(manager);
                        Controls.Add(hotelTableControl);
                        hotelTableControl.TableButtonClicked += HotelMenu_HotelTableControlButtonClicked;
                    }
                    else Controls.Add(hotelTableControl);

                    break;

                case "房间管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");
                    if (Controls.ContainsKey("HotelTableControl")) Controls.RemoveByKey("HotelTableControl");
                    roomTableControl = new RoomTableControl(manager, presentViewHotelNO);
                    Controls.Add(roomTableControl);

                    break;

                case "订单管理":
                    if (Controls.ContainsKey("CarouselPanel")) Controls.RemoveByKey("CarouselPanel");
                    if (Controls.ContainsKey("HotelTableControl")) Controls.RemoveByKey("HotelTableControl");
                    if (Controls.ContainsKey("RoomTableControl")) Controls.RemoveByKey("RoomTableControl");


                    break;
            }
        }

        private void HotelMenu_HotelTableControlButtonClicked(object sender, List<string> e)
        {
            var args = new MenuSelectEventArgs(new MenuItem("房间管理"));
            if (int.TryParse(e[1], out presentViewHotelNO));
            else Console.WriteLine("酒店地址转换错误");
            HotelMenu_SelectChanged(sender, args);
        }

        /*----------------------------Public Member----------------------------------------*/

        

        /*----------------------------Private Member----------------------------------------*/

        private HotelTableControl? hotelTableControl;
        private RoomTableControl? roomTableControl;
        private Postgre postgre;
        private Manager manager;

        private int presentViewHotelNO = 10001;
    }
}
