using HotelSQL.DataBase;
using System;
using System.Collections.Generic;
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
            HotelTable = new Hotel(postgre);
            RoomTypeTable = new RoomType(postgre);
            RoomTable = new Room(postgre);
            ReserverTable = new Reserver(postgre);
            AddressTable = new Address(postgre);
            ReservationTable = new Reservation(postgre);
        }

        public void DropAllTable()
        {
            SQL.Drop($"DROP TABLE {AddressTable.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {ReservationTable.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {ReserverTable.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {RoomTable.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {RoomTypeTable.TableName} CASCADE;");
            SQL.Drop($"DROP TABLE {HotelTable.TableName} CASCADE;");
        }

        public int ReserveRoom(int reserverID, int hotelNO, int roomNO)
        {
            return 1;
        }

        public int ReserveCancle(int reserverID)
        {
            return 1;
        }

        /*---------------------------Public Member--------------------------*/

        public Hotel HotelTable { get; set; }
        public RoomType RoomTypeTable { get; set; }
        public Room RoomTable { get; set; }
        public Reserver ReserverTable { get; set; }
        public Address AddressTable { get; set; }
        public Reservation ReservationTable { get; set; }

        /*---------------------------Private Member--------------------------*/

        private readonly Postgre SQL;

    }
}
