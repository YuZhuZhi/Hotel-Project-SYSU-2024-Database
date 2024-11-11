using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Reserver
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, ID, date, duration
        }

        /*---------------------------Public Function--------------------------*/
        public Reserver(Postgre postgre)
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

        public string TableName { get; set; } = "Reserver";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Reserver (\n" +
            "hotelNO  int      NOT NULL REFERENCES Hotel(hotelNO)," +
            "ID       int      NOT NULL PRIMARY KEY," +
            "date     date     NOT NULL," +
            "duration interval NOT NULL);";

    }
}
