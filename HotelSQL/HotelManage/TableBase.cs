using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace HotelSQL.HotelManage
{
    internal class TableBase
    {
        /*---------------------------Public Function--------------------------*/

        public TableBase(Postgre postgre, string tableName)
        {
            TableName = tableName;
            Adapter = postgre.Adapter(TableName);
            Adapter.Fill(Table);
        }

        protected virtual void InitialData(Postgre postgre) { return; }

        /*---------------------------Public Member--------------------------*/

        public readonly string TableName;

        /*---------------------------Protected Member--------------------------*/

        protected NpgsqlDataAdapter Adapter = new();
        protected DataTable Table = new();

    }
}
