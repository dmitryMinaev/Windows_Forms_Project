using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Users
{
    public partial class Add : Form
    {
        public InformationUser user;

        public Add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.isObjectNull = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Add_Load(object sender, EventArgs e)
        {
            user.isObjectNull = true;
        }
    }
}
