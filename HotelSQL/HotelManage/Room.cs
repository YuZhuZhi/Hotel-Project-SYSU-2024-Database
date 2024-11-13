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
    internal class Room : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, roomNO, isReserved
        }

        /*---------------------------Public Function--------------------------*/

        public Room(Postgre postgre) : base("Room")
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
            Table.PrimaryKey = [Table.Columns["hotelNO"], Table.Columns["roomNO"]];
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}";
        }

        public bool Reserve(int hotelNO, int roomNO)
        {
            var roomInfo = Table.Rows.Find([hotelNO, roomNO]);
            if (roomInfo is null) return false;
            if ((bool)roomInfo["isReserved"]) return false;
            roomInfo["isReserved"] = true;
            return true;
        }

        public void Cancle(int hotelNO, int roomNO)
        {
            var roomInfo = Table.Rows.Find([hotelNO, roomNO]);
            if (roomInfo is null) return;
            roomInfo["isReserved"] = false;
        }

        public bool Add(int hotelNO, int roomNO)
        {
            if (Table.Rows.Find([hotelNO, roomNO]) is not null) return false;
            Table.Rows.Add([hotelNO, roomNO, false]);
            return true;
        }

        public void Delete(int hotelNO, int roomNO)
        {
            Table.Rows.Find([hotelNO, roomNO])?.Delete();
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            for (int i = 101; i <= 400; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, FALSE"));
            }
            for (int i = 1001; i <= 1100; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, FALSE"));
            }
            for (int i = 50001; i <= 50010; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, FALSE"));
            }

            for (int i = 501; i <= 700; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10002, {i}, FALSE"));
            }
            for (int i = 1001; i <= 1100; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10002, {i}, FALSE"));
            }

            for (int i = 301; i <= 450; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, FALSE"));
            }
            for (int i = 651; i <= 700; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, FALSE"));
            }
            for (int i = 1; i <= 5; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, FALSE"));
            }
        }

        /*---------------------------Public Member--------------------------*/

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Room(\n" +
            "hotelNO    int     NOT NULL REFERENCES Hotel(hotelNO) ON DELETE CASCADE,\n" +
            "roomNO     int     NOT NULL,\n" +
            "isReserved boolean NOT NULL,\n" +
            "PRIMARY KEY (hotelNO, roomNO));";

    }
}
