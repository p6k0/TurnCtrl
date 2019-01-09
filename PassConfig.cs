using System;

namespace TurnCtrl
{
    public class StationProperties
    {
        public int ExpressCode;
        public string Name;
    }

    public abstract class Props
    {
        public delegate void PropertyChanged(object sender, EventArgs e);
        /// <summary>
        /// Порядковый номер элемента
        /// </summary>
        public byte Order = 1;
    }

    public class LineGroupProperties : Props
    {
        public event PropertyChanged NameChanged;
        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                NameChanged?.Invoke(this, null);
            }
        }

        private string _Name = "Группа линеек";

    }

    public class TurnLineProperties : Props
    {

        public event PropertyChanged NameChanged;
        public event PropertyChanged ModelChanged;
        /// <summary>
        /// Название линейки
        /// </summary>
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                NameChanged?.Invoke(this, null);
            }
        }
        private string _Name = "Имя линейки";
        /// <summary>
        /// Модель турникетов в линейке
        /// </summary>
        public Turnstile.Model TurnstileModel
        {
            get => _TurnstileModel;
            set
            {
                _TurnstileModel = value;
                ModelChanged?.Invoke(this, null);
            }
        }

        private Turnstile.Model _TurnstileModel = Turnstile.Model.ut2000;
    }
    public class WireProperties
    {
        /// <summary>
        /// Адрес на линии
        /// </summary>
        public byte Address = 1;
        /// <summary>
        /// COM - порт общения
        /// </summary>
        public string Port = "Com1";
    }

    public class PassProperties : Props
    {
        public event PropertyChanged NumberChanged;
        public event PropertyChanged HeadCfgChanged;

        /// <summary>
        /// Номер прохода на станции
        /// </summary>
        public byte Number
        {
            get => _Number;
            set
            {
                _Number = value;
                NumberChanged?.Invoke(this, null);
            }
        }
        public byte _Number = 1;
        /// <summary>
        /// Возможность прохода на платформу
        /// </summary>
        public bool InEnable
        {
            get => _InEnable;
            set
            {
                _InEnable = value;
                HeadCfgChanged?.Invoke(this, new HeadChangedEventArgs(true));
            }
        }
        private bool _InEnable = true;

        /// <summary>
        /// Возможность прохода с платформы
        /// </summary>
        public bool OutEnable
        {
            get => _OutEnable;
            set
            {
                _OutEnable = value;
                HeadCfgChanged?.Invoke(this, new HeadChangedEventArgs(false));
            }
        }
        public bool _OutEnable = true;
        /// <summary>
        /// Проход к электропоездам ЭКСПРЕСС
        /// </summary>
        public bool Express = false;
        /// <summary>
        /// Багажный проход
        /// </summary>
        public bool Baggage = false;
        /// <summary>
        /// Свойства сети RS-485
        /// </summary>
        public WireProperties Wire = new WireProperties();

        /// <summary>
        /// Конфигурация стойки
        /// </summary>
        public RackProperties
            OutRack = new RackProperties(),
            InRack = new RackProperties();
    }

    class HeadChangedEventArgs : EventArgs
    {
        public bool In;
        public HeadChangedEventArgs(bool In)
        {
            this.In = In;
        }
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
