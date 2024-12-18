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

        private void SetFloatButton()
        {
            ConfigBtn[] btns = new ConfigBtn[] {
                new ConfigBtn("Button1", "按钮 1") {  },
                new ConfigBtn("Button2", "按钮 2")
            };

            // 定义按钮点击后的回调
            Action<ConfigBtn> buttonClickCallback = (btn) => {
                MessageBox.Show($"按钮 {btn.Name} 被点击!");
            };

            // 配置并打开悬浮按钮
            var config = FloatButton.config(this.FindForm(), btns, buttonClickCallback);
            FloatButton.open(config);
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

            }

        }

        private void HotelTablePagination_ValueChanged(object sender, PagePageEventArgs e)
        {
            page = e.Current;
            TableOfHotel.Binding((AntList<AntItem[]>)GetPageData(page, 20));
        }

        private void HotelTableControl_Load(object sender, EventArgs e)
        {
            //SetFloatButton();
            TableOfHotel.Columns = new([
                new Column("hotelno", "酒店地址", ColumnAlign.Center) { SortOrder = true },
                new Column("name", "酒店名字", ColumnAlign.Center),
                new Column("star", "酒店星级", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            //bindHotel.DataSource = GetPageData(page, 10);  // Bind hotel.Table to bindHotel (To allow changes show immediately).
            //TableOfHotel.DataSource = bindHotel;
            TableOfHotel.Binding((AntList<AntItem[]>)GetPageData(page, 20));

            HotelTablePagination.Current = page;

        }

        private void HotelTableDropdown_SelectedValueChanged(object sender, ObjectNEventArgs e)
        {
            switch (e.Value) {
                case "刷新":
                    TableOfHotel.Binding((AntList<AntItem[]>)GetPageData(page, 20));
                    break;

                case "增加酒店":
                    Modal.open(this.FindForm(), "增加酒店", new AddHotelControl());
                    break;

                default:
                    Console.WriteLine(e.Value);
                    break;
            }
                
        }
    }
}
