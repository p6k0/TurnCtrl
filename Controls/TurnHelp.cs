using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurnCtrl
{
    public partial class Turnstile
    {
        public enum Model : byte
        {
            ut2000 = 0,
            ut2000_5 = 1,
            ut2000_9 = 2,
            ut2012 = 3,
            ut2012_14 = 4,
            ut2015 = 5
        }

        public static readonly string[] ModelName = {
            "УТ-2000",
            "УТ-2005",
            "УТ-2000.9",
            "УТ-2012",
            "УТ-2012.14",
            "УТ-2015",
        };
        #region область видимости
        /// <summary>
        /// Область видимости прохода
        /// </summary>
        public static Region PassRegion = null;
        /// <summary>
        /// Возвращает область видимости турникета в зависимости от его положения в линейке
        /// </summary>
        /// <param name="position">Позиция в линейке</param>
        /// <returns>область видимости элемента управления</returns>
        public static Region getTurnstileRegion()
        {
            if (PassRegion != null)
                return PassRegion;
            else
                return createPassRegion();
        }
        /// <summary>
        /// Создает область видимости турникета в зависимости от его положения в линейке
        /// </summary>
        /// <param name="position">Позиция в линейке</param>
        /// <returns>область видимости элемента управления</returns>
        private static Region createPassRegion()
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddLine(0, 0, 0, 65);
                gp.AddLine(0, 65, 20, 65);
                gp.AddLine(20, 65, 20, 150);
                gp.AddLine(20, 150, 80, 150);
                gp.AddLine(80, 150, 80, 65);
                gp.AddLine(80, 65, 60, 65);
                gp.AddLine(60, 65, 60, 0);
                gp.AddLine(60, 0, 0, 0);
                PassRegion = new Region(gp);
                return PassRegion;
            }
        }
        #endregion
    }
}
