using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCtrl
{
    class PassProperies
    {
        /// <summary>
        /// Номер прохода на станции
        /// </summary>
        public int PassNum = 0;
        /// <summary>
        /// COM - порт общения
        /// </summary>
        public SerialPort Port = null;
        /// <summary>
        /// Адрес на линии
        /// </summary>
        public int Address = 0;
        /// <summary>
        /// Конфигурация стойки
        /// </summary>
        public RackConfig
            LeftRack,
            RightRack;
        /// <summary>
        /// Возможность прохода на платформу
        /// </summary>
        public bool InEnable = true;
        /// <summary>
        /// Возможность прохода с платформы
        /// </summary>
        public bool OutEnable = true;
        /// <summary>
        /// Проход к электропоездам ЭКСПРЕСС
        /// </summary>
        public bool Express = true;
        /// <summary>
        /// Багажный проход
        /// </summary>
        public bool Baggage = false;
    }
    class RackConfig
    {
       public ulong
            InventoryNum = 0,
            SerialNum = 0;
       

        //Возможно придется добавить владельца
    }
}
