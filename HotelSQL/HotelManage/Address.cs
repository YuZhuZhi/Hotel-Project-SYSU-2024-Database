using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Address
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, roomNO, type
        }

        /*---------------------------Public Function--------------------------*/
        public Address(Postgre postgre)
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
            for (int i = 101; i <= 400; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, 'normal'"));
            }
            for (int i = 1001; i <= 1100; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, 'luxury'"));
            }
            for (int i = 50001; i <= 50010; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10001, {i}, 'president'"));
            }

            for (int i = 501; i <= 700; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10002, {i}, 'standard'"));
            }
            for (int i = 1001; i <= 1100; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10002, {i}, 'commercial'"));
            }

            for (int i = 301; i <= 450; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, 'standard'"));
            }
            for (int i = 651; i <= 700; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, 'commercial'"));
            }
            for (int i = 1; i <= 5; i++) {
                postgre.Insert(GenerateCommand.Insert(TableName, $"10003, {i}, 'president'"));
            }
        }

        /*---------------------------Public Member--------------------------*/

        public string TableName { get; set; } = "Address";

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Address (\n" +
            "hotelNO  int      NOT NULL,\n" +
            "roomNO   int      NOT NULL,\n" +
            "type     CHAR(10) NOT NULL,\n" +
            "FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO),\n" +
            "FOREIGN KEY (hotelNO, type) REFERENCES RoomType(hotelNO, type));";
    }
}
