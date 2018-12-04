using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCtrl
{
    public class PassProperies
    {
        /// <summary>
        /// Номер прохода на станции
        /// </summary>
        public int PassNum = 1;
        /// <summary>
        /// COM - порт общения
        /// </summary>
        public string Port = string.Empty;
        /// <summary>
        /// Адрес на линии
        /// </summary>
        public int Address = 1;
        /// <summary>
        /// Конфигурация стойки
        /// </summary>
        public RackConfig
            LeftRack = new RackConfig(),
            RightRack = new RackConfig();
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
        public bool Baggage = true;
    }
   public class RackConfig
    {
        /// <summary>
        /// Инвентарный номер стойки
        /// </summary>
        public string InventoryNum = "0";
        /// <summary>
        /// Серийный номер стойки
        /// </summary>
        public ulong SerialNum = 0;
       

        //Возможно придется добавить владельца
    }
}
