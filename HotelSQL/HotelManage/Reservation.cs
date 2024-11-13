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

        public Reservation(Postgre postgre) : base("Reservation")
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception error) {
                Console.WriteLine(error.ToString());
            }
            Adapter = postgre.Adapter(TableName);
            Adapter.Fill(Table);
            Table.PrimaryKey = [Table.Columns["orderNO"]];
            Table.Columns["orderNO"].AutoIncrement = true;
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}, {(Attribute)3}";
        }

        public DataRow GetRow(int ID)
        {
            var rows = Table.Select($"ID = {ID}");
            return rows.Last();
        }

        public bool Add(int ID, int hotelNO, int roomNO)
        {
            //if (Table.Select($"ID = {ID} AND hotelNO = {hotelNO}") is not null) return false;
            DataRow row = Table.NewRow();
            row["ID"] = ID;
            row["hotelNO"] = hotelNO;
            row["roomNO"] = roomNO;
            Table.Rows.Add(row);
            return true;
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
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
