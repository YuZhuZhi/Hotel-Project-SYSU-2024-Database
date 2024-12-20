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
    public partial class AddRoomTypeControl : UserControl
    {
        public AddRoomTypeControl(int hotelNO)
        {
            InitializeComponent();
            HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = null;
            HotelNOInput.Text = hotelNO.ToString();
            HotelNOInput.Enabled = false;
        }

        public AddRoomTypeControl(int hotelNO, string type)
        {
            InitializeComponent();
            HotelNOInput.Font = RoomTypeInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = RoomTypeInput.ForeColor = null;
            HotelNOInput.Text = hotelNO.ToString();
            HotelNOInput.Enabled = false;
            RoomTypeInput.Text = type;
        }

        public bool IsValid()
        {
            if (HotelNOInput.Text.Length != 5) return false;
            if (!int.TryParse(HotelNOInput.Text, out int _)) return false;
            if (RoomTypeInput.Text == "请输入房间类型名称") return false;
            if (PriceInputNumber.Value < 0) return false;
            return true;
        }

        public (int hotelNO, string type, int price) GetValues()
        {
            int hotelNO = 0;
            int.TryParse(HotelNOInput.Text, out hotelNO);
            return (hotelNO, RoomTypeInput.Text.Trim(), (int)PriceInputNumber.Value);
        }

        private void HotelNOInput_Click(object sender, EventArgs e)
        {
            if (HotelNOInput.Text == "请输入五位数字") {
                HotelNOInput.Clear();
                HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                HotelNOInput.ForeColor = null;
            }
        }

        private void RoomTypeInput_Click(object sender, EventArgs e)
        {
            if (RoomTypeInput.Text == "请输入房间类型名称") {
                RoomTypeInput.Clear();
                RoomTypeInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                RoomTypeInput.ForeColor = null;
            }
        }
    }
}
