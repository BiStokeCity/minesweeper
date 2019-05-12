using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDoMin
{
    class MyButton2 : System.Windows.Forms.Button
    {
        public bool isOpened = false;
        public bool isNormal = false;
        public bool isMark = false;
        public bool isFlag = false;
        public bool isMine = false;
        public int minesAround = 0;
    }
}
