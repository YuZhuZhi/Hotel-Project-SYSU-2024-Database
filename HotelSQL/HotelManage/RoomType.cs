using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class RoomType
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, type, price, amount
        }

        /*---------------------------Public Function--------------------------*/

        public RoomType(Postgre postgre)
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception) {
                postgre.Drop($"DROP TABLE {TableName};");
            }
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            return;
        }

        /*---------------------------Public Member--------------------------*/

        public string TableName { get; set; } = "RoomType";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE RoomType(\n" +
            "hotelNO  serial    NOT NULL REFERENCES Hotel(hotelNO),\n" +
            "type     char[10]  NOT NULL PRIMARY KEY,\n" +
            "price    int       NOT NULL,\n" +
            "amount   int       NOT NULL\n" +
            ");";
    }
}
