using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    internal class Manager
    {
        /*---------------------------Public Function--------------------------*/
        
        public Manager(Postgre postgre)
        {
            SQL = postgre;
            Hotel = new Hotel(postgre);
            RoomType = new RoomType(postgre);
            Room = new Room(postgre);
            Reserver = new Reserver(postgre);
            Address = new Address(postgre);
            Reservation = new Reservation(postgre);
            SetTables();
        }

        public void DropAllTable()
        {
            SQL.Drop($"DROP TABLE {Address.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {Reservation.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {Reserver.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {Room.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {RoomType.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {Hotel.TableName} CASCADE;");
        }

        public int ReserveRoom(int reserverID, int hotelNO, int roomNO)
        {
            return 1;
        }

        public int ReserveCancle(int reserverID)
        {
            return 1;
        }

        /*---------------------------Private Function--------------------------*/

        private void SetTables()
            //Fill the DataSet(private), and set Constraints same as which in SQL.
        {
            dataSet.Tables.AddRange([Hotel.Table, RoomType.Table, Room.Table, Reserver.Table, Address.Table, Reservation.Table]);
            dataSet.Relations.Add(new DataRelation("hotelType", Hotel.Table.Columns["hotelNO"], RoomType.Table.Columns["hotelNO"]) );
            dataSet.Relations.Add(new DataRelation("hotelRoom", Hotel.Table.Columns["hotelNO"], Room.Table.Columns["hotelNO"]) );
            dataSet.Relations.Add(new DataRelation("typeAddress", 
                [RoomType.Table.Columns["hotelNO"], RoomType.Table.Columns["type"]], 
                [Address.Table.Columns["hotelNO"], Address.Table.Columns["type"]]) );
            dataSet.Relations.Add(new DataRelation("roomAddress",
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["type"]],
                [Address.Table.Columns["hotelNO"], Address.Table.Columns["type"]]));
            dataSet.Relations.Add(new DataRelation("reserverReservation", Reserver.Table.Columns["ID"], Reservation.Table.Columns["ID"]));
            dataSet.Relations.Add(new DataRelation("roomReservation",
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["type"]],
                [Reservation.Table.Columns["hotelNO"], Reservation.Table.Columns["type"]]));

        }

        /*---------------------------Public Member--------------------------*/

        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public Room Room { get; set; }
        public Reserver Reserver { get; set; }
        public Address Address { get; set; }
        public Reservation Reservation { get; set; }

        /*---------------------------Private Member--------------------------*/

        private readonly Postgre SQL;
        private DataSet dataSet = new();

    }
}
