using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Room
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, roomNO, isReserved
        }

        /*---------------------------Public Function--------------------------*/

        public Room(Postgre postgre)
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

        public string TableName { get; set; } = "Room";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Room(\n" +
            "hotelNO    serial  NOT NULL REFERENCES Hotel(hotelNO),\n" +
            "roomNO     int     NOT NULL,\n" +
            "isReserved boolean NOT NULL,\n" +
            "PRIMARY KEY (hotelNO, roomNO));";
    }
}
