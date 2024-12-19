using AntdUI;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AntdUI.FloatButton;

namespace HotelSQL.UI
{
    public partial class HotelTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;
        private int page = 1;

        /*----------------------------Public Event----------------------------------------*/

        public event EventHandler<List<string>> TableButtonClicked;
        // The params should be [operateType, hotelNO]

        /*----------------------------Public Function----------------------------------------*/

        public HotelTableControl(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        /*----------------------------Private Function----------------------------------------*/

        private object GetPageData(int current, int pageSize)
        {
            var list = new AntList<AntItem[]>(pageSize);
            var table = manager.Hotel.Table;
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);
            HotelTablePagination.Total = table.Rows.Count;

            for (int i = start; i < end; i++) {
                list.Add(new AntItem[] {
                    new AntItem("check", false),
                    new AntItem("hotelno", table.Rows[i]["hotelNO"]),
                    new AntItem("name", table.Rows[i]["name"]),
                    new AntItem("star", table.Rows[i]["star"]),
                    new AntItem("operate", new CellLink[] {
                        new CellButton($"EditHotel{i}", "编辑信息") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"ViewHotelRoom{i}", "查看房间") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },
                        new CellButton($"ViewHotelOrder{i}", "查看订单") { Type = TTypeMini.Primary, Ghost = true, BorderWidth = 2F },

                    })
                });
            }

            return list;
        }

        private void TableRefresh()
        {
            TableOfHotel.Binding((AntList<AntItem[]>)GetPageData(page, 20));
        }

        private Table.CellStyleInfo? TableOfHotel_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
        {
            if (e.RowIndex % 2 == 0) {
                return new Table.CellStyleInfo {
                    BackColor = ColorTranslator.FromHtml("#edf6f9"),
                };
            }
            return null;
        }

        private void TableOfHotel_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Btn.Id.Contains("Room")) {
                List<string> args = new() { "房间管理" };
                args.Add(TableOfHotel[e.RowIndex - 1]?["hotelno"]?.ToString());
                TableButtonClicked?.Invoke(this, args);
                return;
            }
            else if (e.Btn.Id.Contains("Order")) {
                List<string> args = new() { "订单管理" };
                args.Add(TableOfHotel[e.RowIndex - 1]?["hotelno"]?.ToString());
                TableButtonClicked?.Invoke(this, args);
                return;
            }
            else if (e.Btn.Id.Contains("Edit")) {
                int presentHotelNO = (int)TableOfHotel[e.RowIndex - 1]?["hotelno"];
                var control = new AddHotelControl(
                    hotelNO: (int)TableOfHotel[e.RowIndex - 1]?["hotelno"],
                    hotelName: TableOfHotel[e.RowIndex - 1]?["name"].ToString(),
                    hotelStar: (int)TableOfHotel[e.RowIndex - 1]?["star"]
                    );
                var config = new Modal.Config(this.FindForm(), "修改酒店信息", control) {
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
                            var (hotelNO, name, star) = control.GetValues();
                            bool success = manager.SetHotelAddress(presentHotelNO, hotelNO);
                            success &= manager.SetHotelName(presentHotelNO, name);
                            success &= manager.SetHotelStar(presentHotelNO, star);
                            if (!success) Notification.open(noteConfig);
                            return success;
                        }
                        Notification.open(noteConfig);
                        return false;
                    }
                };
                Modal.open(config);
                TableRefresh();
            }

        }

        private void HotelTablePagination_ValueChanged(object sender, PagePageEventArgs e)
        {
            page = e.Current;
            TableRefresh();
        }

        private void HotelTableControl_Load(object sender, EventArgs e)
        {
            TableOfHotel.Columns = new([
                new ColumnCheck("check"),
                new Column("hotelno", "酒店地址", ColumnAlign.Center) { SortOrder = true },
                new Column("name", "酒店名字", ColumnAlign.Center),
                new Column("star", "酒店星级", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            TableOfHotel.Binding((AntList<AntItem[]>)GetPageData(page, 20));

            HotelTablePagination.Current = page;

        }

        private void HotelTableDropdown_SelectedValueChanged(object sender, ObjectNEventArgs e)
        {
            switch (e.Value) {
                case "刷新":
                    TableRefresh();
                    break;

                case "新增酒店":
                    var control = new AddHotelControl();
                    var config = new Modal.Config(this.FindForm(), "新增酒店", control) {
                        Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OkFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        CancelFont = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        OnOk = (config) => {
                            if (control.IsValid()) {
                                var (hotelNO, name, star) = control.GetValues();
                                int addNum = manager.AddHotel(hotelNO, name, star);
                                if (addNum > 0) return true;
                            }
                            #region Show Notification
                            var noteConfig = new Notification.Config(this.FindForm(), "Alert", "非法数据！", TType.Error, TAlignFrom.Top) {
                                FontTitle = new Font("汉仪文黑-85W", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Font = new Font("汉仪文黑-85W", 15F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                AutoClose = 3,
                                ShowInWindow = true,
                            };
                            Notification.open(noteConfig);
                            #endregion
                            return false;
                        }
                    };
                    Modal.open(config);
                    TableRefresh();
                    break;

                case "移除酒店":
                    var table = (AntList<AntItem[]>)TableOfHotel.DataSource;
                    for (int i = 0; i < table?.Count; i++) {
                        if ((bool)table[i][0].value) manager.RemoveHotel((int)table[i][1].value);
                    }
                    TableRefresh();
                    break;

                default:
                    Console.WriteLine(e.Value);
                    break;
            }
                
        }
    }
}
