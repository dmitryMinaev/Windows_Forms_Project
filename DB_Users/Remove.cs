using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DB_Users
{
    public partial class Remove : Form
    {
        public InformationUser user;

        public Remove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Remove_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Name;
            textBox2.Text = user.Surname;
            textBox3.Text = Convert.ToString(user.Age);
            textBox4.Text = user.Specialty;
            textBox5.Text = Convert.ToString(user.WorkExperience);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Не все поля заполнены");
            else
            {
                try
                {
                    user.Name = textBox1.Text;
                    user.Surname = textBox2.Text;
                    user.Age = Convert.ToInt32(textBox3.Text);
                    user.Specialty = textBox4.Text;
                    user.WorkExperience = Convert.ToInt32(textBox5.Text);
                    user.isObjectNull = false;
                    Close();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
