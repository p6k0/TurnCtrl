using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCtrl
{
    public class StationProperties
    {
        public int ExpressCode;
        public string Name;
    }

    public class LineGroupProperties
    {
        /// <summary>
        /// Порядковый номер в группе
        /// </summary>
        public int Id = 1;
        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name = "Группа линеек";
    }

    public class TurnLineProperties
    {
        /// <summary>
        /// Порядковый номер в группе
        /// </summary>
        public int Id = 1;
        /// <summary>
        /// Название линейки
        /// </summary>
        public string Name = "Имя линейки";
        /// <summary>
        /// Модель турникетов в линейке
        /// </summary>
        public Turnstile.Model TurnstileModel = Turnstile.Model.ut2000;
    }

    public class TurnstileProperty
    {
        public byte OrderId = 1;
        public PassProperty Pass;
        public WireProperty Wire;
        public RackProperties
            LeftRack = new RackProperties(),
            RightRack = new RackProperties();
    }
    public class WireProperty
    {
        /// <summary>
        /// Адрес на линии rs485
        /// </summary>
        public byte Address = 1;
        /// <summary>
        /// COM-порт
        /// </summary>
        public string Port = string.Empty;
    }

    public class PassProperty
    {
        /// <summary>
        /// Номер прохода
        /// </summary>
        public byte Number = 1;
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
        public bool Express = false;
        /// <summary>
        /// Багажный проход
        /// </summary>
        public bool Baggage = false;
    }

    public class RackProperties
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
