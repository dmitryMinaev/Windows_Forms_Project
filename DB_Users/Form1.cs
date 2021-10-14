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
    public partial class Form1 : Form
    {
        private string FORM_NAME = "Database";

        private List<InformationUser> _listUsers;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Text = FORM_NAME;

            using (StreamFileRead streamFile = new StreamFileRead())
            {
                _listUsers = await streamFile.readFileAsync();
            }

            MessageBox.Show("Form1_load");

            if (_listUsers == null)
                Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            await Task.Run(() =>
          {
              foreach (var user in _listUsers)
              {
                  Action action = delegate
                  {
                      listBox1.Items.Add(user.Name + "\t" + user.Specialty + "\t" + user.Surname + "\n");
                  };

                  Invoke(action);
              };
          });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}