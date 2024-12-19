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
    public partial class ReserveControl : UserControl
    {
        public ReserveControl()
        {
            InitializeComponent();
        }

        public ReserveControl(int hotelNO, int roomNO)
        {
            InitializeComponent();
            HotelNOInput.Font      = RoomNOInput.Font      = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = RoomNOInput.ForeColor = null;
            HotelNOInput.Enabled   = RoomNOInput.Enabled   = false;
            HotelNOInput.ReadOnly  = RoomNOInput.ReadOnly  = true;
            HotelNOInput.Text = hotelNO.ToString();
            RoomNOInput.Text = roomNO.ToString();
        }

        public ReserveControl(int hotelNO, int roomNO, int ID, DateTime date, int duration)
        {
            InitializeComponent();
            HotelNOInput.Font = RoomNOInput.Font = IDInput.Font = DatePicker.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotelNOInput.ForeColor = RoomNOInput.ForeColor = IDInput.ForeColor = DatePicker.ForeColor = null;
            HotelNOInput.Enabled = RoomNOInput.Enabled = IDInput.Enabled = DatePicker.Enabled = DurationInputNumber.Enabled = false;
            HotelNOInput.ReadOnly = RoomNOInput.ReadOnly = IDInput.ReadOnly = DatePicker.ReadOnly = DurationInputNumber.ReadOnly = true;
            HotelNOInput.Text = hotelNO.ToString();
            RoomNOInput.Text = roomNO.ToString();
            IDInput.Text = ID.ToString();
            DatePicker.Value = date;
            DurationInputNumber.Value = duration;
        }

        public bool IsValid()
        {
            if (HotelNOInput.Text.Length != 5) return false;
            if (!int.TryParse(HotelNOInput.Text, out int _)) return false;
            if (RoomNOInput.Text == "请输入房间号") return false;
            if (!int.TryParse(RoomNOInput.Text, out int _)) return false;
            if (IDInput.Text == "请输入身份证号") return false;
            if (!int.TryParse(IDInput.Text, out int _)) return false;
            if (DatePicker.Value is null) return false;
            return true;
        }

        public (int hotelNO, int roomNO, int ID,
            DateTime date, int duration) GetValues()
        {
            int hotelNO = 0, roomNO = 0, ID = 0;
            int.TryParse(HotelNOInput.Text, out hotelNO);
            int.TryParse(RoomNOInput.Text, out roomNO);
            int.TryParse(IDInput.Text, out ID);
            return (hotelNO, roomNO, ID, (DateTime)DatePicker.Value, (int)DurationInputNumber.Value);
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

        private void IDInput_Click(object sender, EventArgs e)
        {
            if (IDInput.Text == "请输入身份证号") {
                IDInput.Clear();
                IDInput.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                IDInput.ForeColor = null;
            }
        }

        private void DatePicker_Click(object sender, EventArgs e)
        {
            if (DatePicker.Text == "请选择入住日期") {
                DatePicker.Font = new Font("汉仪文黑-85W", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                IDInput.ForeColor = null;
            }
        }

        private void DatePicker_ValueChanged(object sender, AntdUI.DateTimeNEventArgs e)
        {
            DatePicker.ForeColor = null;
        }
    }
}
