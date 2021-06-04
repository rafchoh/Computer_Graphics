using Draw.src;
using Draw.src.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}

		#region DrawShape		

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();			
			statusBar.Items[0].Text = "Рисуване на правоъгълник";			
			viewPort.Invalidate();
		}
		//
		// Draw Ellipse
		//
		void toolStripButton1_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse();
			statusBar.Items[0].Text = "Рисуване на елипса";
			viewPort.Invalidate();
		}
		//
		// Draw Triangle
		//
		void toolStripButton3_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();
			statusBar.Items[0].Text = "Рисуване на триъгълник";
			viewPort.Invalidate();
		}
		//
		// Draw Circle
		//
		private void toolStripButton6_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomCircle();
			statusBar.Items[0].Text = "Рисуване на окръжност";
			viewPort.Invalidate();
		}
		//
		// Draw Hexagon
		//
		private void toolStripButton7_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomHexagon();
			statusBar.Items[0].Text = "Рисуване на шестоъгълник";
			viewPort.Invalidate();
		}
		//
		// Draw Lines
		//

		// ---
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine1();
			statusBar.Items[0].Text = "Рисуване на хоризонтална права";
			viewPort.Invalidate();
		}

		// |
		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine2();
			statusBar.Items[0].Text = "Рисуване на вертикална права";
			viewPort.Invalidate();
		}

		// \
		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine3();
			statusBar.Items[0].Text = "Рисуване на наклоненана права";
			viewPort.Invalidate();
		}

		// /
		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine4();
			statusBar.Items[0].Text = "Рисуване на наклонена права";
			viewPort.Invalidate();
		}

		// X
		private void xToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLineX();
			statusBar.Items[0].Text = "Рисуване на две кръстосани прави";
			viewPort.Invalidate();
		}

		// +
		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLinePlus();
			statusBar.Items[0].Text = "Рисуване на две кръстосани прави";
			viewPort.Invalidate();
		}
		
		#endregion

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked)
			{
				var select = dialogProcessor.ContainsPoint(e.Location);

				if (select != null)
				{
					if (dialogProcessor.SelectList.Contains(select))
						dialogProcessor.SelectList.Remove(select);
					else
						dialogProcessor.SelectList.Add(select);

					statusBar.Items[0].Text = "Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LocationNow = e.Location;
					viewPort.Invalidate();
				}
			}
			
			if (e.Button == MouseButtons.Right)
			{
				var rightcl = dialogProcessor.ContainsPoint(e.Location);

				if (rightcl != null)
				{
					if (dialogProcessor.ShapeList.Contains(rightcl))
					{
						contextMenuStrip1.Show(this, new Point(e.X, e.Y));

						dialogProcessor.Selection = rightcl;
					}
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging)
			{
				if (dialogProcessor.SelectList != null) 
					statusBar.Items[0].Text = "Влачене";

				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		//
		// Color Inside
		//
		private void оцветиВътрешносттаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetColor(colorDialog1.Color);
				viewPort.Invalidate();
			}
		}

		//
		// Color Edges
		//
		private void оцветиКраищатаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetBorderColor(colorDialog1.Color);
				statusBar.Items[0].Text = "Промяна на цвета на кунтура";
				viewPort.Invalidate();
			}
		}

		//
		// Border Width
		//
		private void оразмеряванеНаКонтураToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("border width", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		private void оразмеряванеНаКонтураToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("border width", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		private void оразмеряванеНаКонтурToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("border width", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		//
		// Delete the One U Clicked On  
		//
		private void deleteSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.ShapeList.Remove(dialogProcessor.Selection);
			statusBar.Items[0].Text = "Изтриване на примитивa";
			viewPort.Invalidate();
		}

		private void deleteSelectedItemToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			dialogProcessor.DeleteSelection();
			statusBar.Items[0].Text = "Изтриване на селектираните примитиви";
			viewPort.Invalidate();
		}

		//
		// Rotate
		//
		private void заToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("rotate", dialogProcessor, "right");
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Завъртане";
			viewPort.Invalidate();
		}

		private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("rotate", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Завъртане";
			viewPort.Invalidate();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("rotate", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Завъртане";
			viewPort.Invalidate();
		}

		//
		// Opacity
		//
		private void прозрачностToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("opacity", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		private void прозрачностToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("opacity", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		private void прозрачностToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			DialogWindowRS eventForm = new DialogWindowRS("opacity", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Задавене на дебелина на контура";
			viewPort.Invalidate();
		}

		//
		// Resize
		//
		private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindow eventForm = new DialogWindow("resize", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Oразмеряване";
			viewPort.Invalidate();
		}

		private void оразменяванеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindow eventForm = new DialogWindow("resize", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Oразмеряване";
			viewPort.Invalidate();
		}

		private void оразмеряванеНаФигураToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogWindow eventForm = new DialogWindow("resize", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Oразмеряване";
			viewPort.Invalidate();
		}
		
		//
		// Group
		//
		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			dialogProcessor.Group();
			statusBar.Items[0].Text = "Групиране";
			viewPort.Invalidate();
		}

		//
		// DeGroup
		//
		private void toolStripButton5_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.Degroup();
			statusBar.Items[0].Text = "Разгрупиране";
			viewPort.Invalidate();
		}



		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

        
    }
}
