using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Button Cube = new Button();
        PictureBox[] Buttons = new PictureBox[29];
        PictureBox Player1Visual = new PictureBox();
        PictureBox Player2Visual = new PictureBox();
        Player Player1 = new Player();
        Player Player2 = new Player();
        public Form1()
        {
            InitializeComponent();
            Player1.money = 2000;
            Player2.money = 2000;
            label1.Visible = false;
            label2.Visible = false;
            Controls.Add(Player1Visual);
            Controls.Add(Player2Visual);
            Buttons[0] = new PictureBox();
            Buttons[0].Height = 80;
            Buttons[0].Width = 80;
            Buttons[0].Left = 0;
            Buttons[0].Top = 0;
            Buttons[0].BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(Buttons[0]);

            Player1Visual.Top = Buttons[0].Top;
            Player1Visual.Left = Buttons[0].Left;
            Player1Visual.Image = Image.FromFile("../images/trump.png");
            Player1Visual.Width = 30;
            Player1Visual.Height = 30;
            Player1Visual.SizeMode = PictureBoxSizeMode.StretchImage;

            Player2Visual.Top = Buttons[0].Top;
            Player2Visual.Left = Buttons[0].Left + 35;
            Player2Visual.Image = Image.FromFile("../images/obama.png");
            Player2Visual.Width = 30;
            Player2Visual.Height = 30;
            Player2Visual.SizeMode = PictureBoxSizeMode.StretchImage;



            for (int i = 1; i < 8; i++)
            {
                Buttons[i] = new PictureBox();
                Buttons[i].Height = 80;
                Buttons[i].Width = 80;
                Buttons[i].Left = Buttons[i - 1].Left + 80;
                Buttons[i].Top = 0;
                Controls.Add(Buttons[i]);
                Buttons[i].BorderStyle = BorderStyle.FixedSingle;
            }
            for (int i = 8; i < 15; i++)
            {
                Buttons[i] = new PictureBox();
                Buttons[i].Height = 80;
                Buttons[i].Width = 80;
                Buttons[i].Left = Buttons[i - 1].Left;
                Buttons[i].Top = Buttons[i - 1].Top + 80;
                Controls.Add(Buttons[i]);
                Buttons[i].BorderStyle = BorderStyle.FixedSingle;
            }
            for (int i = 15; i < 22; i++)
            {
                Buttons[i] = new PictureBox();
                Buttons[i].Height = 80;
                Buttons[i].Width = 80;
                Buttons[i].Left = Buttons[i - 1].Left - 80;
                Buttons[i].Top = Buttons[i - 1].Top;
                Controls.Add(Buttons[i]);
                Buttons[i].BorderStyle = BorderStyle.FixedSingle;
            }
            for (int i = 22; i < 28; i++)
            {
                Buttons[i] = new PictureBox();
                Buttons[i].Height = 80;
                Buttons[i].Width = 80;
                Buttons[i].Left = Buttons[i - 1].Left;
                Buttons[i].Top = Buttons[i - 1].Top - 80;
                Controls.Add(Buttons[i]);
                Buttons[i].BorderStyle = BorderStyle.FixedSingle;
            }
            for (int i = 0; i < Buttons.Length; i++)
            {
                try
                {
                    Buttons[i].Image = Image.FromFile("../images/" + i + ".jpg");
                    Buttons[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    try
                    {
                        Buttons[i].Image = Image.FromFile("../images/" + i + ".png");
                    }
                    catch
                    {
                    }
                }
            }
            Cube.Text = "Click To Roll Number";
            Cube.Height = 100;
            Cube.Width = 100;
            Cube.Left = (this.Width / 2) - (Cube.Width / 2 + 10);
            Cube.Top = (this.Height / 2) - (Cube.Height / 2 + 10);
            Controls.Add(Cube);
            Cube.Click += new EventHandler(Cube_Click);

        }
        int Randnum;
        Random rndNum = new Random();
        int turn = 1;
        Random Suprise = new Random();
        int sup;
        private void Cube_Click(object sender, EventArgs e)
        {
            label1.Text = "Trump Has: " + Player1.money + "M";
            label2.Text = "Obama Has: " + Player2.money + "M";
            label1.Visible = true;
            label2.Visible = true;
            Randnum = rndNum.Next(1, 7);
            Cube.BackgroundImage = Image.FromFile("../images/Cube" + Randnum + ".png");
            Cube.BackgroundImageLayout = ImageLayout.Stretch;
            Cube.Text = "";
            if (turn <= 1)
            {
                Player1.Index += Randnum;
                if (Player1.Index >= 28)
                {
                    Player1.Index -= 28;
                    Player1Visual.Top = Buttons[Player1.Index].Top;
                    Player1Visual.Left = Buttons[Player1.Index].Left;
                    Player2Visual.Top = Buttons[Player2.Index].Top;
                    Player2Visual.Left = Buttons[Player2.Index].Left + 35;
                    Player1.money += 200;
                    MessageBox.Show("Trump Completed A Full Round And Recieved 200M");
                }
                Player1Visual.Top = Buttons[Player1.Index].Top;
                Player1Visual.Left = Buttons[Player1.Index].Left;
                switch (Player1.Index)
                {
                    case 1:
                        button1.Visible = false;
                        Player1.money -= 200;
                        MessageBox.Show("Trump Owe's Money To The Country And Therefore Pays 200M");
                        break;
                    case 2:
                        button1.Visible = true;
                        break;
                    case 3:
                        button1.Visible = true;
                        break;
                    case 4:
                        button1.Visible = true;
                        break;
                    case 5:
                        button1.Visible = true;
                        break;
                    case 6:
                        button1.Visible = true;
                        break;
                    case 7:
                        button1.Visible = false;
                        break;
                    case 8:
                        button1.Visible = true;
                        break;
                    case 9:
                        button1.Visible = true;
                        break;
                    case 10:
                        button1.Visible = true;
                        break;
                    case 11:
                        button1.Visible = true;
                        Player1.Index++;
                        MessageBox.Show("Trump Stepped On 1 Steps Forward!");
                        Player1Visual.Top = Buttons[Player1.Index].Top;
                        Player1Visual.Left = Buttons[Player1.Index].Left;
                        break;
                    case 12:
                        button1.Visible = true;
                        break;
                    case 13:
                        button1.Visible = true;
                        break;
                    case 14: //jail
                        button1.Visible = false;
                        MessageBox.Show("Trump Attempted Terrible Crimes And Therefor In Prison For 2 Rounds");
                        Player1.Index = 7;
                        Player1Visual.Top = Buttons[Player1.Index].Top;
                        Player1Visual.Left = Buttons[Player1.Index].Left;
                        turn++;
                        break;
                    case 15:
                        button1.Visible = true;
                        break;
                    case 16:
                        button1.Visible = true;
                        break;
                    case 17:
                        button1.Visible = true;
                        break;
                    case 18:
                        sup = Suprise.Next(1, 4);
                    switch(sup)
                        {
                        case 1:
                                Player1.money += 500;
                                MessageBox.Show("Trump Recieved 500M When Hitting Chance");
                                break;
                        case 2:
                                Player1.money -= 300;
                                MessageBox.Show("Trump Lost 300M After Hitting Chance");
                                break;
                        case 3:
                                MessageBox.Show("Trump Moves Forward 2 Steps After Hitting Chance");
                                Player1.Index += 2;
                                Player1Visual.Top = Buttons[Player1.Index].Top;
                                Player1Visual.Left = Buttons[Player1.Index].Left;
                                button1.Visible = true;
                                break;
                        case 4:
                                MessageBox.Show("Trump Moves Backwards 5 Steps After Hitting Chance");
                                Player1.Index -= 5;
                                Player1Visual.Top = Buttons[Player1.Index].Top;
                                Player1Visual.Left = Buttons[Player1.Index].Left;
                                button1.Visible = true;
                                break;
                        }
                        button1.Visible = false;
                        break;
                    case 19:
                        button1.Visible = true;
                        break;
                    case 20:
                        button1.Visible = true;
                        break;
                    case 21:
                        button1.Visible = false;
                        Player1.money += 300;
                        MessageBox.Show("Trump Recieved 300M After Finding The Treasure");
                        break;
                    case 22:
                        button1.Visible = true;
                        Player1.Index -= 3;
                        MessageBox.Show("Trump Stepped On 3 Steps Backward!");
                        Player1Visual.Top = Buttons[Player1.Index].Top;
                        Player1Visual.Left = Buttons[Player1.Index].Left;
                        break;
                    case 23:
                        button1.Visible = true;
                        break;
                    case 24:
                        button1.Visible = true;
                        break;
                    case 25:
                        sup = Suprise.Next(1, 4);
                        switch (sup)
                        {
                            case 1:
                                Player1.money += 500;
                                MessageBox.Show("Trump Recieved 500M When Hitting Chance");
                                break;
                            case 2:
                                Player1.money -= 300;
                                MessageBox.Show("Trump Lost 300M After Hitting Chance");
                                break;
                            case 3:
                                MessageBox.Show("Trump Moves Forward 2 Steps After Hitting Chance");
                                Player1.Index += 2;
                                Player1Visual.Top = Buttons[Player1.Index].Top;
                                Player1Visual.Left = Buttons[Player1.Index].Left;
                                button1.Visible = true;
                                break;
                            case 4:
                                MessageBox.Show("Trump Moves Backwards 5 Steps After Hitting Chance");
                                Player1.Index -= 5;
                                Player1Visual.Top = Buttons[Player1.Index].Top;
                                Player1Visual.Left = Buttons[Player1.Index].Left;
                                button1.Visible = true;
                                break;
                        }
                        button1.Visible = false;
                        break;
                    case 26:
                        button1.Visible = true;
                        break;
                    case 27:
                        button1.Visible = true;
                        break;
                }
                if (Whos(Player1.Index) == 2)
                {
                    MessageBox.Show("Trump Stepped On Obama's Property And Paid 100M To Him");
                    Player1.money -= 100;
                    Player2.money += 100;
                }
                Won();
                turn++;
            }
            else
            {
                Player2.Index += Randnum;
                if (Player2.Index >= 28)
                {
                    Player2.Index -= 28;
                    Player1Visual.Top = Buttons[Player1.Index].Top;
                    Player1Visual.Left = Buttons[Player1.Index].Left;
                    Player2Visual.Top = Buttons[Player2.Index].Top;
                    Player2Visual.Left = Buttons[Player2.Index].Left + 35;
                    Player2.money += 200;
                    MessageBox.Show("Obama Completed A Full Round And Recieved 200M");
                }
                Player2Visual.Top = Buttons[Player2.Index].Top;
                Player2Visual.Left = Buttons[Player2.Index].Left + 35;
                switch (Player2.Index)
                {
                    case 1:
                        button1.Visible = false;
                        Player2.money -= 200;
                        MessageBox.Show("Obama Owe's Money To The Country And Therefore Pays 200M");
                        break;
                    case 2:
                        button1.Visible = true;
                        break;
                    case 3:
                        button1.Visible = true;
                        break;
                    case 4:
                        button1.Visible = true;
                        break;
                    case 5:
                        button1.Visible = true;
                        break;
                    case 6:
                        button1.Visible = true;
                        break;
                    case 7:
                        button1.Visible = false;
                        break;
                    case 8:
                        button1.Visible = true;
                        break;
                    case 9:
                        button1.Visible = true;
                        break;
                    case 10:
                        button1.Visible = true;
                        break;
                    case 11: // 1 step forward
                        button1.Visible = true;
                        Player2.Index++;
                        MessageBox.Show("Obama Stepped On 1 Steps Forward!");
                        Player2Visual.Top = Buttons[Player2.Index].Top;
                        Player2Visual.Left = Buttons[Player2.Index].Left;
                        break;
                    case 12:
                        button1.Visible = true;
                        break;
                    case 13:
                        button1.Visible = true;
                        break;
                    case 14: //jail
                        button1.Visible = false;
                        MessageBox.Show("Obama Attempted Terrible Crimes And Therefor In Prison For 2 Rounds");
                        Player2.Index = 7;
                        Player2Visual.Top = Buttons[Player2.Index].Top;
                        Player2Visual.Left = Buttons[Player2.Index].Left;
                        turn--;
                        break;
                    case 15:
                        button1.Visible = true;
                        break;
                    case 16:
                        button1.Visible = true;
                        break;
                    case 17:
                        button1.Visible = true;
                        break;
                    case 18:
                        sup = Suprise.Next(1, 4);
                        switch (sup)
                        {
                            case 1:
                                Player2.money += 500;
                                MessageBox.Show("Obama Recieved 500M When Hitting Chance");
                                break;
                            case 2:
                                Player2.money -= 300;
                                MessageBox.Show("Obama Lost 300M After Hitting Chance");
                                break;
                            case 3:
                                MessageBox.Show("Obama Moves Forward 2 Steps After Hitting Chance");
                                Player2.Index += 2;
                                Player2Visual.Top = Buttons[Player2.Index].Top;
                                Player2Visual.Left = Buttons[Player2.Index].Left;
                                button1.Visible = true;
                                break;
                            case 4:
                                MessageBox.Show("Obama Moves Backwards 5 Steps After Hitting Chance");
                                Player2.Index -= 5;
                                Player2Visual.Top = Buttons[Player2.Index].Top;
                                Player2Visual.Left = Buttons[Player2.Index].Left;
                                button1.Visible = true;
                                break;
                        }
                        button1.Visible = false;
                        break;
                    case 19:
                        button1.Visible = true;
                        break;
                    case 20:
                        button1.Visible = true;
                        break;
                    case 21:
                        button1.Visible = false;
                        Player2.money += 300;
                        MessageBox.Show("Obama Recieved 300M After Finding The Treasure");
                        break;
                    case 22: // 3 steps backwards
                        button1.Visible = true;
                        Player2.Index -= 3;
                        MessageBox.Show("Obama Stepped On 3 Steps Backwards!");
                        Player2Visual.Top = Buttons[Player2.Index].Top;
                        Player2Visual.Left = Buttons[Player2.Index].Left;
                        break;
                    case 23:
                        button1.Visible = true;
                        break;
                    case 24:
                        button1.Visible = true;
                        break;
                    case 25:
                        sup = Suprise.Next(1, 4);
                        switch (sup)
                        {
                            case 1:
                                Player2.money += 500;
                                MessageBox.Show("Obama Recieved 500M When Hitting Chance");
                                break;
                            case 2:
                                Player2.money -= 300;
                                MessageBox.Show("Obama Lost 300M After Hitting Chance");
                                break;
                            case 3:
                                MessageBox.Show("Obama Moves Forward 2 Steps After Hitting Chance");
                                Player2.Index += 2;
                                Player2Visual.Top = Buttons[Player2.Index].Top;
                                Player2Visual.Left = Buttons[Player2.Index].Left;
                                button1.Visible = true;
                                break;
                            case 4:
                                MessageBox.Show("Obama Moves Backwards 5 Steps After Hitting Chance");
                                Player2.Index -= 5;
                                Player2Visual.Top = Buttons[Player2.Index].Top;
                                Player2Visual.Left = Buttons[Player2.Index].Left;
                                button1.Visible = true;
                                break;
                        }
                        button1.Visible = false;
                        break;
                    case 26:
                        button1.Visible = true;
                        break;
                    case 27:
                        button1.Visible = true;
                        break;
                }
                if (Whos(Player2.Index) == 1)
                {
                    MessageBox.Show("Obama Stepped On Trump's Property And Paid 100M To Him");
                    Player1.money += 100;
                    Player2.money -= 100;
                }
                Won();
                turn--;
            }
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (turn > 1) // Trump
            {
                switch (Player1.Index)
                {
                    case 2:
                        if (IsAvailable(2))
                        {
                            if (Player1.money >= 400)
                            {
                                Player1.owned[2] = true;
                                Player1.money -= 400;
                                MessageBox.Show("Trump Just Bought for: 400M BoardWalk");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 3:
                        if (IsAvailable(3))
                        {
                            if (Player1.money >= 350)
                            {
                                Player1.owned[3] = true;
                                Player1.money -= 350;
                                MessageBox.Show("Trump Just Bought for: 350M Park Place");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 4:
                        if (IsAvailable(4))
                        {
                            if (Player1.money >= 300)
                            {
                                Player1.owned[4] = true;
                                Player1.money -= 300;
                                MessageBox.Show("Trump Just Bought for: 300M North Carolina Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 5:
                        if (IsAvailable(5))
                        {
                            if (Player1.money >= 320)
                            {
                                Player1.owned[5] = true;
                                Player1.money -= 320;
                                MessageBox.Show("Trump Just Bought for: 320M Bond Street");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 6:
                        if (IsAvailable(6))
                        {
                            if (Player1.money >= 300)
                            {
                                Player1.owned[6] = true;
                                Player1.money -= 300;
                                MessageBox.Show("Trump Just Bought for: 300M Pacific Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 8:
                        if (IsAvailable(8))
                        {
                            if (Player1.money >= 220)
                            {
                                Player1.owned[8] = true;
                                Player1.money -= 220;
                                MessageBox.Show("Trump Just Bought for: 220M Indiana Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 9:
                        if (IsAvailable(9))
                        {
                            if (Player1.money >= 240)
                            {
                                Player1.owned[9] = true;
                                Player1.money -= 240;
                                MessageBox.Show("Trump Just Bought for: 240M Illinois Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 10:
                        if (IsAvailable(10))
                        {
                            if (Player1.money >= 220)
                            {
                                Player1.owned[10] = true;
                                Player1.money -= 220;
                                MessageBox.Show("Trump Just Bought for: 220M Kentucky Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 12:
                        if (IsAvailable(12))
                        {
                            if (Player1.money >= 280)
                            {
                                Player1.owned[12] = true;
                                Player1.money -= 280;
                                MessageBox.Show("Trump Just Bought for: 280M Marvin Gardens");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 13:
                        if (IsAvailable(13))
                        {
                            if (Player1.money >= 260)
                            {
                                Player1.owned[13] = true;
                                Player1.money -= 260;
                                MessageBox.Show("Trump Just Bought for: 260M Ventnor Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 15:
                        if (IsAvailable(15))
                        {
                            if (Player1.money >= 260)
                            {
                                Player1.owned[15] = true;
                                Player1.money -= 260;
                                MessageBox.Show("Trump Just Bought for: 260M Atlantic Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 16:
                        if (IsAvailable(16))
                        {
                            if (Player1.money >= 160)
                            {
                                Player1.owned[16] = true;
                                Player1.money -= 160;
                                MessageBox.Show("Trump Just Bought for: 160M Virginia Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 17:
                        if (IsAvailable(17))
                        {
                            if (Player1.money >= 140)
                            {
                                Player1.owned[17] = true;
                                Player1.money -= 140;
                                MessageBox.Show("Trump Just Bought for: 140M States Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 19:
                        if (IsAvailable(19))
                        {
                            if (Player1.money >= 140)
                            {
                                Player1.owned[19] = true;
                                Player1.money -= 140;
                                MessageBox.Show("Trump Just Bought for: 140M St.Charles Place");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 20:
                        if (IsAvailable(20))
                        {
                            if (Player1.money >= 180)
                            {
                                Player1.owned[20] = true;
                                Player1.money -= 180;
                                MessageBox.Show("Trump Just Bought for: 180M St.James Place");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 23:
                        if (IsAvailable(23))
                        {
                            if (Player1.money >= 180)
                            {
                                Player1.owned[23] = true;
                                Player1.money -= 180;
                                MessageBox.Show("Trump Just Bought for: 180M Tennessee Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 24:
                        if (IsAvailable(24))
                        {
                            if (Player1.money >= 200)
                            {
                                Player1.owned[24] = true;
                                Player1.money -= 200;
                                MessageBox.Show("Trump Just Bought for: 200M New York Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 26:
                        if (IsAvailable(26))
                        {
                            if (Player1.money >= 100)
                            {
                                Player1.owned[26] = true;
                                Player1.money -= 100;
                                MessageBox.Show("Trump Just Bought for: 100M Vermont Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 27:
                        if (IsAvailable(27))
                        {
                            if (Player1.money >= 100)
                            {
                                Player1.owned[27] = true;
                                Player1.money -= 100;
                                MessageBox.Show("Trump Just Bought for: 100M Oriental Avenue");
                            }
                            else
                                MessageBox.Show("Trump Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                }
            }
            else // Obama
            {
                switch (Player2.Index)
                {
                    case 2:
                        if (IsAvailable(2))
                        {
                            if (Player2.money >= 400)
                            {
                                Player2.owned[2] = true;
                                Player2.money -= 400;
                                MessageBox.Show("Obama Just Bought for: 400M BoardWalk");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 3:
                        if (IsAvailable(3))
                        {
                            if (Player2.money >= 350)
                            {
                                Player2.owned[3] = true;
                                Player2.money -= 350;
                                MessageBox.Show("Obama Just Bought for: 350M Park Place");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 4:
                        if (IsAvailable(4))
                        {
                            if (Player2.money >= 300)
                            {
                                Player2.owned[4] = true;
                                Player2.money -= 300;
                                MessageBox.Show("Obama Just Bought for: 300M North Carolina Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 5:
                        if (IsAvailable(5))
                        {
                            if (Player2.money >= 320)
                            {
                                Player2.owned[5] = true;
                                Player2.money -= 320;
                                MessageBox.Show("Obama Just Bought for: 320M Bond Street");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 6:
                        if (IsAvailable(6))
                        {
                            if (Player2.money >= 300)
                            {
                                Player2.owned[6] = true;
                                Player2.money -= 300;
                                MessageBox.Show("Obama Just Bought for: 300M Pacific Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 8:
                        if (IsAvailable(8))
                        {
                            if (Player2.money >= 220)
                            {
                                Player2.owned[8] = true;
                                Player2.money -= 220;
                                MessageBox.Show("Obama Just Bought for: 220M Indiana Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 9:
                        if (IsAvailable(9))
                        {
                            if (Player2.money >= 240)
                            {
                                Player2.owned[9] = true;
                                Player2.money -= 240;
                                MessageBox.Show("Obama Just Bought for: 240M Illinois Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 10:
                        if (IsAvailable(10))
                        {
                            if (Player2.money >= 220)
                            {
                                Player2.owned[10] = true;
                                Player2.money -= 220;
                                MessageBox.Show("Obama Just Bought for: 220M Kentucky Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 12:
                        if (IsAvailable(12))
                        {
                            if (Player2.money >= 280)
                            {
                                Player2.owned[12] = true;
                                Player2.money -= 280;
                                MessageBox.Show("Obama Just Bought for: 280M Marvin Gardens");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 13:
                        if (IsAvailable(13))
                        {
                            if (Player2.money >= 260)
                            {
                                Player2.owned[13] = true;
                                Player2.money -= 260;
                                MessageBox.Show("Obama Just Bought for: 260M Ventnor Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 15:
                        if (IsAvailable(15))
                        {
                            if (Player2.money >= 260)
                            {
                                Player2.owned[15] = true;
                                Player2.money -= 260;
                                MessageBox.Show("Obama Just Bought for: 260M Atlantic Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 16:
                        if (IsAvailable(16))
                        {
                            if (Player2.money >= 160)
                            {
                                Player2.owned[16] = true;
                                Player2.money -= 160;
                                MessageBox.Show("Obama Just Bought for: 160M Virginia Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 17:
                        if (IsAvailable(17))
                        {
                            if (Player2.money >= 140)
                            {
                                Player2.owned[17] = true;
                                Player2.money -= 140;
                                MessageBox.Show("Obama Just Bought for: 140M States Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 19:
                        if (IsAvailable(19))
                        {
                            if (Player2.money >= 140)
                            {
                                Player2.owned[19] = true;
                                Player2.money -= 140;
                                MessageBox.Show("Obama Just Bought for: 140M St.Charles Place");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 20:
                        if (IsAvailable(20))
                        {
                            if (Player2.money >= 180)
                            {
                                Player2.owned[20] = true;
                                Player2.money -= 180;
                                MessageBox.Show("Obama Just Bought for: 180M St.James Place");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 23:
                        if (IsAvailable(23))
                        {
                            if (Player2.money >= 180)
                            {
                                Player2.owned[23] = true;
                                Player2.money -= 180;
                                MessageBox.Show("Obama Just Bought for: 180M Tennessee Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 24:
                        if (IsAvailable(24))
                        {
                            if (Player2.money >= 200)
                            {
                                Player2.owned[24] = true;
                                Player2.money -= 200;
                                MessageBox.Show("Obama Just Bought for: 200M New York Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 26:
                        if (IsAvailable(26))
                        {
                            if (Player2.money >= 100)
                            {
                                Player2.owned[26] = true;
                                Player2.money -= 100;
                                MessageBox.Show("Obama Just Bought for: 100M Vermont Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                    case 27:
                        if (IsAvailable(27))
                        {
                            if (Player2.money >= 100)
                            {
                                Player2.owned[27] = true;
                                Player2.money -= 100;
                                MessageBox.Show("Obama Just Bought for: 100M Oriental Avenue");
                            }
                            else
                                MessageBox.Show("Obama Doesn't Have Enough Money ");
                        }
                        else
                            MessageBox.Show("This Property Is Already Occupied");
                        break;
                }
            }
        }
        private bool IsAvailable(int num)
        {
            if (Player1.owned[num] || Player2.owned[num])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Won()
        {
            if (Player1.money <= -1000)
            {
                MessageBox.Show("Trump Lost The Game");
                Player1.money = 2000;
                Player2.money = 2000;
                label1.Visible = false;
                label2.Visible = false;
                Player1.Index = 0;
                Player1Visual.Top = Buttons[0].Top;
                Player1Visual.Left = Buttons[0].Left;
                Player2.Index = 0;
                Player2Visual.Top = Buttons[0].Top;
                Player2Visual.Left = Buttons[0].Left;
            }
            if (Player2.money <= -1000)
            {
                MessageBox.Show("Obama Lost The Game");
                Player1.money = 2000;
                Player2.money = 2000;
                label1.Visible = false;
                label2.Visible = false;
                Player1.Index = 0;
                Player1Visual.Top = Buttons[0].Top;
                Player1Visual.Left = Buttons[0].Left;
                Player2.Index = 0;
                Player2Visual.Top = Buttons[0].Top;
                Player2Visual.Left = Buttons[0].Left;
            }
        }
        private int Whos(int slot)
        {
            if (Player1.owned[slot])
                return 1;
            else
                return 0;
            if (Player2.owned[slot])
                return 2;
            else
                return 0;
        }
    }
}

