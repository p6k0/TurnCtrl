﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

        public static PictureBox CreateBagageIcon()
        {
            PictureBox icon = CreateTurnIcon();
            icon.Image = Properties.Resources.Baggage;
            icon.Top = 64;
            return icon;
        }
        public static PictureBox CreateExpressIcon()
        {
            PictureBox icon = CreateTurnIcon();
            icon.Image = Properties.Resources.Express;
            icon.Top = 44;
            return icon;
        }


        private static PictureBox CreateTurnIcon()
        {
            PictureBox icon = new PictureBox()
            {
                Width = 20,
                Height = 20,
                Left = 30
            };
            return icon;
        }
        #endregion
    }
}