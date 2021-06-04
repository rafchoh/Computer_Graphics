
namespace Draw.src.GUI
{
    partial class DialogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hight_label = new System.Windows.Forms.Label();
            this.hight_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.allUse_textBox = new System.Windows.Forms.TextBox();
            this.allUse_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hight_label
            // 
            this.hight_label.AutoSize = true;
            this.hight_label.Location = new System.Drawing.Point(27, 84);
            this.hight_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hight_label.Name = "hight_label";
            this.hight_label.Size = new System.Drawing.Size(80, 17);
            this.hight_label.TabIndex = 1;
            this.hight_label.Text = "Височина :";
            this.hight_label.Click += new System.EventHandler(this.hight_label_Click);
            // 
            // hight_textBox
            // 
            this.hight_textBox.Location = new System.Drawing.Point(53, 104);
            this.hight_textBox.Name = "hight_textBox";
            this.hight_textBox.Size = new System.Drawing.Size(100, 22);
            this.hight_textBox.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 154);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 22;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // allUse_textBox
            // 
            this.allUse_textBox.Location = new System.Drawing.Point(53, 45);
            this.allUse_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.allUse_textBox.Name = "allUse_textBox";
            this.allUse_textBox.Size = new System.Drawing.Size(100, 22);
            this.allUse_textBox.TabIndex = 23;
            // 
            // allUse_label
            // 
            this.allUse_label.AutoSize = true;
            this.allUse_label.Location = new System.Drawing.Point(27, 24);
            this.allUse_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.allUse_label.Name = "allUse_label";
            this.allUse_label.Size = new System.Drawing.Size(67, 17);
            this.allUse_label.TabIndex = 24;
            this.allUse_label.Text = "Ширина :";
            this.allUse_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DialogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 207);
            this.Controls.Add(this.allUse_label);
            this.Controls.Add(this.allUse_textBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hight_textBox);
            this.Controls.Add(this.hight_label);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DialogWindow";
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.DialogWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label hight_label;
        private System.Windows.Forms.TextBox hight_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox allUse_textBox;
        private System.Windows.Forms.Label allUse_label;
    }
}