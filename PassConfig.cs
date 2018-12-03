using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCtrl
{
    class PassConfig
    {
        public int
            PassNum,
            Port,
            Address;
        public RackConfig
            LeftRack,
            RightRack;
    }
    class RackConfig
    {
        ulong
            InventoryNum,
            SerialNum;
        //Возможно придется добавить владельца
    }
}
