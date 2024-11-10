using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSQL.DataBase;

namespace HotelSQL.HotelManage
{
    internal class HotelInfo
    {
        /*---------------------------Public Enum--------------------------*/

        public enum RoomType
        {
            MEI, LAN, ZU, JU
        }

        /*---------------------------Public Function--------------------------*/

        public HotelInfo(string hotelName = "KaiFeng",
            string hotelAddr = "588 BJ East Road, Haizhu, Guangzhou",
            int hotelStar = 4,
            int[]? roomAmounts = null)
        {
            Name = hotelName;
            Address = hotelAddr;
            Star = hotelStar;
            RoomAmount = new int[4];
            if (roomAmounts is not null) for (int i = 0; i < 4; i++) RoomAmount[i] = roomAmounts[i];
        }

        public void CreateTable(Postgre postgre)
        {
            List<string> stats = ["hotelName", "hotelAddr", "hotelStar", "roomType", "roomAmount"];
            List<string> types = ["char[20]", "char[50]", "int", "char[3]", "int"];
            List<bool> isNotNull = [true, true, true, true, true];
            var command = GenerateCommand.Create(TableName, stats, types, [0, 3], null, isNotNull);
            postgre.Create(command);
            InitialData(postgre);
        }

        

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            for (int i = 0; i < 4; i++) {
                var command = GenerateCommand.Insert(TableName, $"{Name}, {Address}, {Star}, {(RoomType)i}, {RoomAmount[i]}");
                postgre.Insert(command);
            }
        }

        /*---------------------------Public Members--------------------------*/

        public string Name { get; set; } // Hotel's name.
        public string Address { get; set; }
        public int Star { get; set; }
        public int[] RoomAmount { get; set; }
        public string TableName { get; private set; } = "HotelInfo"; // Name of the table in the SQL. READ only!

    }
}
