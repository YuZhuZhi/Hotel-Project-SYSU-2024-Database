using AntdUI;
using HotelSQL.HotelManage;
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
    public partial class ReservationTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;
        private int page = 1;
        private int hotelNO;

        /*----------------------------Public Function----------------------------------------*/

        public ReservationTableControl(Manager manager, int hotelNO)
        {
            InitializeComponent();
            this.manager = manager;
            this.hotelNO = hotelNO;
        }

        /*----------------------------Private Function----------------------------------------*/

        private object GetPageData(int current, int pageSize)
        {
            var list = new AntList<AntItem[]>(pageSize);
            var table = manager.GetHotelReservations(hotelNO);
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);
            ReservationTablePagination.Total = table.Rows.Count;

            for (int i = start; i < end; i++) {
                list.Add(new AntItem[] {
                    new AntItem("orderno", table.Rows[i]["orderNO"]),
                    new AntItem("hotelno", table.Rows[i]["hotelNO"]),
                    new AntItem("roomno", table.Rows[i]["roomNO"]),
                    new AntItem("id", table.Rows[i]["ID"]),
                    new AntItem("date", table.Rows[i]["date"]),
                    new AntItem("duration", table.Rows[i]["duration"]),
                    new AntItem("operate", new CellLink[] {
                        new CellButton($"EditReservation{i}", "编辑信息") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"Cancel{i}", "取消订单") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },

                    })
                });
            }

            return list;
        }

        private AntdUI.Table.CellStyleInfo? TableOfRoom_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
        {
            if (e.RowIndex % 2 == 0) {
                return new Table.CellStyleInfo {
                    BackColor = ColorTranslator.FromHtml("#edf6f9"),
                };
            }
            return null;
        }

        private void ReservationTablePagination_ValueChanged(object sender, PagePageEventArgs e)
        {
            page = e.Current;
            TableOfReservation.Binding((AntList<AntItem[]>)GetPageData(page, 20));
        }

        private void ReservationTableControl_Load(object sender, EventArgs e)
        {
            TableOfReservation.Columns = new([
                new Column("orderno", "订单编号", ColumnAlign.Center) { SortOrder = true },
                new Column("hotelno", "酒店地址", ColumnAlign.Center),
                new Column("roomno", "房间号", ColumnAlign.Center),
                new Column("id", "预订人", ColumnAlign.Center),
                new Column("date", "预订时间", ColumnAlign.Center),
                new Column("duration", "入住时长", ColumnAlign.Center),
                ]);

            //bindReservation.DataSource = GetPageData(page, 20);  // Bind hotel.Table to bindHotel (To allow changes show immediately).
            //TableOfReservation.DataSource = bindReservation;
            TableOfReservation.Binding((AntList<AntItem[]>)GetPageData(page, 20));
            ReservationTablePagination.Current = page;

        }
    }
}
