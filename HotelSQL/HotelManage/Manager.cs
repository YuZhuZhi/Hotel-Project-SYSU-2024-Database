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
        
        public Manager(Postgre postgre, bool reset = false)
        {
            SQL = postgre;
            if (reset) DropAllTable();
            try {
                CreateAllTables(postgre);
            }
            catch (Exception) {
                DropAllTable();
                CreateAllTables(postgre);
            }
            SetTables();
        }

        public void DropAllTable()
        {
            try {
                SQL.Drop($"DROP TABLE Address CASCADE;");
                SQL.Drop($"DROP TABLE TableName CASCADE;");
                SQL.Drop($"DROP TABLE Reserver CASCADE;");
                SQL.Drop($"DROP TABLE Room CASCADE;");
                SQL.Drop($"DROP TABLE RoomType CASCADE;");
                SQL.Drop($"DROP TABLE Hotel CASCADE;");
            }
            catch (Exception) { return; }
        }

        public int ReserveRoom(int reserverID, int hotelNO, int roomNO, DateTime date, int duration)
        {
            if (Room.Reserve(hotelNO, roomNO)) {
                Reserver.Delete(reserverID);
                Reserver.Add(reserverID, date, duration);

                Reservation.Add(reserverID, hotelNO, roomNO);

                return Room.Update() + Reserver.Update() + Reservation.Update();
            }
            else return 0;
        }

        public int ReserveCancle(int reserverID)
        {
            DataRow reservationInfo = Reservation.GetRow(reserverID);
            if (reservationInfo is null) return 0;
            Room.Cancle((int)reservationInfo["hotelNO"], (int)reservationInfo["roomNO"]);
            Reserver.Delete(reserverID);
            return Room.Update() + Reserver.Update();
        }

        /*---------------------------Private Function--------------------------*/

        private void CreateAllTables(Postgre postgre)
        {
            Hotel = new Hotel(postgre);
            RoomType = new RoomType(postgre);
            Room = new Room(postgre);
            Reserver = new Reserver(postgre);
            Address = new Address(postgre);
            Reservation = new Reservation(postgre);
        }

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
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
                [Address.Table.Columns["hotelNO"], Address.Table.Columns["roomNO"]]));
            dataSet.Relations.Add(new DataRelation("reserverReservation", Reserver.Table.Columns["ID"], Reservation.Table.Columns["ID"]));
            dataSet.Relations.Add(new DataRelation("roomReservation",
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
                [Reservation.Table.Columns["hotelNO"], Reservation.Table.Columns["roomNO"]]));

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
