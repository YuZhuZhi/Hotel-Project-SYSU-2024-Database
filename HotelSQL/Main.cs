using System;
using System.Collections;
using HotelSQL.DataBase;

class MainFunction
{
    public static void Main(string[] args)
    {
        var postgre = new Postgre(passWord: "wjy20040416");
        postgre.Open();

        string query = GenerateCommand.Select(["cid", "cname"], "courses", "cid = '10045'");
        postgre.Query(query);

        postgre.Close();
    }
}
