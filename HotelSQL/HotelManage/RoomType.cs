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
    internal class RoomType : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, type, price, amount
        }

        /*---------------------------Public Function--------------------------*/

        public RoomType(Postgre postgre) : base("RoomType")
        {
            try {
                postgre.Create(CreateCommand);
                InitialData(postgre);
            }
            catch (Exception) {
                return;
            }
            Adapter = postgre.Adapter(TableName);
            Adapter.Fill(Table);
            Table.PrimaryKey = [Table.Columns["hotelNO"], Table.Columns["type"]];
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}, {(Attribute)3}";
        }

        public bool Add(int hotelNO, string type, int price, int amount)
        {
            if (Table.Rows.Find([hotelNO, type]) is not null) return false;
            Table.Rows.Add([hotelNO, type, price, amount]);
            return true;
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            postgre.Insert(GenerateCommand.Insert(TableName, "10001, 'normal', 500, 300"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10001, 'luxury', 1000, 100"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10001, 'president', 1500, 10"));

            postgre.Insert(GenerateCommand.Insert(TableName, "10002, 'standard', 800, 200"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10002, 'commercial', 3000, 100"));

            postgre.Insert(GenerateCommand.Insert(TableName, "10003, 'standard', 800, 150"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10003, 'commercial', 3500, 50"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10003, 'president', 5000, 5"));
        }

        /*---------------------------Public Member--------------------------*/

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE RoomType(\n" +
            "hotelNO  int       NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE,\n" +
            "type     char(10)  NOT NULL,\n" +
            "price    int       NOT NULL,\n" +
            "amount   int       NOT NULL,\n" +
            "PRIMARY KEY (hotelNO, type));";
    }
}
