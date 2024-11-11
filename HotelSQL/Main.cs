using System;
using System.Collections;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;

class MainFunction
{
    public static void Main(string[] args)
    {
        var postgre = new Postgre(passWord: "wjy20040416");

        var hotelTable = new Hotel(postgre);
        var roomTypeTable = new RoomType(postgre);
        var roomTable = new Room(postgre);
        var reserverTable = new Reserver(postgre);
        var addressTable = new Address(postgre);
        var reservationTable = new Reservation(postgre);
    }
}
