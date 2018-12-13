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

<<<<<<< HEAD
    public class VisualPassProperty
    {
        public byte OrderId = 1;
        public Turnstile.Model Model = Turnstile.Model.ut2000;
        /// <summary>
        /// Номер прохода
        /// </summary>
        public byte Number = 1;
        /// <summary>
        /// Проход к электропоездам ЭКСПРЕСС
        /// </summary>
        public bool Express = false;
        /// <summary>
        /// Багажный проход
        /// </summary>
        public bool Baggage = false;
        /// <summary>
        /// Возможность прохода на платформу
        /// </summary>
        public bool InEnable = true;
        /// <summary>
        /// Возможность прохода с платформы
        /// </summary>
        public bool OutEnable = true;
        public RackProperties
            LeftRack = new RackProperties(),
            RightRack = new RackProperties();
    }
    public class WireProperty
    {
        /// <summary>
        /// Номер прохода
        /// </summary>
        public byte Number = 1;
        /// <summary>
        /// Модель турникета
        /// </summary>
        public Turnstile.Model Model;
        /// <summary>
        /// Адрес на линии rs485
=======
    public class PassProperies
    {
        /// <summary>
        /// Порядковый номер в линейке
>>>>>>> parent of 89c9487... Remake
        /// </summary>
        public int Id = 1;
        /// <summary>
        /// Номер прохода на станции
        /// </summary>
        public int PassNum = 1;
        /// <summary>
        /// COM - порт общения
        /// </summary>
        public string Port = string.Empty;
<<<<<<< HEAD
=======
        /// <summary>
        /// Адрес на линии
        /// </summary>
        public int Address = 1;
        /// <summary>
        /// Конфигурация стойки
        /// </summary>
        public RackProperties
            LeftRack = new RackProperties(),
            RightRack = new RackProperties();
>>>>>>> parent of 89c9487... Remake
        /// <summary>
        /// Возможность прохода на платформу
        /// </summary>
        public bool InEnable = true;
        /// <summary>
        /// Возможность прохода с платформы
        /// </summary>
        public bool OutEnable = true;
    }
<<<<<<< HEAD


    public class RackProperties
=======
   public class RackProperties
>>>>>>> parent of 89c9487... Remake
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
