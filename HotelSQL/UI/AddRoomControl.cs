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
    public partial class AddRoomControl : UserControl
    {
        public AddRoomControl(int hotelNO, List<string> types)
        {
            InitializeComponent();
            HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = null;
            HotelNOInput.Text = hotelNO.ToString();
            HotelNOInput.Enabled = false;
            RoomTypeSelect.Items.AddRange(types.ToArray());
        }

        public AddRoomControl(int hotelNO, List<string> types, int roomNO, string type)
        {
            InitializeComponent();
            HotelNOInput.Font = RoomNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = RoomNOInput.ForeColor = null; 
            HotelNOInput.Text = hotelNO.ToString();
            HotelNOInput.Enabled = false;
            RoomNOInput.Text = roomNO.ToString();
            RoomTypeSelect.Items.AddRange(types.ToArray());
            RoomTypeSelect.Text = type;
        }

        public bool IsValid()
        {
            if (HotelNOInput.Text.Length != 5) return false;
            if (!int.TryParse(HotelNOInput.Text, out int _)) return false;
            if (!int.TryParse(RoomNOInput.Text, out int _)) return false;
            if (RoomTypeSelect.SelectedIndex == -1) return false;
            return true;
        }

        public (int hotelNO, int roomNO, string type) GetValues()
        {
            int hotelNO = 0, roomNO = 0;
            int.TryParse(HotelNOInput.Text, out hotelNO);
            int.TryParse(RoomNOInput.Text, out roomNO);
            return (hotelNO, roomNO, RoomTypeSelect.SelectedValue?.ToString());
        }

        private void HotelNOInput_Click(object sender, EventArgs e)
        {
            if (HotelNOInput.Text == "请输入五位数字") {
                HotelNOInput.Clear();
                HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                HotelNOInput.ForeColor = null;
            }
        }

        private void RoomNOInput_Click(object sender, EventArgs e)
        {
            if (RoomNOInput.Text == "请输入房间号") {
                RoomNOInput.Clear();
                RoomNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                RoomNOInput.ForeColor = null;
            }
        }

        private void RoomTypeSelect_TextChanged(object sender, EventArgs e)
        {
            RoomTypeSelect.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeSelect.ForeColor = null;
        }

        //private void RoomTypeSelect_Click(object sender, EventArgs e)
        //{
        //    if (RoomTypeSelect.Text == "请选择房间等级") {
        //        RoomTypeSelect.Clear();
        //        RoomTypeSelect.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //        RoomTypeSelect.ForeColor = null;
        //    }
        //}
    }
}
