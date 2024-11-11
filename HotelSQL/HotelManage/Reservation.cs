using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Reservation
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            orderNO, ID, hotelNO, roomNO
        }

        /*---------------------------Public Function--------------------------*/
        public Reservation(Postgre postgre)
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

        public string TableName { get; set; } = "Reservation";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Reservation (\n" +
            "orderNO  serial NOT NULL PRIMARY KEY,\n" +
            "ID       int    NOT NULL REFERENCES Reserver(ID),\n" +
            "hotelNO  int    NOT NULL,\n" +
            "roomNO   int    NOT NULL,\n" +
            "FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO));";
    }
}
