using Class_diary.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Class_diary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string MyStringProperty { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            popularItems();



        }

        public Form1(string message)
        {
            InitializeComponent();

        }
        public void popularItems()
        {



            UserControl1[] u = new UserControl1[7];

            for (int i = 0; i < u.Length; i++)
            {
                u[0] = new UserControl1();
                u[0].Icon = Resources.profile_picture;
                u[0].Number = "1";
                u[0].Fullname = "Mehraj Latifli";
                u[0].EnterTime = "01/01/2021";

                u[1] = new UserControl1();
                u[1].Icon = Resources.pp2;
                u[1].Number = "2";
                u[1].Fullname = "Kate Brown";
                u[1].EnterTime = "02/03/2021";

                u[2] = new UserControl1();
                u[2].Icon = Resources.pp3;
                u[2].Number = "3";
                u[2].Fullname = "Ben Müller";
                u[2].EnterTime = "03/01/2021";

                u[3] = new UserControl1();
                u[3].Icon = Resources.pp4;
                u[3].Number = "4";
                u[3].Fullname = "Elias Weber";
                u[3].EnterTime = "04/01/2021";

                u[4] = new UserControl1();
                u[4].Icon = Resources.pp5;
                u[4].Number = "5";
                u[4].Fullname = "Ole Larsen";
                u[4].EnterTime = "02/01/2021";

                u[5] = new UserControl1();
                u[5].Icon = Resources.pp6;
                u[5].Number = "6";
                u[5].Fullname = "Odd Kristiansen";
                u[5].EnterTime = "02/01/2021";

                u[6] = new UserControl1();
                u[6].Icon = Resources.pp7;
                u[6].Number = "7";
                u[6].Fullname = "Oktay Turkmensoy";
                u[6].EnterTime = "01/01/2021";

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }

               else
                
                    flowLayoutPanel1.Controls.Add(u[i]);
                
            }



        }

        private void Teacher2guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            Saveguna2Button1.Hide();
            RefuseButton.Hide();
            Addguna2Button1.Hide();
            Subjectlabel1.Hide();
        }

        private void RefuseButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            Saveguna2Button1.Hide();
            RefuseButton.Hide();
            Addguna2Button1.Hide();
            Subjectlabel1.Hide();
        }

        private void Teacher1guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Show();
            Saveguna2Button1.Show();
            RefuseButton.Show();
            Addguna2Button1.Show();
            Subjectlabel1.Show();
        }

        private void ShowStudentguna2Button1_Click(object sender, EventArgs e)
        {

        }

        List<Teacher> teachers = new List<Teacher>();

        private void Saveguna2Button1_Click(object sender, EventArgs e)
        {
            
                Save();
            
        }

        public void Save()
        {
            DateTime d = DateTime.Now; 

            var xml = new XmlSerializer(typeof(List<Teacher>));
            using (var fs = new FileStream($"Teacher{d.ToString("MM dd yyyy_HH mm ss")}.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, teachers);
            }

            Teacher teacher = null;

            var xml2 = new XmlSerializer(typeof(List<Teacher>));

            using (var fs2 = new FileStream($"Teacher{d.ToString("MM dd yyyy_HH mm ss")}.xml", FileMode.OpenOrCreate))
            {
                teacher = xml2.Deserialize(fs2) as Teacher;

            }
        }

        private void Addguna2Button1_Click(object sender, EventArgs e)
        {
            if (Teacher1guna2RadioButton1.Checked == true)
            {
                teachers.Add(new Teacher(richTextBox1.Text)
                {

                    Notebook = richTextBox1.Text
                });
            }
        }


        public void Add()
        {
            teachers.Add(new Teacher(richTextBox1.Text)
            {

                Notebook = richTextBox1.Text
            });
        }
    }
}
