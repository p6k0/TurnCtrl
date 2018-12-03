using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurnCtrl
{
    public static class Helper
    {
        #region турникет
        /// <summary>
        /// Модели турникетов
        /// </summary>
        public enum TurnstileModels : byte
        {
            ut2000,
            ut2000_5,
            ut2000_9,
            ut2012,
            ut2012_14,
            ut2015
        }

        /// <summary>
        /// Регионы турникетов в зависимости от их положения в линейке
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
                gp.AddLine(20, 65, 20, 130);
                gp.AddLine(20, 130, 80, 130);
                gp.AddLine(80, 130, 80, 65);
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
