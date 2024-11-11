using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSQL.DataBase;

namespace HotelSQL.HotelManage
{
    internal class Hotel
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, name, star
        }

        /*---------------------------Public Function--------------------------*/

        public Hotel(Postgre postgre)
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception) {
                postgre.Drop($"DROP TABLE {TableName} CASCADE;");
            }
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            postgre.Insert(GenerateCommand.Insert(TableName, "10001, 'KaiFeng', 4"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10002, 'SiJi', 5"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10003, 'SiJi', 5"));
        }

        /*---------------------------Public Member--------------------------*/

        public string TableName { get; set; } = "Hotel";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Hotel (\n" +
            "hotelNO  int      NOT NULL PRIMARY KEY,\n" +
            "name     char(10) NOT NULL,\n" +
            "star     int      NOT NULL\n" +
            ");";

    }
}
