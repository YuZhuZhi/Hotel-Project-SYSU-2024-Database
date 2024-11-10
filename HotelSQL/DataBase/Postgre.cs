using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using System.Collections;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace HotelSQL.DataBase
{
    class Postgre
    {
        /*---------------------------Public Functions--------------------------*/

        public Postgre(string connectionString)
        {
            ConnectString = connectionString;
            Connection = new NpgsqlConnection(ConnectString);
        }

        public Postgre(int port = 5432, string userName = "postgres", string passWord = "password")
        {
            ConnectString = $"Host=localhost;Port={port};Username={userName};Password={passWord};";
            Connection = new NpgsqlConnection(ConnectString);
        }

        ~Postgre()
        {
            try { Close(); }
            finally { Connection.Dispose(); }
        }

        public void Open() { Connection.Open(); }

        public void Close() { Connection.Close(); }

        public void Select(string select)
        {
            if (string.IsNullOrEmpty(select)) return;
            using var command = new NpgsqlCommand(select, Connection);
            PrintSelection(command.ExecuteReader());
        }

        public int NotQuery(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return 0;
            using var command = new NpgsqlCommand(sentence, Connection);
            return command.ExecuteNonQuery();
        }

        public int Create(string create) { return NotQuery(create); }

        public int Insert(string insert) { return NotQuery(insert); }

        public int Update(string update) { return NotQuery(update); }

        public int Delete(string delete) { return NotQuery(delete); }

        /*---------------------------Private Functions--------------------------*/

        private static void PrintSelection(NpgsqlDataReader reader)
        {
            var schema = reader.GetColumnSchema();
            while (reader.Read()) {
                foreach (var column in schema) {
                    Console.Write($"{reader[column.ColumnName]}, \t");
                }
                Console.Write('\n');
            }
        }

        /*---------------------------Private Members--------------------------*/

        public string ConnectString { get; private set; }
        private NpgsqlConnection Connection;
    }
}
