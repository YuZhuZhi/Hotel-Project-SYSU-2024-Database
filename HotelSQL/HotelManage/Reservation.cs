using HotelSQL.DataBase;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Reservation : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            orderNO, ID, hotelNO, roomNO
        }

        /*---------------------------Public Function--------------------------*/

        public Reservation(Postgre postgre) : base(postgre, "Reservation")
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception error) {
                Console.WriteLine(error.ToString());
            }
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}, {(Attribute)3}";
        }

        /*---------------------------Private Function--------------------------*/

        protected override void InitialData(Postgre postgre)
        {
            return;
        }

        /*---------------------------Public Member--------------------------*/

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Reservation (\n" +
            "orderNO  serial NOT NULL PRIMARY KEY,\n" +
            "ID       int    NOT NULL REFERENCES Reserver(ID) ON DELETE CASCADE,\n" +
            "hotelNO  int    NOT NULL,\n" +
            "roomNO   int    NOT NULL,\n" +
            "FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO) ON DELETE CASCADE);";
    }
}
