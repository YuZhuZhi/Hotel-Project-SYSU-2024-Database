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
    internal class Reserver : TableBase
    {
        /*---------------------------Public Enum--------------------------*/

        public enum Attribute
        {
            ID, date, duration
        }

        /*---------------------------Public Function--------------------------*/
        public Reserver(Postgre postgre) : base("Reserver")
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
            Table.PrimaryKey = [Table.Columns["ID"]];
        }

        public Attribute GetAttribute(int index)
        {
            return (Attribute)index;
        }

        public string GetAllAttribute()
        {
            return $"{(Attribute)0}, {(Attribute)1}, {(Attribute)2}, {(Attribute)3}";
        }

        public DataRow? GetRow(int ID) { return Table.Rows.Find(ID); }

        public bool Add(int ID, DateTime date, int duration)
        {
            if (Table.Rows.Find(ID) is not null) return false;
            Table.Rows.Add([ID, date.Date, new TimeSpan(duration, 0, 0)]);
            return true;
        }

        public void Delete(int ID)
        {
            Table.Rows.Find(ID)?.Delete();
        }

        /*---------------------------Private Function--------------------------*/

        private void InitialData(Postgre postgre)
        {
            return;
        }

        /*---------------------------Public Member--------------------------*/

        /*---------------------------Private Member--------------------------*/

        private readonly string CreateCommand = "CREATE TABLE Reserver (\n" +
            "ID       int      NOT NULL PRIMARY KEY," +
            "date     date     NOT NULL," +
            "duration interval NOT NULL);";
    }
}
