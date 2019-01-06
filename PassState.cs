using System;

namespace TurnCtrl
{
    class PassState
    {
        /// <summary>
        /// Состояние проходов на вход или выход;
        /// </summary>
        readonly Travel InTravel, OutTravel;

    }

    class PassStateParam
    {
        /// <summary>
        /// Время последнего изменения
        /// </summary>
        readonly DateTime Changed;
    }

    class Travel : PassStateParam
    {
        /// <summary>
        /// Число проходов
        /// </summary>
        readonly int Count;

        /// <summary>
        /// Открыт ли проход сейчас
        /// </summary>
        readonly bool CurrentlyOpen;
    }

    class SensorState : PassStateParam
    {
        /// <summary>
        /// Состояние датчика
        /// </summary>
        readonly bool State;
    }

    class DoorState
    {
        readonly bool isSlider;
        readonly SensorState[] Sensors = new SensorState[]{
           new SensorState(),new SensorState(),new SensorState()
        };
        SensorState OpenIn { get => Sensors[0]; }
        SensorState OpenOut { get => Sensors[1]; }
        SensorState Closed { get => Sensors[2]; }
        SensorState Damage { get => Sensors[2]; }
    }
}
