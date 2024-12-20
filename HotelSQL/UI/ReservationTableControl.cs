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

        public void TableRefresh()
        {
            TableOfReservation.Binding((AntList<AntItem[]>)GetPageData(page, 20));
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
                    new AntItem("check", false),
                    new AntItem("orderno", table.Rows[i]["orderNO"]),
                    new AntItem("hotelno", table.Rows[i]["hotelNO"]),
                    new AntItem("roomno", table.Rows[i]["roomNO"]),
                    new AntItem("id", table.Rows[i]["ID"]),
                    new AntItem("date", ((DateTime)table.Rows[i]["date"]).ToString("yyyy-MM-dd")),
                    new AntItem("duration", ((TimeSpan)table.Rows[i]["duration"]).Days + "天"),
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
            TableRefresh();
        }

        private void ReservationTableControl_Load(object sender, EventArgs e)
        {
            TableOfReservation.Columns = new([
                new ColumnCheck("check"),
                new Column("orderno", "订单编号", ColumnAlign.Center) { SortOrder = true },
                new Column("hotelno", "酒店地址", ColumnAlign.Center),
                new Column("roomno", "房间号", ColumnAlign.Center),
                new Column("id", "预订人", ColumnAlign.Center),
                new Column("date", "预订时间", ColumnAlign.Center),
                new Column("duration", "入住时长", ColumnAlign.Center),
                ]);

            TableOfReservation.Binding((AntList<AntItem[]>)GetPageData(page, 20));
            ReservationTablePagination.Current = page;

        }

        private void ReservationTableDropdown_SelectedValueChanged(object sender, ObjectNEventArgs e)
        {
            switch (e.Value) {
                case "刷新":
                    TableRefresh();
                    break;

                case "撤销订单":
                    var table = (AntList<AntItem[]>)TableOfReservation.DataSource;
                    var removeConfig = new Modal.Config(this.FindForm(), "再次确认", "确定要移除这些订单吗？") {
                        Icon = TType.Warn,
                        Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OnOk = (removeRoomConfig) => {
                            for (int i = 0; i < table?.Count; i++) {
                                if ((bool)table[i][0].value) manager.ReserveCancle((int)table[i][4].value);
                            }
                            return true;
                        }
                    };
                    Modal.open(removeConfig);
                    TableRefresh();
                    break;
            }
        }
    }
}
