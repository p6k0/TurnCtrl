using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TurnCtrl
{
    static class TurnstileSkin
    {
        private static System.Collections.Generic.Dictionary<Turnstile.Model, ImageList> Skins = new System.Collections.Generic.Dictionary<Turnstile.Model, ImageList>();
        public static ImageList get(Turnstile.Model model)
        {
            //Исключения для визуально одинаковых моделей
            if (model == Turnstile.Model.ut2000_5) model = Turnstile.Model.ut2000;
            if (model == Turnstile.Model.ut2012_14) model = Turnstile.Model.ut2012;

            if (!Skins.ContainsKey(model))
                return CreateSkin(model);
            return Skins[model];
        }
        private static ImageList CreateSkin(Turnstile.Model model)
        {
            ImageList lst = new ImageList();
            lst.ImageSize = new Size(20, 65);
            addSkinImageByKey(ref lst, model, "in_empty");
            addSkinImageByKey(ref lst, model, "in_normal");
            addSkinImageByKey(ref lst, model, "out_empty");
            addSkinImageByKey(ref lst, model, "out_normal");
            Skins.Add(model, lst);
            return lst;
        }

        private static void addSkinImageByKey(ref ImageList lst, Turnstile.Model model, string name)
        {
            lst.Images.Add(name, (Image)(Properties.Resources.ResourceManager.GetObject(model.ToString() + "_" + name)));
        }
    }

    public static class Helper
    {
        /// <summary>
        /// Регионы турникетов в зависимости от их положения в линейке
        /// </summary>
        public static Region PassRegion = null;


        
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
                
    }

}
