using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>
    public abstract class Shape
    {
        #region Constructors

        public Shape() { }

        protected List<Shape> shapeList = new List<Shape>();
        public List<Shape> ShapeList { get { return shapeList; } set { shapeList = value; } }

        /// <summary>
        /// Външен контур на фигурата.
        /// </summary>
        /// <param name="rect"></param>
        public Shape(RectangleF rect) 
        {
            rectangle = rect;
        }

        /// <summary>
        /// Елементи на фигурата.
        /// </summary>
        /// <param name="shape"></param>
        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.rectangle = shape.rectangle;

            this.FillColor = shape.FillColor;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public virtual RectangleF Rectangle { get{ return rectangle; } set{ rectangle = value; } }

        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public virtual float Width { get{ return Rectangle.Width; } set{ rectangle.Width = value; } }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public virtual float Height { get{ return Rectangle.Height; } set{ rectangle.Height = value; } }

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location { get{ return Rectangle.Location; } set{ rectangle.Location = value; } }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;
        public virtual Color FillColor { get{ return fillColor; } set{ fillColor = value; } }

        /// <summary>
		/// Цвят на граница.
		/// </summary>
        private Color borderColor;
        public virtual Color BorderColor { get{ return borderColor; } set{ borderColor = value; } }
        
        /// <summary>
        /// Дебелина на страната на елемента.
        /// </summary>
        private float borderWidth;
        public virtual float BorderWidth { get{ return borderWidth; } set{ borderWidth = value; } }
        
        /// <summary>
        /// Завъртане на елемента.
        /// </summary>
        private float rotate;
        public virtual float Rotate { get{ return rotate; } set{ rotate = value; } }

        /// <summary>
        /// Прозрачност на елемента.
        /// </summary>
        private int opacity;
        public virtual int Opacity { get{ return opacity; } set{ opacity = value; } }               

        #endregion


        #region GroupElements
        
        public virtual void Move(float dx, float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);
        }

        public virtual void GrTranslate(PointF point) { }

        public virtual void GrColor(Color color)
        {
            fillColor = color;
        }

        public virtual void GrBorderColor(Color color)
        {
            borderColor = color;
        }     
        
        public virtual void GrBorderWidth(float borderW)
        {
            this.borderWidth = borderW;
        }
        
        public virtual void RotateGr(float rotate)
        {
            this.Rotate = rotate;
        }

        public virtual void GrOpacity(int opacity)
        {
            this.opacity = opacity;
        } 

        #endregion        

        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point.X, point.Y);
        }

        /// <summary>
        /// Визуализира елемента.( На произволно място. )
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx) { }

        

        /// <summary>
        /// Помага за завъртането на елемента, като не му позволява да се върти по целия екран според зададените градуси. 
        /// </summary>
        /// <param name="grfx"></param>
        public virtual void ShapeGraphics(Graphics grfx)
        {
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            grfx.RotateTransform(Rotate);

            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
        }       
    }
}
