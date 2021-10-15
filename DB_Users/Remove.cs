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
            textBox3.Text = user.Specialty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user.Name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            user.Surname = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            user.Specialty = textBox3.Text;
        }
    }
}
