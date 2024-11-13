using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HotelSQL.DataBase;
using Npgsql;

namespace HotelSQL.HotelManage
{
    internal class Hotel : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, name, star
        }

        /*---------------------------Public Function--------------------------*/

        public Hotel(Postgre postgre) : base("Hotel")
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
            Table.PrimaryKey = [Table.Columns["hotelNO"]];
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}";
        }

        public bool Add(int hotelNO, string hotelName, int hotelStar)
        {
            if (Table.Rows.Find(hotelNO) is not null) return false;
            Table.Rows.Add([hotelNO, hotelName, hotelStar]);
            return true;
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            postgre.Insert(GenerateCommand.Insert(TableName, "10001, 'KaiFeng', 4"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10002, 'SiJi', 5"));
            postgre.Insert(GenerateCommand.Insert(TableName, "10003, 'SiJi', 5"));
        }

        /*---------------------------Public Member--------------------------*/

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Hotel (\n" +
            "hotelNO  int      NOT NULL PRIMARY KEY,\n" +
            "name     char(10) NOT NULL,\n" +
            "star     int      NOT NULL\n" +
            ");";

    }
}
