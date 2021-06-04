using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class DialogWindowRS : Form
    {
        string dialogStatus;
        string button;
        DialogProcessor dialogProcessor;

        public DialogWindowRS(string dialogStatus, DialogProcessor dialogProcessor, string btn = " ")
        {
            this.dialogStatus = dialogStatus;
            this.dialogProcessor = dialogProcessor;
            this.button = btn;

            InitializeComponent();

            switch (dialogStatus)
            {
                case "border width":
                    label1.Text = "Дебелина на границата :";
                    break;

                case "rotate":
                    label1.Text = "Градуси :";
                    break;

                case "opacity":
                    label1.Text = "Прозрачност(МАХ: 255) :";
                    textBox1.Text = "МАХ: 255";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (dialogStatus)
            {
                case "border width":
                    this.Hide();
                    try
                    {
                        dialogProcessor.SetBorderWidth(float.Parse(textBox1.Text), button);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Грешка!");
                    }

                    this.Close();
                    break;

                case "rotate":
                    this.Hide();
                    try
                    {
                        dialogProcessor.Rotate(float.Parse(textBox1.Text), button);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Грешка!");
                    }

                    this.Close();
                    break;

                case "opacity":
                    this.Hide();
                    try
                    {
                        dialogProcessor.SetOpacity(int.Parse(textBox1.Text), button);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Грешка!  Само до 255!!!");
                    }

                    this.Close();
                    break;
            }
        }
    }
}