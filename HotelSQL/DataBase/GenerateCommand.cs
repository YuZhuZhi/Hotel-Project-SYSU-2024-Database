using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace HotelSQL.DataBase
{
    class GenerateCommand
    {
        public static string Condition(List<string> columns, List<string> operators, List<string> values, List<string> logics)
        {
            var condition = new StringBuilder();
            for (int i = 0; i < columns.Count; i++) {
                condition.Append('(').Append(columns[i]).Append($" {operators[i]} ").Append(values[i]).Append(')');
                if (i != columns.Count - 1) condition.Append($" {logics[i]} ");
            }
            return condition.ToString();
        }

        public static string NatrualJoin(List<string> tableNames)
        {
            var tabel = new StringBuilder();
            for (int i = 0; i < tableNames.Count; i++) {
                tabel.Append(tableNames[i]);
                if (i != tableNames.Count - 1) tabel.Append(" NATRUAL JOIN ");
            }
            return tabel.ToString();
        }
        public static string Join(List<string> tableNames, string condition)
        {
            var tabel = new StringBuilder();
            for (int i = 0; i < tableNames.Count; i++) {
                tabel.Append(tableNames[i]);
                if (i != tableNames.Count - 1) tabel.Append(" JOIN ");
            }
            tabel.Append(" ON ").Append(condition);
            return tabel.ToString();
        }

        //public static string Create(string tableName, List<string> stats, List<string> types, HashSet<int> primaryIndex, Hashtable? foreignIndex, List<bool> isNotNull)
        //{
        //    if (primaryIndex.Count == 0) return "";
        //    var statsTable = new StringBuilder();
        //    for (int i = 0; i < stats.Count; i++) {
        //        statsTable.Append($"{stats[i]} {types[i]}");
        //        if (primaryIndex.Contains(i)) statsTable.Append(" PRIMARY KEY");
        //        if (foreignIndex is not null && foreignIndex.Contains(i)) statsTable.Append(" FOREIGN KEY");
        //        if (isNotNull[i]) statsTable.Append(" NOT NULL");
        //        statsTable.Append(",\n");
        //    }
        //    return $"CREATE IF NOT EXISTS TABLE {tableName} ({statsTable});";
        //}

        public static string Drop(string tableName)
        {
            return $"DROP TABLE {tableName};";
        }

        public static string Select(string tableName, List<string> columnNames)
        {
            if (columnNames.Count == 0) return $"SELECT * FROM {tableName};";
            var columns = new StringBuilder();
            for (int i = 0; i < columnNames.Count; i++) {
                columns.Append(columnNames[i]);
                if (i != columnNames.Count - 1) columns.Append(", ");
            }
            return $"SELECT {columns} FROM {tableName};";
        }

        public static string Select(string tableName, List<string> columnNames, string condition)
        {
            var command = new StringBuilder(Select(tableName, columnNames));
            return command.Insert(command.Length - 1, $" WHERE ({condition})").ToString();
        }

        public static string Insert(string tableName, string values, string hint = "")
        {
            if (hint == "") return $"INSERT INTO {tableName} VALUES ({values});";
            else return $"INSERT INTO {tableName}({hint}) VALUES ({values});";
        }

        public static string Delete(string tableName, string condition)
        {
            return $"DELETE FROM {tableName} WHERE ({condition});";
        }

        public static string Update()
        {
            return "";
        }

    }

}
