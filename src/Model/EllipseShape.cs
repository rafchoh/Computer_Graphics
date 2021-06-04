using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// Класът елипса е примитив, който е наследник на базовия Shape.
    /// </summary>
    class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(RectangleF ellp) : base(ellp) { }

        public EllipseShape(EllipseShape ellipse) : base(ellipse) { }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            // Проверка дали е в обекта само, ако точката е в обхващащата елипса.
            // В случая на елипса - проверяваме с формулата дали точка се намира вътре в еллипсата.
            if (base.Contains(point))
            {
                
                float A = Width / 2;
                float B = Height / 2;
                float X0 = Location.X + A;
                float Y0 = Location.Y + B;

                return Math.Pow((point.X - X0) / A, 2) + Math.Pow((point.Y - Y0) / B, 2) <= 1;
            }
            else
                // Ако не е в обхващащия правоъгълник, то не може да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.ShapeGraphics(grfx);

            grfx.FillEllipse(new SolidBrush(Color.FromArgb(Opacity, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.ResetTransform();
        }
    }
}
