using System;

namespace TurnCtrl
{
    class PassState
    {

    }

    abstract class SensorState
    {

        /// <summary>
        /// Время последнего изменения
        /// </summary>
        public int Changed;
        public bool State
        {
            get => _State;
            set
            {
                if (_State != value)
                {
                    (_State ? CurrentOn : CurrentOff).Inc((ushort)(GetUnixNow() - Changed));
                    _State = value;
                    Changed = GetUnixNow();
                }
            }
        }
        private bool _State;

        public CountTimer CurrentOn, CurrentOff;
        public AveragePrediction AvgOn, AvgOff;

        private readonly static DateTime UnixEpoch = new DateTime(1970, 1, 1);
        /// <summary>
        /// Возвращает метку времени UNIX
        /// </summary>
        /// <returns></returns>
        private static int GetUnixNow()
        {
            return (int)DateTime.UtcNow.Subtract(UnixEpoch).TotalSeconds;
        }
    }

    class AveragePrediction
    {
        public ushort Count { get; private set; }
        public ushort Duration { get; private set; }
        public AveragePrediction()
        {
            Count = 0;
            Duration = 0;
        }
        public AveragePrediction(ushort Count, ushort Duration)
        {
            this.Count = Count;
            this.Duration = Duration;
        }
        public void Update(ushort Count, ushort Duration)
        {
            this.Count = Count;
            this.Duration = Duration;
        }

    }

    class CountTimer
    {
        /// <summary>
        /// Число переключений
        /// </summary>
        public ushort Count { get; private set; } = 0;
        /// <summary>
        /// Общая длительность нахождения в данном состоянии
        /// </summary>
        public ushort Duration { get; private set; } = 0;

        public CountTimer(ushort Count, ushort Duration)
        {
            this.Count = Count;
            this.Duration = Duration;
        }

        /// <summary>
        /// Увеличение счетчика 
        /// </summary>
        /// <param name="Duration">Ч исло секунд нахождения в состоянии</param>
        public void Inc(ushort Duration)
        {
            Count++;
            Duration += Duration;
        }

        /// <summary>
        /// Сброс счетчика
        /// </summary>
        public void Reset()
        {
            Count = 0;
            Duration = 0;
        }
    }
}
