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
    public partial class AddHotelControl : UserControl
    {
        public AddHotelControl()
        {
            InitializeComponent();
        }

        public AddHotelControl(int hotelNO, string hotelName, int hotelStar)
        {
            InitializeComponent();
            HotelNameInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNameInput.ForeColor = null;
            HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = null;
            HotelNOInput.Text = hotelNO.ToString();
            HotelNameInput.Text = hotelName;
            HotelStarInputNumber.Text = hotelStar.ToString();
        }

        public bool IsValid()
        {
            if (HotelNOInput.Text.Length != 5) return false;
            if (!int.TryParse(HotelNOInput.Text, out int temp)) return false;
            if (HotelNameInput.Text == "请输入拼音") return false;
            int star = int.Parse(HotelStarInputNumber.Text);
            if (star <= 0 || star > 5) return false;
            return true;
        }

        public (int hotelNO, string name, int star) GetValues()
        {
            int hotelNO = 0, star = 0;
            int.TryParse(HotelNOInput.Text, out hotelNO);
            int.TryParse(HotelStarInputNumber.Text, out star);
            return (hotelNO, HotelNameInput.Text, star);
        }

        private void HotelNameInput_Click(object sender, EventArgs e)
        {
            if (HotelNameInput.Text == "请输入拼音") {
                HotelNameInput.Clear();
                HotelNameInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                HotelNameInput.ForeColor = null;
            }
        }

        private void HotelNOInput_Click(object sender, EventArgs e)
        {
            if (HotelNOInput.Text == "请输入五位数字") {
                HotelNOInput.Clear();
                HotelNOInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                HotelNOInput.ForeColor = null;
            }
        }
    }
}
