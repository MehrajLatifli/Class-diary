using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_diary
{
    [Serializable]
    public class Teacher
    {
        public Teacher()
        {

        }
        public Teacher(string notebook)
        {
            Notebook = notebook;
        }

        public string Notebook { get; set; }
    }
}
