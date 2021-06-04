using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// Базовият класът отговорен за групирането на елементите, който е наследник на базовия Shape.
    /// </summary>
    public class Group : Shape
    {
        #region Constructor

        public Group(RectangleF rect) : base(rect) { }

        public Group(RectangleShape rectangle) : base(rectangle) { }

        #endregion

        #region Properties

        protected List<Shape> shapeList = new List<Shape>();
        public List<Shape> ShapeList { get { return shapeList; } set { shapeList = value; } }

        #endregion


        #region GroupElements

        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);

            foreach (var item in ShapeList)
            {
                item.Move(dx, dy);
            }
        }

        public override void GrTranslate(PointF p)
        {
            base.GrTranslate(p);
        }

        public override void GrColor(Color colorF)
        {
            base.GrColor(colorF);

            foreach (var item in ShapeList)
            {
                item.FillColor = colorF;
            }
        }

        public override void GrBorderColor(Color colorB)
        {
            base.GrBorderColor(colorB);

            foreach (var item in ShapeList)
            {
                item.BorderColor = colorB;
            }
        }
        
        public override void GrBorderWidth(float borderW)
        {
            base.GrBorderWidth(borderW);

            foreach (var item in ShapeList)
            {
                item.BorderWidth = borderW;
            }
        }

        public override void RotateGr(float rotate)
        {
            base.RotateGr(rotate);

            foreach (var item in ShapeList)
            {
                item.Rotate = rotate;
            }
        } 

        public override void GrOpacity(int opct)
        {
            base.GrOpacity(opct);

            foreach (var item in ShapeList)
            {
                item.Opacity = opct;
            }
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
            if (base.Contains(point))
            {               
                foreach (var item in ShapeList)
                {
                    // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                    // В случая на правоъгълник - директно връщаме true
                    if (item.Contains(point)) 
                        return true;
                }
                return true;
            }
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

            foreach (var item in ShapeList)
            {
                item.DrawSelf(grfx);
            }

            grfx.ResetTransform();
        }
    }
}
