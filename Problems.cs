using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCtrl
{
    class Problems
    {
        #region Проход
        public enum PassProblem : byte
        {
            Offline = 0,
            InTravelsTimeout = 1,
            OutTravelsTimeout = 2
        }
        public static readonly string[] PassProblemNames = new string[]
        {
            "Нет связи {1}",
            "Отсутствие проходов на платформу",
            "Отсутствие проходов c платформы"
        };
        #endregion
        #region Створка
        public enum DoorProblem : byte
        {
            #region общие
            ClosedSensor,   // Отсутстует сигнал сенсора закрытого состояния
            Shreddinger,    // Более одного сенсора подают сигнал о положении створки
            Void,           // Ни один из сенсоров не подает сигнал о положении створки
            #endregion

            #region калиточные
            OpenOutSensor,  // Отсутствует сигнал сенсора открытия c платформы
            OpenInSensor,   // Отсутстует сигнал сенсора открытия на платформу
            #endregion

            #region Слайдеры
            BittenPassenger,// Зажевало пассажира
            OpenSensor,     // Отсутствует сигнал сенсора открытой створки
            Tremor          // Смена состояний сенсоров без осуществления прохода
            #endregion
        }
        public static readonly string[] DoorProblemNames = new string[]
        {
            "Отсутствует сигнал закрытого состояния",
            "Неопределенное положение створки",
            "Нет информации о положении створки",

            "Не открылась с платформы",
            "Не открылась на платформу",

            "Сработал сенсор зажатия пассажира",
            "Не открылась на проход",
            "Не закрылась после прохода"
        };
        #endregion
        #region ИК-датчики
        public enum IRproblem : byte
        {
            ClosedTimeout=0,  //Длительное наличие сигнала преграды
            OpenedTimeout=1,  //Длительное отсутствие сигнала преграды
        }
        public static readonly string[] IrProblemNames = new string[]
        {
            "Перекрыт",
            "Не перекрыт"
        };
        #endregion
    }






}
