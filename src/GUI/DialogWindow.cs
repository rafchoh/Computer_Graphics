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
    public partial class DialogWindow : Form
    {
        string dialogStatus;
        string button;
        DialogProcessor dialogProcessor;

        public DialogWindow(string dialogStatus, DialogProcessor dialogProcessor, string btn = " ")
        {
            this.dialogStatus = dialogStatus;
            this.dialogProcessor = dialogProcessor;
            this.button = btn;
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {

            float width;
            float height;
            try
            {
                if (!allUse_textBox.Text.Equals(""))
                {
                    width = float.Parse(allUse_textBox.Text);
                    height = float.Parse(hight_textBox.Text);
                }
                else
                {
                    width = -1;
                    height = -1;
                }
                dialogProcessor.SetSize(width, height, button);
            }
            catch (Exception)
            {
                MessageBox.Show("Грешка!");
            }

            this.Close();
        }

        private void DialogWindow_Load(object sender, EventArgs e)
        {

        }

        private void hight_label_Click(object sender, EventArgs e)
        {

        }
    }
}
