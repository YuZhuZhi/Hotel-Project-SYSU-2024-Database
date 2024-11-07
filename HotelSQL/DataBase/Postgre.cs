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
            connectString = connectionString;
            connection = new NpgsqlConnection(connectString);
        }

        public Postgre(int port = 5432, string userName = "postgres", string passWord = "password")
        {
            connectString = $"Host=localhost;Port={port};Username={userName};Password={passWord};";
            connection = new NpgsqlConnection(connectString);
        }

        public string GetConnectString() { return connectString; }

        public void Open() { connection.Open(); }

        public void Close() { connection.Close(); }

        public void Query(string query)
        {
            var command = new NpgsqlCommand(query, connection);
            PrintSelection(command.ExecuteReader());
        }

        public void Insert(string insert) { NotQuery(insert); }

        public void Update(string update) { NotQuery(update); }

        public void Delete(string delete) { NotQuery(delete); }

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

        private void NotQuery(string sentence)
        {
            var command = new NpgsqlCommand(sentence, connection);
            command.ExecuteNonQuery();
        }

        /*---------------------------Private Members--------------------------*/

        private string connectString { get; }
        private NpgsqlConnection connection;
    }
}
