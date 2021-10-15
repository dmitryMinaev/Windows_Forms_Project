using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Users
{
    public partial class MainForms : Form
    {
        private string FORM_NAME = "Database";

        private List<InformationUser> _listUsers;
        private FormatUserString _format;

        public MainForms()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Text = FORM_NAME;

            using (StreamFileRead fileRead = new StreamFileRead())
            {
                _listUsers = await fileRead.readFileAsync();
            }

            if (_listUsers == null)
                Close();

            _format = new FormatUserString(_listUsers);
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
                      listBox1.Items.Add(_format.FormatUserLineListBox(user));
                  };

                  Invoke(action);
              };
          });

            ActiveControl = default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                _listUsers.RemoveAt(listBox1.SelectedIndex);
                button1_Click(this, new EventArgs());
            }

            ActiveControl = default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                InformationUser us = _listUsers[listBox1.SelectedIndex];
                new Remove() { user = us }.ShowDialog();
                _listUsers[listBox1.SelectedIndex] = us;
                button1_Click(this, new EventArgs());
            }

            ActiveControl = default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamFileWrite fileWrite = new StreamFileWrite())
            {
                fileWrite.writeFileAsync(_listUsers, _format);
            }

            ActiveControl = default;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (listBox1 != null)
            {
                _listUsers.Sort(new ComparerName());
                button1_Click(this, new EventArgs());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (listBox1 != null)
            {
                _listUsers.Sort(new ComparerSurname());
                button1_Click(this, new EventArgs());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (listBox1 != null)
            {
                _listUsers.Sort(new ComparerAge());
                button1_Click(this, new EventArgs());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (listBox1 != null)
            {
                _listUsers.Sort(new ComparerWorkExperience());
                button1_Click(this, new EventArgs());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InformationUser us = new InformationUser();
            new Add() { user = us }.ShowDialog();
            if (!us.isObjectNull)
            {
                _listUsers.Add(us);
                button1_Click(this, new EventArgs());
            }

            ActiveControl = default;
        }


    }
}