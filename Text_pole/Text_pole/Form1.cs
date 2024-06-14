using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Text_pole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.BackColor = Color.Blue;
            InitializeComponent();
            InitializeButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void InitializeButton()
        {
            Button myButton = new Button();
            myButton.Text = "Ввод текста";
            myButton.Location = new System.Drawing.Point(50, 50);
            myButton.Size = new System.Drawing.Size(145, 45);
            myButton.BackColor = Color.Purple;

            myButton.Click += new EventHandler(Button_Click);

            Controls.Add(myButton);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string input = ShowInputDialog("Пожалуйста, введите текст:", "Ввод текста");
            if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Вы ввели: " + input);
            }
        }

        private static string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            textLabel.Size = new System.Drawing.Size(200, 15);
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";


        }

    }
}
