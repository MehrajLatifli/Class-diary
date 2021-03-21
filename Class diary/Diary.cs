using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_diary
{
    [Serializable]
    public class Diary
    {
        public Diary(string number, string fullnames, string enterTime, string note, string homework, string classwork, string raiting, string commet)
        {
            Number = number;
            Fullnames = fullnames;
            EnterTime = enterTime;
            Note = note;
            Homework = homework;
            Classwork = classwork;
            Raiting = raiting;
            Commet = commet;
        }

        public Diary()
        {

        }

        public string Number { get; set; }
        public string Fullnames { get; set; }
        public string EnterTime { get; set; }
        public string Note { get; set; }
        public string Homework { get; set; }
        public string Classwork { get; set; }
        public string Raiting { get; set; }
        public string Commet { get; set; }

    }


}
