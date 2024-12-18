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
    public class Postgre
    {
        /*---------------------------Public Functions--------------------------*/

        public Postgre(string connectionString)
        {
            if (ConnectionNum >= 2) return;
            ConnectionNum++;
            ConnectString = connectionString;
            Connection = new NpgsqlConnection(ConnectString);
            Connection.Open();
        }

        public Postgre(int port = 5432, string userName = "postgres", string passWord = "password")
        {
            if (ConnectionNum >= 2) return;
            ConnectionNum++;
            ConnectString = $"Host=localhost;Port={port};Username={userName};Password={passWord};";
            Connection = new NpgsqlConnection(ConnectString);
            Connection.Open();
        }

        ~Postgre()
        {
            try { Close(); }
            finally { Connection?.Dispose(); }
        }

        public void Open() { Connection?.Open(); }

        public void Close() { Connection?.Close(); }

        public NpgsqlDataAdapter? Adapter(string tableName)
        {
            if (Connection is null) return null;
            var adapter =  new NpgsqlDataAdapter($"SELECT * FROM {tableName};", Connection);
            _ = new NpgsqlCommandBuilder(adapter);
            return adapter;
        }

        public NpgsqlDataReader? Query(string query)
        {
            if (string.IsNullOrEmpty(query)) return null;
            using var command = new NpgsqlCommand(query, Connection);
            return command.ExecuteReader();
        }

        public int NotQuery(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return 0;
            using var command = new NpgsqlCommand(sentence, Connection);
            return command.ExecuteNonQuery();
        }

        public void Select(string select)
        {
            PrintSelection(Query(select));
        }

        public int Create(string create) { return NotQuery(create); }

        public int Drop(string drop) { return NotQuery(drop); }

        public int Insert(string insert) { return NotQuery(insert); }

        public int Update(string update) { return NotQuery(update); }

        public int Delete(string delete) { return NotQuery(delete); }

        /*---------------------------Private Functions--------------------------*/

        private static void PrintSelection(NpgsqlDataReader? reader)
        {
            if (reader is null) return;
            var schema = reader.GetColumnSchema();
            while (reader.Read()) {
                foreach (var column in schema) {
                    Console.Write($"{reader[column.ColumnName]}, \t");
                }
                Console.Write('\n');
            }
        }

        /*---------------------------Private Members--------------------------*/

        public readonly string? ConnectString;
        private readonly NpgsqlConnection? Connection;
        private static int ConnectionNum = 0;
    }
}
