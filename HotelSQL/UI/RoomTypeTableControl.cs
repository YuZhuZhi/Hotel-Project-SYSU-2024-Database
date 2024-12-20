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
    public partial class RoomTypeTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;
        private int page = 1;
        private int hotelNO;

        /*----------------------------Public Function----------------------------------------*/


        public RoomTypeTableControl(Manager manager, int hotelNO)
        {
            InitializeComponent();
            this.manager = manager;
            this.hotelNO = hotelNO;
        }

        /*----------------------------Private Function----------------------------------------*/

        private void TableRefresh()
        {
            TableOfRoomType.Binding((AntList<AntItem[]>)GetPageData(page, 20));
        }

        private object GetPageData(int current, int pageSize)
        {
            var list = new AntList<AntItem[]>(pageSize);
            var table = manager.GetHotelRoomTypes(hotelNO);
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);
            RoomTypePagination.Total = table.Rows.Count;

            for (int i = start; i < end; i++) {
                string type = ((string)table.Rows[i]["type"]).Trim();
                list.Add(new AntItem[] {
                    new AntItem("check", false),
                    new AntItem("hotelno", hotelNO),
                    new AntItem("type", table.Rows[i]["type"]),
                    new AntItem("price", table.Rows[i]["price"]),
                    new AntItem("amount", table.Rows[i]["amount"]),
                    new AntItem("remain", manager.RoomRemain(hotelNO, type)),
                    new AntItem("operate", new CellLink[] {
                        new CellButton($"EditRoom{i}", "编辑信息") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                    })
                });
            }

            list.Add([new AntItem("operate", new CellButton($"AddRoom", "增添房间类型") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F })]);
            list.Add([new AntItem("operate", new CellButton($"RemoveRoom", "移除房间类型") { Type = TTypeMini.Error, Ghost = true, BorderWidth = 2F })]);
            list.Add([new AntItem("operate", new CellButton($"Refresh", "刷新") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F })]);

            return list;
        }

        private void RoomTypeTableControl_Load(object sender, EventArgs e)
        {
            TableOfRoomType.Columns = new([
                new ColumnCheck("check"),
                new Column("hotelno", "酒店地址", ColumnAlign.Center),
                new Column("type", "房间等级", ColumnAlign.Center),
                new Column("price", "单晚价格", ColumnAlign.Center),
                new Column("amount", "总房间数", ColumnAlign.Center),
                new Column("remain", "剩余房间数", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            TableOfRoomType.Binding((AntList<AntItem[]>)GetPageData(page, 20));

            #region pagination

            RoomTypePagination.Current = page;

            #endregion

        }

        private void RoomTypePagination_ValueChanged(object sender, PagePageEventArgs e)
        {
            page = e.Current;
            TableRefresh();
        }

        private AntdUI.Table.CellStyleInfo TableOfRoomType_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
        {
            if (e.RowIndex % 2 == 0) {
                return new Table.CellStyleInfo {
                    BackColor = ColorTranslator.FromHtml("#edf6f9"),
                };
            }
            return null;
        }

        private void TableOfRoomType_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Btn.Id.Contains("Refresh")) {
                TableRefresh();
                return;
            }

            else if (e.Btn.Id.Contains("Edit")) {
                var type = TableOfRoomType[e.RowIndex - 1]?["type"]?.ToString();
                var editControl = new AddRoomTypeControl(hotelNO, type);
                var editConfig = new AntdUI.Modal.Config(this.FindForm(), "编辑房间类型", editControl) {
                    Icon = TType.Info,
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (e) => {
                        #region Define Notification
                        var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                            FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            AutoClose = 3,
                            ShowInWindow = true,
                        };
                        #endregion
                        if (editControl.IsValid()) {
                            var (hotelNO, newType, price) = editControl.GetValues();
                            int change = manager.SetRoomTypePrice(hotelNO, type, price);
                            change = change + manager.SetRoomTypeName(hotelNO, type, newType);
                            if (change > 0) return true;
                        }
                        Notification.open(noteConfig);
                        return false;
                    }
                };
                Modal.open(editConfig);
            }

            else if (e.Btn.Id.Contains("Add")) {
                var addControl = new AddRoomTypeControl(hotelNO);
                var addConfig = new AntdUI.Modal.Config(this.FindForm(), "增添房间类型", addControl) {
                    Icon = TType.Info,
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (e) => {
                        #region Define Notification
                        var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                            FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                            AutoClose = 3,
                            ShowInWindow = true,
                        };
                        #endregion
                        if (addControl.IsValid()) {
                            var (hotelNO, type, price) = addControl.GetValues();
                            if (manager.AddRoomType(hotelNO, type, price, 0, 0) > 0) return true;
                        }
                        Notification.open(noteConfig);
                        return false;
                    }
                };
                Modal.open(addConfig);
            }

            else if (e.Btn.Id.Contains("Remove")) {
                var table = (AntList<AntItem[]>)TableOfRoomType.DataSource;
                var removeConfig = new Modal.Config(this.FindForm(), "再次确认", "确定要移除这些房间类型吗？") {
                    Icon = TType.Warn,
                    Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    OnOk = (removeConfig) => {
                        for (int i = 0; i < table?.Count - 3; i++) {
                            if ((bool)table[i][0].value) manager.RemoveRoomType((int)table[i][1].value, (string)table[i][2].value);
                        }
                        return true;
                    }
                };
                Modal.open(removeConfig);
            }
            TableRefresh();
        }
    }
}
