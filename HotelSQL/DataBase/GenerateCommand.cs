using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.DataBase
{
    class GenerateCommand
    {
        public static string Condition(ArrayList columns, ArrayList operators, ArrayList values, ArrayList logics)
        {
            var condition = new StringBuilder();
            for (int i = 0; i < columns.Count; i++) {
                condition.Append('(').Append(columns[i]).Append($" {operators[i]} ").Append(values[i]).Append(')');
                if (i != columns.Count - 1) condition.Append($" {logics[i]} ");
            }
            return condition.ToString();
        }

        public static string NatrualJoin(ArrayList tableNames)
        {
            var tabel = new StringBuilder();
            for (int i = 0; i < tableNames.Count; i++) {
                tabel.Append(tableNames[i]);
                if (i != tableNames.Count - 1) tabel.Append(" NATRUAL JOIN ");
            }
            return tabel.ToString();
        }
        public static string Join(ArrayList tableNames, string condition)
        {
            var tabel = new StringBuilder();
            for (int i = 0; i < tableNames.Count; i++) {
                tabel.Append(tableNames[i]);
                if (i != tableNames.Count - 1) tabel.Append(" JOIN ");
            }
            tabel.Append(" ON ").Append(condition);
            return tabel.ToString();
        }

        public static string Select(ArrayList columnNames, string table)
        {
            if (columnNames.Count == 0) return $"SELECT * FROM {table};";
            var columns = new StringBuilder();
            for (int i = 0; i < columnNames.Count; i++) {
                columns.Append(columnNames[i]);
                if (i != columnNames.Count - 1) columns.Append(", ");
            }
            var sentence = $"SELECT {columns} FROM {table};";
            return sentence;
        }

        public static string Select(ArrayList columnNames, string table, string condition)
        {
            if (columnNames.Count == 0) return $"SELECT * FROM {table} WHERE ({condition});";
            var columns = new StringBuilder();
            for (int i = 0; i < columnNames.Count; i++) {
                columns.Append(columnNames[i]);
                if (i != columnNames.Count - 1) columns.Append(", ");
            }
            var sentence = $"SELECT {columns} FROM {table} WHERE ({condition});";
            return sentence;
        }
    }

}
