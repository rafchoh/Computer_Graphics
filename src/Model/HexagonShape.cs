using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// Класът шестоълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    class HexagonShape : Shape
    {
        #region Constructor

        public HexagonShape(RectangleF hex) : base(hex)
        {
        }

        public HexagonShape(HexagonShape hexagon) : base(hexagon)
        {
        }

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
            // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
            // В случая на правоъгълник - директно връщаме true
            if (base.Contains(point))
                // Но не можах да намеря формула дали дадена точка се намира в шестоълника...
                return true;
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

            double halfWidth = Rectangle.Width / 2;
            double fourthWidth = Rectangle.Width / 4;

            Point[] p = { new Point((int)(Rectangle.X - halfWidth), (int)Rectangle.Y),
                          new Point((int)((Rectangle.X - halfWidth) + fourthWidth), (int)(Rectangle.Y + halfWidth)),
                          new Point((int)((Rectangle.X - halfWidth) + fourthWidth * 3), (int)(Rectangle.Y + halfWidth)),
                          new Point((int)(Rectangle.X + halfWidth), (int)Rectangle.Y),
                          new Point((int)((Rectangle.X - halfWidth) + fourthWidth * 3), (int)(Rectangle.Y - halfWidth)),
                          new Point((int)((Rectangle.X - halfWidth) + fourthWidth), (int)(Rectangle.Y - halfWidth)) };

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), p);
            grfx.DrawPolygon(new Pen(BorderColor, BorderWidth), p);

            grfx.ResetTransform();
        }
    }
}

