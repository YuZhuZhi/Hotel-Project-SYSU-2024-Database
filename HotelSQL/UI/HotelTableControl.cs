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

namespace HotelSQL.UI
{
    public partial class HotelTableControl : UserControl
    {
        /*----------------------------Private Member----------------------------------------*/

        private Manager manager;

        /*----------------------------Public Event----------------------------------------*/

        public event EventHandler<List<string>> TableButtonClicked;
        // The params should be [operateType, hotelNO]

        /*----------------------------Public Function----------------------------------------*/

        public HotelTableControl(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            TableOfHotel.Columns = new([
                new Column("hotelno", "酒店地址", ColumnAlign.Center) { SortOrder = true },
                new Column("name", "酒店名字", ColumnAlign.Center),
                new Column("star", "酒店星级", ColumnAlign.Center),
                new Column("operate", "操作", ColumnAlign.Center),
                ]);

            bindHotel.DataSource = GetPageData(1, 10);  // Bind hotel.Table to bindHotel (To allow changes show immediately).
            TableOfHotel.DataSource = bindHotel;



        }

        /*----------------------------Private Function----------------------------------------*/

        private object GetPageData(int current, int pageSize)
        {
            var list = new List<AntItem[]>(pageSize);
            var table = manager.Hotel.Table;
            int start = Math.Abs(current - 1) * pageSize;
            int end = Math.Min(start + pageSize, table.Rows.Count);

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

        private Table.CellStyleInfo? TableOfHotel_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
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

        private void TableOfHotel_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Btn.Id.Contains("ViewHotelRoom")) {
                List<string> args = new() { "房间管理" };
                args.Add(TableOfHotel[e.RowIndex - 1]?["hotelno"]?.ToString());
                TableButtonClicked?.Invoke(this, args);
            }

        }
    }
}
