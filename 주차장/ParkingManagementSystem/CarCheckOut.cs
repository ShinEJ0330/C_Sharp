using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem
{
    class CarCheckOut
    {
        public int Id { get; set; }
        public string CarNo { get; set; }
        public string CarType { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int ParkingCharge { get; set; }
        public string ParkingLotNum { get; set; }
    }
}
