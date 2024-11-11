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

        public string TableName { get; set; } = "Room";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Room(\n" +
            "hotelNO    int     NOT NULL REFERENCES Hotel(hotelNO),\n" +
            "roomNO     int     NOT NULL,\n" +
            "isReserved boolean NOT NULL,\n" +
            "PRIMARY KEY (hotelNO, roomNO));";
    }
}
