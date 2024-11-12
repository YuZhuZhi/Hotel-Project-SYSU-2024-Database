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

        public TableBase(string tableName)
        {
            TableName = tableName;
            Table = new DataTable(TableName);
        }

        ~TableBase()
        {
            Adapter.Dispose();
        }

        /*---------------------------Public Member--------------------------*/

        public readonly string TableName;
        public DataTable Table { get; set; }

        /*---------------------------Protected Member--------------------------*/

        protected NpgsqlDataAdapter Adapter;
        

    }
}
