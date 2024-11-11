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
    internal class Address : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            hotelNO, roomNO, type
        }

        /*---------------------------Public Function--------------------------*/

        public Address(Postgre postgre) : base(postgre, "Address")
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
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}";
        }

        /*---------------------------Private Function--------------------------*/

        protected override void InitialData(Postgre postgre)
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

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Address (\n" +
            "hotelNO  int      NOT NULL,\n" +
            "roomNO   int      NOT NULL,\n" +
            "type     CHAR(10) NOT NULL,\n" +
            "FOREIGN KEY (hotelNO, roomNO) REFERENCES Room(hotelNO, roomNO) ON DELETE CASCADE,\n" +
            "FOREIGN KEY (hotelNO, type) REFERENCES RoomType(hotelNO, type) ON DELETE CASCADE);";
    }
}
