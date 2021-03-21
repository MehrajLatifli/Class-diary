using Newtonsoft.Json;
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
using System.Xml;
using System.Xml.Serialization;

namespace Class_diary
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private string fn;
        private string n;
        private string note;
        private string et;
        private string c;
        private Image i;
        public void UserControl1_Load(object sender, EventArgs e)
        {
            Commentguna2Button1.Hide();
            Cancelguna2Button1.Hide();
            CommenttextBox1.Hide();
        }


        [Category("CustomProp")]
        public string Fullname
        {

            get { return fn; }
            set { fn = value; Fullnamelabel1.Text = value; }

        }

        [Category("CustomProp")]
        public string Number
        {

            get { return n; }
            set { n = value; Nlabel1.Text = value; }

        }



        [Category("CustomProp")]
        public string EnterTime
        {

            get { return et; }
            set { et = value; EndTimelabel1.Text = value; }

        }

        [Category("CustomProp")]
        public string Commet
        {

            get { return c; }
            set { c = value; }

        }

        [Category("CustomProp")]
        public Image Icon
        {

            get { return i; }
            set { i = value; pictureBox1.Image = value; }

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Teacher1guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuRating1_onValueChanged(object sender, EventArgs e)
        {
            if(RatingbunifuRating1.Value ==1)
            {
                rlabel2.Text = Convert.ToString(1);
            }
            if (RatingbunifuRating1.Value == 2)
            {
                rlabel2.Text = Convert.ToString(2);
            }
            if (RatingbunifuRating1.Value == 3)
            {
                rlabel2.Text = Convert.ToString(3);
            }
            if (RatingbunifuRating1.Value == 4)
            {
                rlabel2.Text = Convert.ToString(4);
            }
            if (RatingbunifuRating1.Value == 5)
            {
                rlabel2.Text = Convert.ToString(5);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            Commentguna2Button1.Show();
            Cancelguna2Button1.Show();
            CommenttextBox1.Show();
            SaveSStudentDataguna2Button1.Hide();
        }

        private void Cancelguna2Button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Show();
            Commentguna2Button1.Hide();
            Cancelguna2Button1.Hide();
            CommenttextBox1.Hide();
            SaveSStudentDataguna2Button1.Show();
        }

        private void Commentguna2Button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Show();
            Commentguna2Button1.Hide();
            Cancelguna2Button1.Hide();
            CommenttextBox1.Hide();
            SaveSStudentDataguna2Button1.Hide();
        }
        List<Diary> diaries = new List<Diary>();
        string s = "";

        private void SaveStudentguna2Button1_Click(object sender, EventArgs e)
        {
            if (Participleguna2RadioButton1.Checked)
            {
                diaries.Add(new Diary(Nlabel1.Text, Fullnamelabel1.Text, EndTimelabel1.Text, Participleguna2RadioButton1.Text, HomeworkComboBox1.Text, ClassWorkguna2ComboBox1.Text, rlabel2.Text, CommenttextBox1.Text)
                {
                    Number = Nlabel1.Text,
                    Fullnames =Fullnamelabel1.Text,
                    EnterTime =EndTimelabel1.Text,
                    Note= Participleguna2RadioButton1.Text,
                    Homework = Homeworklabel2.Text,
                    Classwork =ClassWorklabel2.Text,
                    Raiting = rlabel2.Text,
                    Commet = s,

                });

                SavetoFile();
            }

            if (Belateguna2RadioButton1.Checked)
            {
                diaries.Add(new Diary(Nlabel1.Text, Fullnamelabel1.Text, EndTimelabel1.Text, Participleguna2RadioButton1.Text, HomeworkComboBox1.Text, ClassWorkguna2ComboBox1.Text, rlabel2.Text, CommenttextBox1.Text)
                {
                    Number = Nlabel1.Text,
                    Fullnames = Fullnamelabel1.Text,
                    EnterTime = EndTimelabel1.Text,
                    Note = Belateguna2RadioButton1.Text,
                    Homework = Homeworklabel2.Text,
                    Classwork = ClassWorklabel2.Text,
                    Raiting = rlabel2.Text,
                    Commet = s,

                });

                SavetoFile();
            }

            if (nottoparticipateguna2RadioButton1.Checked)
            {
                diaries.Add(new Diary(Nlabel1.Text, Fullnamelabel1.Text, EndTimelabel1.Text, Participleguna2RadioButton1.Text, HomeworkComboBox1.Text, ClassWorkguna2ComboBox1.Text, rlabel2.Text, CommenttextBox1.Text)
                {
                    Number = Nlabel1.Text,
                    Fullnames = Fullnamelabel1.Text,
                    EnterTime = EndTimelabel1.Text,
                    Note = Belateguna2RadioButton1.Text,
                    Homework = Homeworklabel2.Text,
                    Classwork = ClassWorklabel2.Text,
                    Raiting = rlabel2.Text,
                    Commet = s,

                });

                SavetoFile();
            }

            else
            {
                DialogResult dialog = MessageBox.Show("Note section is empty.", "Filling is important.", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        DateTime d = DateTime.Now;
        StringBuilder filepath = new StringBuilder();
        public void SavetoFile()
        {
            DateTime d = DateTime.Now;
          
            var xml = new XmlSerializer(typeof(List<Diary>));
            using (var fs = new FileStream($"{Fullnamelabel1.Text} {d.ToString("MM dd yyyy_HH mm ss")}.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, diaries);
            }

          

            Diary diary = null;

            var xml2 = new XmlSerializer(typeof(List<Diary>));

            using (var fs2 = new FileStream($"{Fullnamelabel1.Text} {d.ToString("MM dd yyyy_HH mm ss")}.xml", FileMode.OpenOrCreate))
            {
                diary = xml2.Deserialize(fs2) as Diary;

            }

           

        

            /*
            XmlDocument document = new XmlDocument();
                document.Load($"{Fullnamelabel1.Text}{d.ToString("MM dd yyyy_HH mm ss")}.xml");

                if (File.Exists("General.xml"))
                    File.Delete("General.xml");
                document.Save("General.xml");
            
            
            */

            /*
            foreach (var item in diaries)
            {
                string s2="";
               

                 s2= $" \n {item.Number}  \n {item.Fullnames}  \n {item.EnterTime}  \n {item.Note}  \n {item.Homework}  \n {item.Classwork}  \n {item.Raiting} \n {item.Commet} \n\n";

              

          

                


            }

            */

            


        }
         
        /*
        public void Json()
        {
            string json = JsonConvert.SerializeObject(diaries.ToArray(), Newtonsoft.Json.Formatting.Indented);
            var outObject = JsonConvert.DeserializeObject<List<Diary>>(json);
            foreach (var item in outObject)
            {

            }

            if (Fullnamelabel1.Text=="Mehraj Latifli") {
                File.WriteAllText("Mehrajusercontrol.json", json);
            }
            if (Fullnamelabel1.Text == "Kate Brown")
            {
                File.WriteAllText("Kateusercontrol.json", json);
            }

        }

        */

        private void HomeworkComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (HomeworkComboBox1.Text == "1")
            {
                Homeworklabel2.Text = Convert.ToString(1);
            }
            if (HomeworkComboBox1.Text == "2")
            {
                Homeworklabel2.Text = Convert.ToString(2);
            }
            if (HomeworkComboBox1.Text == "3")
            {
                Homeworklabel2.Text = Convert.ToString(3);
            }
            if (HomeworkComboBox1.Text == "4")
            {
                Homeworklabel2.Text = Convert.ToString(4);
            }
            if (HomeworkComboBox1.Text == "5")
            {
                Homeworklabel2.Text = Convert.ToString(5);
            }
            if (HomeworkComboBox1.Text == "6")
            {
                Homeworklabel2.Text = Convert.ToString(6);
            }
            if (HomeworkComboBox1.Text == "6")
            {
                Homeworklabel2.Text = Convert.ToString(7);
            }
            if (HomeworkComboBox1.Text == "8")
            {
                Homeworklabel2.Text = Convert.ToString(8);
            }
            if (HomeworkComboBox1.Text == "9")
            {
                Homeworklabel2.Text = Convert.ToString(9);
            }
            if (HomeworkComboBox1.Text == "10")
            {
                Homeworklabel2.Text = Convert.ToString(10);
            }

            if (HomeworkComboBox1.Text == "11")
            {
                Homeworklabel2.Text = Convert.ToString(11);
            }

            if (HomeworkComboBox1.Text == "12")
            {
                Homeworklabel2.Text = Convert.ToString(12);
            }

        }

        private void ClassWorkguna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassWorkguna2ComboBox1.Text == "1")
            {
                ClassWorklabel2.Text = Convert.ToString(1);
            }
            if (ClassWorkguna2ComboBox1.Text == "2")
            {
                ClassWorklabel2.Text = Convert.ToString(2);
            }
            if (ClassWorkguna2ComboBox1.Text == "3")
            {
                ClassWorklabel2.Text = Convert.ToString(3);
            }
            if (ClassWorkguna2ComboBox1.Text == "4")
            {
                ClassWorklabel2.Text = Convert.ToString(4);
            }
            if (ClassWorkguna2ComboBox1.Text == "5")
            {
                ClassWorklabel2.Text = Convert.ToString(5);
            }
            if (ClassWorkguna2ComboBox1.Text == "6")
            {
                ClassWorklabel2.Text = Convert.ToString(6);
            }
            if (ClassWorkguna2ComboBox1.Text == "6")
            {
                ClassWorklabel2.Text = Convert.ToString(7);
            }
            if (ClassWorkguna2ComboBox1.Text == "8")
            {
                ClassWorklabel2.Text = Convert.ToString(8);
            }
            if (ClassWorkguna2ComboBox1.Text == "9")
            {
                ClassWorklabel2.Text = Convert.ToString(9);
            }
            if (ClassWorkguna2ComboBox1.Text == "10")
            {
                ClassWorklabel2.Text = Convert.ToString(10);
            }

            if (ClassWorkguna2ComboBox1.Text == "11")
            {
                ClassWorklabel2.Text = Convert.ToString(11);
            }

            if (ClassWorkguna2ComboBox1.Text == "12")
            {
                ClassWorklabel2.Text = Convert.ToString(12);
            }
        }

        private void Commentguna2Button1_Click_1(object sender, EventArgs e)
        {
             s = CommenttextBox1.Text;
            pictureBox2.Show();
            Commentguna2Button1.Hide();
            Cancelguna2Button1.Hide();
            CommenttextBox1.Hide();
            SaveSStudentDataguna2Button1.Show();
        }
    }
}
