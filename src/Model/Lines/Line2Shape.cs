using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model.Lines
{
    // |

    class Line2Shape : Shape
    {
        #region Constructor

        public Line2Shape(RectangleF rect) : base(rect) { }

        public Line2Shape(Line2Shape line) : base(line) { }

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
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.ShapeGraphics(grfx);

            PointF point1 = new PointF(Rectangle.X + (Rectangle.Width / 2), Rectangle.Y);
            PointF point2 = new PointF(Rectangle.X + (Rectangle.Height / 2), Rectangle.Y + Rectangle.Width);

            PointF[] Points =
            {
                point1,
                point2,
            };

            grfx.DrawLine(new Pen(BorderColor, BorderWidth), point1, point2);
            grfx.ResetTransform();
        }
    }
}
