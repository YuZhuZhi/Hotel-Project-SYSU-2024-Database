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
    public partial class RoomTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;
        private int hotelNO;

        /*----------------------------Public Function----------------------------------------*/

        public RoomTableControl(Manager manager, int hotelNO)
        {
            InitializeComponent();
            this.manager = manager;
            this.hotelNO = hotelNO;
            TableOfRoom.Columns = new([
                new Column("hotelno", "酒店地址", ColumnAlign.Center),
                new Column("roomno", "房间号", ColumnAlign.Center) { SortOrder = true },
                new Column("type", "房间等级", ColumnAlign.Center),
                new Column("price", "单晚价格", ColumnAlign.Center),
                new Column("isreserved", "预订状态", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            bindRoom.DataSource = GetPageData(1, 100);  // Bind hotel.Table to bindHotel (To allow changes show immediately).
            TableOfRoom.DataSource = bindRoom;

        }

        /*----------------------------Private Function----------------------------------------*/

        private object GetPageData(int current, int pageSize)
        {
            var list = new List<AntItem[]>(pageSize);
            var table = manager.GetHotelRooms(hotelNO);
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);

            for (int i = start; i < end; i++) {
                bool isReserved = (bool)table.Rows[i]["isReserved"];
                var state = isReserved ? TState.Error : TState.Success;
                string strState = isReserved ? "已预订" : "未预订";
                string reserveBtnText = isReserved ? "取消预订" : "预订";

                list.Add(new AntItem[] {
                    new AntItem("hotelno", table.Rows[i]["hotelNO"]),
                    new AntItem("roomno", table.Rows[i]["roomNO"]),
                    new AntItem("type", table.Rows[i]["type"]),
                    new AntItem("price", table.Rows[i]["price"]),
                    new AntItem("isreserved", new CellBadge(state, strState)),
                    new AntItem("operate", new CellLink[] {
                        new CellButton($"EditRoom{i}", "编辑信息") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"Reserve{i}", reserveBtnText) { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"ViewReservation{i}", "查看订单") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },

                    })
                });
            }

            return list;
        }

        private AntdUI.Table.CellStyleInfo TableOfRoom_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
        {
            if (e.RowIndex % 2 == 0) {
                return new Table.CellStyleInfo
                {
                    BackColor = Style.Db.ErrorBg,
                    //ForeColor = Style.Db.Error
                };
            }
            return null;
        }
    }
}
