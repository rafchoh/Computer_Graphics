using Draw.src.Model;
using Draw.src.Model.Lines;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {
        #region Constructor

        public DialogProcessor() { }
        
        /// <summary>
        /// Избран елемент.
        /// </summary>
        private List<Shape> selectList = new List<Shape>();
        public List<Shape> SelectList { get{ return selectList; } set{ selectList = value; } }

        private Shape selection;
        public Shape Selection { get { return selection; } set { selection = value; } }

        #endregion

        #region Properties        
        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging { get{ return isDragging; } set{ isDragging = value; } }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF locationNow;
        public PointF LocationNow { get{ return locationNow; } set{ locationNow = value; } }

        #endregion

        #region Shapes
        
        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle()
        {
            Random rct = new Random();
            int x = rct.Next(100, 1000);
            int y = rct.Next(100, 600);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 200, 100));

            rect.FillColor = Color.White;
            rect.BorderColor = Color.Black;
            rect.Opacity = 255;
            rect.BorderWidth = 1;

            ShapeList.Add(rect);
        }
        //
        // Add Ellipse
        //
        public void AddRandomEllipse()
        {
            Random eli = new Random();
            int x = eli.Next(100, 1000);
            int y = eli.Next(100, 600);

            EllipseShape ellp = new EllipseShape(new Rectangle(x, y, 200, 100));

            ellp.FillColor = Color.White;
            ellp.BorderColor = Color.Black;
            ellp.Opacity = 255;
            ShapeList.Add(ellp);
        }
        //
        // Add Circle
        //
        public void AddRandomCircle()
        {
            Random cir = new Random();
            int x = cir.Next(100, 1000);
            int y = cir.Next(100, 600);

            CircleShape ci = new CircleShape(new Rectangle(x, y, 125, 125));

            ci.FillColor = Color.White;
            ci.BorderColor = Color.Black;
            ci.Opacity = 255;
            ShapeList.Add(ci);
        }
        //
        // Add Triangle
        //
        public void AddRandomTriangle()
        {
            Random tri = new Random();
            int x = tri.Next(100, 1000);
            int y = tri.Next(100, 600);

            TriangleShape poli = new TriangleShape(new Rectangle(x, y, 100, 200));

            poli.FillColor = Color.White;
            poli.BorderColor = Color.Black;
            poli.Opacity = 255;

            ShapeList.Add(poli);
        }        
        //
        // Add Hexagon
        //
        public void AddRandomHexagon()
        {
            Random hex = new Random();
            int x = hex.Next(100, 1000);
            int y = hex.Next(100, 600);

            HexagonShape hexa = new HexagonShape(new Rectangle(x, y, 125, 125));

            hexa.FillColor = Color.White;
            hexa.BorderColor = Color.Black;
            hexa.Opacity = 255;
            ShapeList.Add(hexa);
        }
        //
        // Add Lines
        //
        public void AddRandomLine1()
        {
            Random l1 = new Random();
            int x = l1.Next(100, 1000);
            int y = l1.Next(100, 600);

            Line1Shape line1 = new Line1Shape(new Rectangle(x, y, 200, 200));

            line1.FillColor = Color.White;
            line1.BorderColor = Color.Black;
            line1.Opacity = 255;
            line1.BorderWidth = 1;

            ShapeList.Add(line1);
        }

        public void AddRandomLine2()
        {
            Random l2 = new Random();
            int x = l2.Next(100, 1000);
            int y = l2.Next(100, 600);

            Line2Shape line2 = new Line2Shape(new Rectangle(x, y, 200, 200));

            line2.FillColor = Color.White;
            line2.BorderColor = Color.Black;
            line2.Opacity = 255;
            line2.BorderWidth = 1;

            ShapeList.Add(line2);
        }

        public void AddRandomLine3()
        {
            Random l3 = new Random();
            int x = l3.Next(100, 1000);
            int y = l3.Next(100, 600);

            Line3Shape line3 = new Line3Shape(new Rectangle(x, y, 200, 200));

            line3.FillColor = Color.White;
            line3.BorderColor = Color.Black;
            line3.Opacity = 255;
            line3.BorderWidth = 1;

            ShapeList.Add(line3);
        }

        public void AddRandomLine4()
        {
            Random l4 = new Random();
            int x = l4.Next(100, 1000);
            int y = l4.Next(100, 600);

            Line4Shape line4 = new Line4Shape(new Rectangle(x, y, 200, 200));

            line4.FillColor = Color.White;
            line4.BorderColor = Color.Black;
            line4.Opacity = 255;
            line4.BorderWidth = 1;

            ShapeList.Add(line4);
        }

        public void AddRandomLineX()
        {
            Random lX = new Random();
            int x = lX.Next(100, 1000);
            int y = lX.Next(100, 600);

            LineXShape lineX = new LineXShape(new Rectangle(x, y, 200, 200));

            lineX.FillColor = Color.White;
            lineX.BorderColor = Color.Black;
            lineX.Opacity = 255;
            lineX.BorderWidth = 1;

            ShapeList.Add(lineX);
        }

        public void AddRandomLinePlus()
        {
            Random lX = new Random();
            int x = lX.Next(100, 1000);
            int y = lX.Next(100, 600);

            LinePlusShape linePlus = new LinePlusShape(new Rectangle(x, y, 200, 200));

            linePlus.FillColor = Color.White;
            linePlus.BorderColor = Color.Black;
            linePlus.Opacity = 255;
            linePlus.BorderWidth = 1;

            ShapeList.Add(linePlus);
        }
        
        #endregion

        #region Group

        //
        // Group Selected
        //
        public void Group()
        {
            if (SelectList.Count < 2) 
                return;

            float posX = float.PositiveInfinity;
            float posY = float.PositiveInfinity;

            float negX = float.NegativeInfinity;
            float negY = float.NegativeInfinity;

            foreach (var item in SelectList)
            {
                if (posX > item.Location.X)
                    posX = item.Location.X;
                
                if (posY > item.Location.Y)
                    posY = item.Location.Y;
                
                if (negX < item.Location.X + item.Width)
                    negX = item.Location.X + item.Width;

                if (negY < item.Location.Y + item.Height)
                    negY = item.Location.Y + item.Height;
            }

            var group = new Group(new RectangleF(posX, posY, negX - posX, negY - posY));
            group.ShapeList = SelectList;

            foreach (var item in SelectList)
            {
                ShapeList.Remove(item);
            }

            SelectList = new List<Shape>();
            SelectList.Add(group);
            ShapeList.Add(group);
        }

        //
        // Degroup
        //
        public void Degroup()
        {
            for (int i = 0; i < SelectList.Count; i++)
            {
                if (SelectList[i].GetType().Equals(typeof(Group)))
                {
                    Group group = (Group)SelectList[i];

                    ShapeList.AddRange(group.ShapeList);
                    group.ShapeList.Clear();

                    ShapeList.Remove(SelectList[i]);
                    SelectList.Remove(SelectList[i]);
                }
            }

            GC.Collect();
        }

        #endregion

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {
                    ShapeList[i].FillColor = Color.Red;
                    return ShapeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Чертае фигурата и външната граница на фигурите, която показва дали са маркирани.
        /// </summary>
        /// <param name="grfx"></param>
        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);

            foreach (var item in SelectList)
            {
                item.ShapeGraphics(grfx);

                grfx.DrawRectangle(Pens.GreenYellow, item.Location.X, item.Location.Y, item.Width, item.Height);
                grfx.ResetTransform();
            }
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            foreach (var item in SelectList)
            {
                item.Location = new PointF(item.Location.X + p.X - locationNow.X, item.Location.Y + p.Y - locationNow.Y);

                locationNow = p;
            }
        }

        //
        // Set Field Color
        //
        internal void SetColor(Color color)
        {
            foreach (var item in SelectList)
            {
                item.GrColor(color);
                item.FillColor = color;
            }
        }

        //
        // Set Border Color
        //
        internal void SetBorderColor(Color color)
        {
            foreach (var item in SelectList)
            {
                item.GrBorderColor(color);
                item.BorderColor = color;
            }
        }

        //
        // Set Border Width
        //
        internal void SetBorderWidth(float borderWidth, string btn = " ")
        {
            if (btn.Equals("right"))
            {
                Selection.GrBorderWidth(borderWidth);
                Selection.BorderWidth = borderWidth;
            }
            else
            {
                foreach (var item in SelectList)
                {
                    item.GrBorderWidth(borderWidth);
                    item.BorderWidth = borderWidth;
                }
            }
        }

        //
        // Delete Selected
        //
        internal void DeleteSelection()
        {
            foreach (var item in SelectList)
            {
                ShapeList.Remove(item);
            }
            SelectList.Clear();
        }
        
        
        //
        // Rotate
        //
        public void Rotate(float rotate, string btn = " ")
        {
            if (btn.Equals("right"))
            {
                Selection.RotateGr(rotate);
                Selection.Rotate = rotate;
            }
            else
            {
                if (SelectList.Count != 0)
                {
                    foreach (var item in SelectList)
                    {
                        item.RotateGr(rotate);
                        item.Rotate = rotate;
                    }
                }
            }
        }

        //
        // Set Opacity
        //
        internal void SetOpacity(int opacity, string btn = " ")
        {
            if (btn.Equals("right"))
            {
                Selection.GrOpacity(opacity);
                Selection.Opacity = opacity;
            }
            else
            {
                foreach (var item in SelectList)
                {
                    item.GrOpacity(opacity);
                    item.Opacity = opacity;
                }
            }
        }

        //
        // Set Size
        //
        internal void SetSize(float width, float height, string btn = " ")
        {
            if (btn.Equals("right"))
            {
                if (width != -1)
                    Selection.Width = width;

                if (height != -1)
                    Selection.Height = height;
            }
            else
            {
                foreach (var item in SelectList)
                {
                    if (width != -1)
                        item.Width = width;

                    if (height != -1)
                        item.Height = height;                        
                }
            }
        }
        
    }
}