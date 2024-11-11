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
            return;
        }

        /*---------------------------Public Member--------------------------*/

        public string TableName { get; set; } = "Hotel";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Hotel (\n" +
            "hotelNO  serial   NOT NULL PRIMARY KEY,\n" +
            "name     char[10] NOT NULL,\n" +
            "star     int      NOT NULL\n" +
            ");";

    }
}
