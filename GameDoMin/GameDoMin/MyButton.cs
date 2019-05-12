using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDoMin
{
    public partial class MyButton : System.Windows.Forms.Button
    {
        public bool isOpened;
        public bool isNormal;
        public bool isMark;
        public bool isFlag;
        public bool isMine;
        public int minesAround = 0;
        
        public MyButton()
        {
            InitializeComponent();
        }

        public MyButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
