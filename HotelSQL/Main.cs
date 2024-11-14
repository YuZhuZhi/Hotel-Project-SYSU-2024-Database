using System;
using System.Collections;
using System.Data;
using AntdUI;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;

class MainFunction
{
    public static void Main(string[] args)
    {
        var postgre = new Postgre(passWord: "wjy20040416");


        var manager = new Manager(postgre, true);

        //foreach (DataColumn primaryKeyColumn in manager.Room.Table.PrimaryKey) {
        //    Console.WriteLine($"Column Name: {primaryKeyColumn.ColumnName}, Data Type: {primaryKeyColumn.DataType}");
        //}

        Console.WriteLine(manager.RoomRemian(10001, "normal"));

        Console.WriteLine(manager.ReserveRoom(reserverID: 223344,
            hotelNO: 10001,
            roomNO: 101,
            date: DateTime.Now.Date,
            duration: 7));

        Console.WriteLine(manager.RoomRemian(10001, "normal"));

        //Console.WriteLine(manager.ReserveCancle(223344));

        //manager.AddHotel(10004, "LuFeng", 3);
        //manager.AddRoomType(10004, "standard", 10, 1000, 100);
        //manager.AddRoom(10004, 1005, "standard");
        //Console.WriteLine(manager.RemoveRoom(10004, 1000));
        //manager.RemoveHotel(10004);

        //manager.DropAllTable();
    }
}
