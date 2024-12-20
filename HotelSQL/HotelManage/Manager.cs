using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSQL.HotelManage
{
    public class Manager
    {
        /*---------------------------Public Function--------------------------*/
        
        public Manager(Postgre postgre, bool reset = false)
        {
            SQL = postgre;
            if (reset) DropAllTable();
            try {
                CreateAllTables(postgre);
                SetTables();
            }
            catch (Exception) {
                DropAllTable();
                dataSet = new DataSet();
                CreateAllTables(postgre);
                SetTables();
            }
        }

        public DataTable GetHotelRooms(int hotelNO)
        {
            DataTable dataTable = new DataTable();
            var result = SQL.Query($"SELECT Room.hotelNO, roomNO, type, price, isReserved\n" +
                $"FROM hotel NATURAL JOIN room NATURAL JOIN roomtype NATURAL JOIN address\n" +
                $"WHERE (Room.hotelNO = {hotelNO})\n" +
                $"ORDER BY roomNO ASC, price ASC;");
            dataTable.Load(result);
            return dataTable;
        }

        public DataTable GetHotelReservations(int hotelNO)
        {
            DataTable dataTable = new DataTable();
            var result = SQL.Query($"SELECT Reservation.orderNO, Room.hotelno, Room.roomNO, Reserver.ID, Reserver.date, Reserver.duration\n" +
                $"FROM Reservation NATURAL JOIN Reserver NATURAL JOIN Room\n" +
                $"WHERE (hotelNO = {hotelNO})");
            dataTable.Load(result);
            return dataTable;
        }

        public DataTable GetHotelRoomTypes(int hotelNO)
        {
            DataTable dataTable = new DataTable();
            var result = SQL.Query($"SELECT hotelNO, type, price, amount\n" +
                $"FROM RoomType\n" +
                $"WHERE (hotelNO = {hotelNO})\n" +
                $"ORDER BY price ASC;");
            dataTable.Load(result);
            return dataTable;
        }

        public void DropAllTable()
        {
            try {
                SQL.Drop($"DROP TABLE Address CASCADE;");
                SQL.Drop($"DROP TABLE Reservation CASCADE;");
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
            return Reservation.Update() + Room.Update() + Reserver.Update();
        }

        public int ChangeRoom(int reserverID, int newRoomNO)
        {
            DataRow reservationInfo = Reservation.GetRow(reserverID);
            if (reservationInfo is null) return 0;
            if (Room.IsReserved((int)reservationInfo["hotelNO"], newRoomNO)) return 0;
            Room.Cancle((int)reservationInfo["hotelNO"], (int)reservationInfo["roomNO"]);
            Room.Reserve((int)reservationInfo["hotelNO"], newRoomNO);
            Reservation.SetRoom(reserverID, newRoomNO);
            return Reservation.Update() + Room.Update();
        }

        public int AddHotel(int hotelNO, string hotelName, int hotelStar)
        {
            Hotel.Add(hotelNO, hotelName, hotelStar);
            return Hotel.Update();
        }

        public int RemoveHotel(int hotelNO)
        {
            Hotel.Delete(hotelNO);
            return Hotel.Update();
        }

        public bool SetHotelName(int hotelNO, string newHotelName)
        {
            bool success = Hotel.Rename(hotelNO, newHotelName);
            if (success) Hotel.Update();
            return success;
        }

        public bool SetHotelAddress(int hotelNO, int newHotelNO)
        {
            bool success = Hotel.SetAddress(hotelNO, newHotelNO);
            if (success) Hotel.Update();
            return success;
        }

        public bool SetHotelStar(int hotelNO, int newStar)
        {
            bool success = Hotel.SetStar(hotelNO, newStar);
            if (success) Hotel.Update();
            return success;
        }

        public int AddRoomType(int hotelNO, string type, int price, int amount, int initialRoomNO)
        {
            type = type.Trim();
            RoomType.Add(hotelNO, type, price, amount);
            for (int i = initialRoomNO; i < initialRoomNO + amount; i++) {
                Room.Add(hotelNO, i);
                Address.Add(hotelNO, i, type);
            }
            return RoomType.Update() + Room.Update() + Address.Update();
        }

        public int RemoveRoomType(int hotelNO, string type)
        {
            type = type.Trim();
            var roomNOs = (from row in Room.Table.AsEnumerable()
                           join address in Address.Table.AsEnumerable()
                           on row.Field<int>("roomNO") equals address.Field<int>("roomNO")
                           where (row.Field<int>("hotelNO") == hotelNO) && (address.Field<int>("hotelNO") == hotelNO)
                                && (address.Field<string>("type")?.TrimEnd() == type)
                           select row.Field<int>("roomNO")).ToList();
            foreach (var roomNO in roomNOs) Room.Delete(hotelNO, roomNO);
            RoomType.Delete(hotelNO, type);
            return Address.Update() + RoomType.Update() + Room.Update();
        }

        public int SetRoomTypePrice(int hotelNO, string type, int price)
        {
            type = type.Trim();
            RoomType.SetPrice(hotelNO, type, price);
            return RoomType.Update();
        }

        public int SetRoomTypeName(int hotelNO, string type, string newType)
        {
            type = type.Trim();
            newType = newType.Trim();
            RoomType.SetType(hotelNO, type, newType);
            return RoomType.Update();
        }

        public int AddRoom(int hotelNO, int roomNO, string type)
        {
            type = type.Trim();
            if (!Room.Add(hotelNO, roomNO)) return 0;
            if (!Address.Add(hotelNO, roomNO, type)) return 0;
            RoomType.IncreaseAmount(hotelNO, type, 1);
            return Room.Update() + Address.Update() + RoomType.Update();
        }

        public int RemoveRoom(int hotelNO, int roomNO)
        {
            var addressInfo = Address.GetRow(hotelNO, roomNO);
            if (addressInfo is null) return 0;
            RoomType.IncreaseAmount(hotelNO, addressInfo["type"].ToString(), -1);
            Room.Delete(hotelNO, roomNO);
            return Address.Update() + Room.Update() + RoomType.Update();
        }

        public int RoomRemain(int hotelNO, string type)
        {
            return (from room in Room.Table.AsEnumerable()
                       join address in Address.Table.AsEnumerable()
                       on room.Field<int>("roomNO") equals address.Field<int>("roomNO")
                       where (room.Field<int>("hotelNO") == hotelNO) && (address.Field<int>("hotelNO") == hotelNO)
                            && (address.Field<string>("type")?.TrimEnd() == type) && (room.Field<bool>("isReserved") == false)
                    select room).Count();
        }

        public int SetRoomType(int hotelNO, int roomNO, string type)
        {
            type = type.Trim();
            Address.SetType(hotelNO, roomNO, type);
            return Address.Update();
        }

        public string GetRoomType(int hotelNO, int roomNO)
        {
            var row = Address.GetRow(hotelNO, roomNO);
            if (row is null) return string.Empty;
            return row["type"].ToString();
        }

        public List<string> GetRoomType(int hotelNO)
        {
            return (from row in RoomType.Table.AsEnumerable()
                    where row.Field<int>("hotelNO") == hotelNO
                    select row.Field<string>("type")).ToList();
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

            Room.Table.Constraints.Add(new ForeignKeyConstraint(
                Hotel.Table.Columns["hotelNO"],
                Room.Table.Columns["hotelNO"])
                { DeleteRule = Rule.Cascade});
            RoomType.Table.Constraints.Add(new ForeignKeyConstraint(
                Hotel.Table.Columns["hotelNO"],
                RoomType.Table.Columns["hotelNO"])
                { DeleteRule = Rule.Cascade });
            Address.Table.Constraints.Add(new ForeignKeyConstraint(
                [RoomType.Table.Columns["hotelNO"], RoomType.Table.Columns["type"]],
                [Address.Table.Columns["hotelNO"], Address.Table.Columns["type"]])
                { DeleteRule = Rule.Cascade });
            Address.Table.Constraints.Add(new ForeignKeyConstraint(
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
                [Address.Table.Columns["hotelNO"], Address.Table.Columns["roomNO"]])
                { DeleteRule = Rule.Cascade });
            Reservation.Table.Constraints.Add(new ForeignKeyConstraint(
                Reserver.Table.Columns["ID"],
                Reservation.Table.Columns["ID"])
                { DeleteRule = Rule.Cascade });
            Reservation.Table.Constraints.Add(new ForeignKeyConstraint(
                [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
                [Reservation.Table.Columns["hotelNO"], Reservation.Table.Columns["roomNO"]])
                { DeleteRule = Rule.Cascade });

            //var hotelType = new DataRelation("hotelType", 
            //    Hotel.Table.Columns["hotelNO"], 
            //    RoomType.Table.Columns["hotelNO"], 
            //    createConstraints: true);
            //var hotelRoom = new DataRelation("hotelRoom", 
            //    Hotel.Table.Columns["hotelNO"], 
            //    Room.Table.Columns["hotelNO"],
            //    createConstraints: true);
            //var typeAddress = new DataRelation("typeAddress",
            //    [RoomType.Table.Columns["hotelNO"], RoomType.Table.Columns["type"]],
            //    [Address.Table.Columns["hotelNO"], Address.Table.Columns["type"]],
            //    createConstraints: true);
            //var roomAddress = new DataRelation("roomAddress",
            //    [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
            //    [Address.Table.Columns["hotelNO"], Address.Table.Columns["roomNO"]],
            //    createConstraints: true);
            //var reserverReservation = new DataRelation("reserverReservation", 
            //    Reserver.Table.Columns["ID"], 
            //    Reservation.Table.Columns["ID"],
            //    createConstraints: true);
            //var roomReservation = new DataRelation("roomReservation",
            //    [Room.Table.Columns["hotelNO"], Room.Table.Columns["roomNO"]],
            //    [Reservation.Table.Columns["hotelNO"], Reservation.Table.Columns["roomNO"]],
            //    createConstraints: true);

            //hotelType.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            //hotelRoom.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            //typeAddress.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            //roomAddress.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            //reserverReservation.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            //roomReservation.ChildKeyConstraint.DeleteRule = Rule.Cascade;

            //dataSet.Relations.AddRange([hotelType, hotelRoom, typeAddress, roomAddress, reserverReservation, roomReservation]);
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
