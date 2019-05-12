using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GameDoMin.Properties;
namespace GameDoMin
{
    public partial class MineSweeper : Form
    {
        public MineSweeper()
        {
            InitializeComponent();
        }

        
        MyButton[,] btnArr = new MyButton[Const.heighS, Const.widthS];      //Đây là bãi mìn
        int bienDemTG = 0;                                                 //Biến Tính thời gian của người chơi
        
        private void Form1_Load(object sender, EventArgs e)
        {
            drawBoard();
            initBoad();
        }

        // Phương thức vẽ bàn cờ
        void drawBoard()
        {
            
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    btnArr[i,j]  = new MyButton()
                    {
                        Width = Const.widthChess,
                        Height = Const.heightChess,
                        Location = new Point(Const.widthChess*j,Const.heightChess*i),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i*16+j
                    };

                    btnArr[i, j].Click += MineSweeper_Click;
                    btnArr[i, j].MouseDown += MineSweeper_MouseDown;
                    pnlBoard.Controls.Add(btnArr[i,j]);
                }

            }
           
        }

        //Khởi tạo ngẫu nhiên vị trí của các quả bom
        void initBoad()
        {
            Random rd = new Random();
            int coutMines = 0;                      //Biến đếm số bom đã tạo ra

            while (Const.mines > coutMines)         //Nếu số bom được tạo ra vẫn nhỏ hơn số bom quy định của thể loại 16*16 thì tạo tiếp
            {
                int posMine = rd.Next(0, Const.widthS * Const.heighS - 1);   // Random vị trí quả bom
                int rMine = posMine / Const.widthS;                  //Vị trí dòng của quả bom
                int cMine = posMine % Const.widthS;                 //Vị trí cột của quả bom

                if (!btnArr[rMine, cMine].isMine)                 //Kiểm tra nếu vị trí này chưa có bom thì đưa bom vào và tăng biến đếm bom
                {
                    btnArr[rMine, cMine].isMine = true;

                    coutMines++;
                }

            }
        }

        int coutMinesAround(int i,int j)
        {
            int countAround;
                    countAround = 0;
                    if (!btnArr[i, j].isMine)
                    {
                        int x1 = i == 0 ? 0 : -1;
                        int y1 = j == 0 ? 0 : -1;
                        int x2 = i == Const.heighS - 1 ? 1 : 2;
                        int y2 = j == Const.widthS - 1 ? 1 : 2;
                        for (; x1 < x2; x1++)               // Vòng lặp này quyết định số dòng được duyệt
                        {
                            for (int k = y1; k < y2; k++)   //Vòng lặp này quết định số cột được duyệt
                            {
                                if (btnArr[i + x1, j + k].isMine)       // Ô đang duyệt
                                    countAround++;
                            }
                        }
                    }
            return countAround;
        }

        // Nhấn chuột phải để cắm cờ
        void MineSweeper_MouseDown(object sender, MouseEventArgs e)
        {
            MyButton btn = sender as MyButton;
            timerPoint.Start();
            if (btnPause.Text.Equals("Resume"))
                btnPause.Text = "Pause";
            if (!btn.isOpened && !btn.isFlag)
            {
                if (e.Button == MouseButtons.Right)
                {
                    btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\Flag.bmp");
                    btn.isFlag = true;
                    
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right && !btn.isOpened)
                {
                    btn.BackgroundImage = null;
                    btn.isFlag = false;
                }
            }
        }

        // Sự kiện khi nhấn chuột trái vào các ô trong bàn
        void MineSweeper_Click(object sender, EventArgs e)
        {
            
            MyButton btn = sender as MyButton;
            timerPoint.Start();
            if (btnPause.Text.Equals("Resume"))
                btnPause.Text = "Pause";
            if (!btn.isFlag)
            {
                if (btn.isMine)
                {
                    btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\mine.bmp");
                    btn.isOpened = true;
                    for (int i = 0; i < Const.heighS; i++)
                    {
                        for (int j = 0; j < Const.widthS; j++)
                        {
                            if (btnArr[i, j].isMine)
                            {

                                if (btnArr[i, j].isFlag)
                                    btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\WrongFlag.bmp");
                                else
                                    btnArr[i, j].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\mine.bmp");
                            }
                        }
                    }
                    pnlBoard.Enabled = false;
                    timerPoint.Stop();
                    lblResult.Text = "Game over";
                }
                else if (!btn.isMine)
                {
                    int countMineArount = coutMinesAround((int)btn.Tag / Const.widthS, (int)btn.Tag % Const.heighS);
                    if (countMineArount > 0)
                    {
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + countMineArount + ".bmp");
                        btn.isOpened = true;
                    }
                    else
                    {
                        //OpenCell((int)btn.Tag / Const.widthS, (int)btn.Tag % Const.heighS);
                        OpenCell((int)btn.Tag / Const.widthS, (int)btn.Tag % Const.heighS);
                    }
                }
            }

            int dem = 0;
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    if (btnArr[i, j].isOpened && !btnArr[i, j].isMine)
                        dem += 1;
                }

            }
            if (dem == Const.heighS * Const.widthS - 40)
            {
                lblResult.Text = "You Win";
                EnterInformation ei = new EnterInformation();
                timerPoint.Stop();

                ei.setTextBoxTime = bienDemTG.ToString();
                ei.Show();
                

            }
        }

        // Phương thức mở ô tự động
        public bool OpenCell(int i, int j)
        {
            int openedCount = 0;
            if (btnArr[i, j].isOpened || btnArr[i, j].isFlag)
                return false;
            btnArr[i, j].isOpened = true;

            if (btnArr[i, j].isMine)
            {
                return true;
            }
            openedCount++;

            // Đếm số mìn xung quanh để kiểm tra các trường hợp
            int count = coutMinesAround(i, j);

            if (count > 0)
            {
                btnArr[i, j].minesAround = count;
                btnArr[i, j].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + coutMinesAround(i, j) + ".bmp");
            }
            else
            {
                int x1 = i == 0 ? 0 : -1;
                int y1 = j == 0 ? 0 : -1;
                int x2 = i == Const.heighS - 1 ? 1 : 2;
                int y2 = j == Const.widthS - 1 ? 1 : 2;
                btnArr[i,j].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + coutMinesAround(i ,j) + ".bmp");
                for (; x1 < x2;x1++ )
                    for (int k = y1; k < y2; k++)
                    {
                        OpenCell(i + x1, j + k);
                        //btnArr[i + x1, j + k].BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\" + coutMinesAround(i + x1, j + k) + ".bmp");
                        btnArr[i + x1, j + k].isOpened = true;
                    }
            }
            return false;
        }

        //phương thức kiểm tra đã thắng chưa
        void checkWin()
        {
            int dem = 0;
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    if (btnArr[i, j].isOpened && !btnArr[i, j].isMine)
                        dem += 1;
                }

            }
            if (dem == Const.heighS * Const.widthS - 40)
            {
                lblResult.Text = "You Win";
                pnlBoard.Enabled = false;
                timerPoint.Stop();
                //Kiểm tra nếu trong danh sách điểm cao có tg lớn hơn "dem" thì chèn dem vào vị trí đó
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*AboutUs f = new AboutUs();
            f.MdiParent = this;
            f.Show();*/
            AboutUs f = new AboutUs();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    btnArr[i, j].BackgroundImage = null;
                    btnArr[i, j].isOpened = false;
                    btnArr[i, j].isMine = false;
                    btnArr[i, j].isFlag = false;
                    btnArr[i, j].minesAround = 0;
                }
            }
            initBoad();
            pnlBoard.Enabled = true;
            lblResult.Text = "";
            lbtTime.Text = "0000";
            bienDemTG = 0;
            timerPoint.Stop();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewgame_Click(object sender, EventArgs e)
        {

            //timerNewgame.Start();
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    btnArr[i, j].BackgroundImage = null;
                    btnArr[i, j].isOpened = false;
                    btnArr[i, j].isMine = false;
                    btnArr[i, j].isFlag = false;
                    btnArr[i, j].minesAround = 0;
                }
            }
            initBoad();
            pnlBoard.Enabled = true;
            lblResult.Text = "";
            lbtTime.Text = "0000";
            bienDemTG = 0;
            timerPoint.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bienDemTG += 1;
                if (bienDemTG < 10)
                    lbtTime.Text = "000" + bienDemTG.ToString();
                else if (bienDemTG < 100)
                    lbtTime.Text = "00" + bienDemTG.ToString();
                else if (bienDemTG < 1000)
                    lbtTime.Text = "0" + bienDemTG.ToString();
                else
                    lbtTime.Text = "0" + bienDemTG.ToString();
                
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text.Equals("Pause"))
            {
                timerPoint.Stop();
                btnPause.Text = "Resume";
            }
            else
            {
                timerPoint.Start();
                btnPause.Text = "Pause";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HightScore hs = new HightScore();
            hs.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản hiện tại không có sẵn tính năng này.");
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản hiện tại không có sẵn tính năng này.");
        }

        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản hiện tại không có sẵn tính năng này.");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Const.heighS; i++)
            {
                for (int j = 0; j < Const.widthS; j++)
                {
                    btnArr[i, j].BackgroundImage = null;
                    btnArr[i, j].isOpened = false;
                    btnArr[i, j].isMine = false;
                    btnArr[i, j].isFlag = false;
                    btnArr[i, j].minesAround = 0;
                }
            }
            initBoad();
            pnlBoard.Enabled = true;
            lblResult.Text = "";
            lbtTime.Text = "0000";
            bienDemTG = 0;
            timerPoint.Stop();
        }
    }
}
