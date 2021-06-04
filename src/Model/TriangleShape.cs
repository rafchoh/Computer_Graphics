﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// Класът триълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF poli) : base(poli)
        {
        }

        public TriangleShape(TriangleShape poligon) : base(poligon)
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
                // Но не можах да намеря формула дали дадена точка се намира в триъгълника...
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

            Point[] p = { new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y), 
                          new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)), 
                          new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)) };

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), p);
            grfx.DrawPolygon(new Pen(BorderColor, BorderWidth), p);

            grfx.ResetTransform();
        }
    }
}
