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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelSQL.UI
{
    public partial class RoomTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;
        private int page = 1;
        private int hotelNO;

        /*----------------------------Public Function----------------------------------------*/

        public RoomTableControl(Manager manager, int hotelNO)
        {
            InitializeComponent();
            this.manager = manager;
            this.hotelNO = hotelNO;
        }

        /*----------------------------Private Function----------------------------------------*/

        private object GetPageData(int current, int pageSize)
        {
            var list = new AntList<AntItem[]>(pageSize);
            var table = manager.GetHotelRooms(hotelNO);
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);
            RoomTablePagination.Total = table.Rows.Count;

            for (int i = start; i < end; i++) {
                bool isReserved = (bool)table.Rows[i]["isReserved"];
                var state = isReserved ? TState.Error : TState.Success;
                string strState = isReserved ? "已预订" : "未预订";
                string reserveBtnText = isReserved ? "取消预订" : "预订";

                list.Add(new AntItem[] {
                    new AntItem("check", false),
                    new AntItem("hotelno", table.Rows[i]["hotelNO"]),
                    new AntItem("roomno", table.Rows[i]["roomNO"]),
                    new AntItem("type", table.Rows[i]["type"]),
                    new AntItem("price", table.Rows[i]["price"]),
                    new AntItem("isreserved", new CellBadge(state, strState)),
                    new AntItem("operate", new CellLink[] {
                        new CellButton($"EditRoom{i}", "编辑信息") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"Reserve{i}", reserveBtnText) { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"ViewReservation{i}", "查看订单") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F, Enabled = isReserved },

                    })
                });
            }

            return list;
        }

        private void TableRefresh()
        {
            TableOfRoom.Binding((AntList<AntItem[]>)GetPageData(page, 20));
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

        private void RoomTablePagination_ValueChanged(object sender, PagePageEventArgs e)
        {
            page = e.Current;
            TableRefresh();
        }

        private void RoomTableControl_Load(object sender, EventArgs e)
        {
            TableOfRoom.Columns = new([
                new ColumnCheck("check"),
                new Column("hotelno", "酒店地址", ColumnAlign.Center),
                new Column("roomno", "房间号", ColumnAlign.Center) { SortOrder = true },
                new Column("type", "房间等级", ColumnAlign.Center),
                new Column("price", "单晚价格", ColumnAlign.Center),
                new Column("isreserved", "预订状态", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            TableOfRoom.Binding((AntList<AntItem[]>)GetPageData(page, 20));

            #region pagination

            RoomTablePagination.Current = page;

            #endregion

        }

        private void TableOfRoom_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Btn.Id.Contains("Reserve")) {  // Reserve the room.
                int hotelNO = (int)TableOfRoom[e.RowIndex - 1]?["hotelno"];
                int roomNO = (int)TableOfRoom[e.RowIndex - 1]?["roomno"];
                var control = new ReserveControl(hotelNO, roomNO);
                var config = new Modal.Config(this.FindForm(), "输入预订信息", control) {
                    Icon = TType.Info,
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (config) => {
                        #region Define Notification
                        var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                            FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            AutoClose = 3,
                            ShowInWindow = true,
                        };
                        #endregion
                        if (control.IsValid()) {
                            var (hotelNO, roomNO, ID, date, duration) = control.GetValues();
                            int addNum = manager.ReserveRoom(ID, hotelNO, roomNO, date, duration);
                            return (addNum > 0);
                        }
                        Notification.open(noteConfig);
                        return false;
                    }
                };
                Modal.open(config);
                TableRefresh();
            }
            else if (e.Btn.Id.Contains("Edit")) {  // Edit the room's info.
                var control = new AddRoomControl(hotelNO, manager.GetRoomType(hotelNO),
                    (int)TableOfRoom[e.RowIndex - 1]["roomno"], (string)TableOfRoom[e.RowIndex - 1]["type"]);
                var config = new Modal.Config(this.FindForm(), "修改房间信息", control) {
                    Icon = TType.Info,
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (config) => {
                        #region Define Notification
                        var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                            FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            AutoClose = 3,
                            ShowInWindow = true,
                        };
                        #endregion
                        if (control.IsValid()) {
                            var (hotelNO, roomNO, type) = control.GetValues();
                            int change = manager.SetRoomType(hotelNO, roomNO, type);
                            if (change > 0) return true;
                        }
                        Notification.open(noteConfig);
                        return false;
                    }
                };
                Modal.open(config);
                TableRefresh();
            }
            else if (e.Btn.Id.Contains("View")) {  // View the room's Reservation.
                int hotelNO = (int)TableOfRoom[e.RowIndex - 1]?["hotelno"];
                int roomNO = (int)TableOfRoom[e.RowIndex - 1]?["roomno"];
                int ID = (int)manager.Reservation.Table.Select($"hotelNO={hotelNO} AND roomNO={roomNO}")[0]["ID"];
                DataRow dataRow = manager.Reserver.GetRow(ID);
                DateTime date = (DateTime)dataRow["date"];
                int duration = ((TimeSpan)dataRow["duration"]).Days;

                var control = new ReserveControl(hotelNO, roomNO, ID, date, duration);
                var config = new Modal.Config(this.FindForm(), "预订信息", control) {
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (config) => { return true; }
                };
                Modal.open(config);
            }
        }

        private void RoomTableDropdown1_SelectedValueChanged(object sender, ObjectNEventArgs e)
        {
            switch (e.Value) {
                case "刷新":
                    TableRefresh();
                    break;

                case "新增房间":
                    var control = new AddRoomControl(hotelNO, manager.GetRoomType(hotelNO));
                    var config = new Modal.Config(this.FindForm(), "新增房间", control) {
                        Icon = TType.Info,
                        Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OnOk = (config) => {
                            #region Define Notification
                            var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                                FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                AutoClose = 3,
                                ShowInWindow = true,
                            };
                            #endregion
                            if (control.IsValid()) {
                                var (hotelNO, roomNO, type) = control.GetValues();
                                int addNum = manager.AddRoom(hotelNO, roomNO, type);
                                if (addNum > 0) return true;
                            }
                            Notification.open(noteConfig);
                            return false;
                        }
                    };
                    Modal.open(config);
                    TableRefresh();
                    break;

                case "移除房间":
                    var table = (AntList<AntItem[]>)TableOfRoom.DataSource;
                    config = new Modal.Config(this.FindForm(), "再次确认", "确定要移除这些房间吗？") {
                        Icon = TType.Warn,
                        Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OnOk = (config) => {
                            for (int i = 0; i < table?.Count; i++) {
                                if ((bool)table[i][0].value) manager.RemoveRoom(hotelNO, (int)table[i][2].value);
                            }
                            return true;
                        }
                    };
                    Modal.open(config);

                    TableRefresh();
                    break;

                case "查看房间类型信息":

                    break;

            }
        }
    }
}
