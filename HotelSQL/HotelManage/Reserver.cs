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
    internal class Reserver : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, ID, date, duration
        }

        /*---------------------------Public Function--------------------------*/
        public Reserver(Postgre postgre) : base(postgre, "Reserver")
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception) {
                return;
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

        private readonly string CreateCommand = "CREATE TABLE Reserver (\n" +
            "hotelNO  int      NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE," +
            "ID       int      NOT NULL PRIMARY KEY," +
            "date     date     NOT NULL," +
            "duration interval NOT NULL);";
    }
}
