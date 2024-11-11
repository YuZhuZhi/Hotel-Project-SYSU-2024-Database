using System;
using System.Collections;
using System.Data;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;

class MainFunction
{
    public static void Main(string[] args)
    {
        var postgre = new Postgre(passWord: "wjy20040416");


        //var manager = new Manager(postgre);
        //manager.DropAllTable();
    }
}
