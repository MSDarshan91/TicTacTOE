using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reset();
        }
        char[,] board = new char [3,3];
        int cnt,diff=1;
        char x,o;
        bool turn;
        void reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                { board[i, j] = '*'; }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ResetText();
                }
            }
            cnt = 0;
            x = 'X';
            o = 'O';
            turn = true;
        }
    bool horwin()
    {
	    bool a=false;
        int i;
	    for(i=0;i<3;i++)
	    {
    		if((board[i,0]==board[i,1])&&(board[i,0]=='O')&&board[i,2]=='*')
            {
    			cplay(i,2);
                a=true;
            }
	    	else if((board[i,0]==board[i,2])&&(board[i,0]=='O')&&board[i,1]=='*')
		    {
                cplay(i,1);
                a=true;
            }
            else if ((board[i, 1] == board[i, 2]) && (board[i, 1] == 'O') && board[i, 0] == '*')
            {
                cplay(i, 0);
                a = true;
            }
	    }
	    return a;
    }
    bool verwin()
    {
	    bool a=false;
	    for(int i=0;i<3;i++)
	    {
		    if((board[0,i]==board[1,i])&&(board[0,i]=='O')&&board[2,i]=='*')
			{
                cplay(2,i);
                a=true;
            }
		    else if((board[0,i]==board[2,i])&&(board[0,i]=='O')&&board[1,i]=='*')
            {
                cplay(1,i);
                a=true;
            }
            else if ((board[1, i] == board[2, i]) && (board[1, i] == 'O') && board[0, i] == '*')
            {
                cplay(0, i);
                a = true;
            }
	    }
	    return a;
    }
    bool diagwin()
    {
	    bool a=false;
	    if((board[0,0]==board[1,1])&&board[1,1]=='O'&&board[2,2]=='*')
		{
             cplay(2, 2);
             a=true;
        }
	    else if((board[0,0]==board[2,2])&&board[2,2]=='O'&&board[1,1]=='*')
		{
             cplay(1,1);
             a=true;
        }
	    else if((board[2,2]==board[1,1])&&board[1,1]=='O'&&board[0,0]=='*')
		{
            cplay(0,0);
            a=true;
        }

    	else if((board[0,2]==board[1,1])&&board[1,1]=='O'&&board[2,0]=='*')
        {
		    cplay(2,0);
            a=true;
        }
	    else if((board[0,2]==board[2,0])&&board[0,2]=='O'&&board[1,1]=='*')
		{
            cplay(1,1);
            a=true;
        }
        else if ((board[1, 1] == board[2, 0]) && board[1, 1] == 'O' && board[0, 2] == '*')
        {
            cplay(0, 2);
            a = true;
        }
	    return a;
    }

    bool win()
    {
            bool a, b=false, c=false;
            a = horwin();
            if (a == false)
                b = verwin();
            if (b == false && a == false)
                c = diagwin();
            return (a || b || c);
    }
    bool horcheck()
    {
	    bool a=false;
	    for(int i=0;i<3;i++)
	    {
		    if((board[i,0]==board[i,1])&&(board[i,0]=='X')&&board[i,2]=='*')
            {   cplay(i,2);
                a=true;}
	    	else if((board[i,0]==board[i,2])&&(board[i,0]=='X')&&board[i,1]=='*')
            {	cplay(i,1);
                a=true;}
            else if ((board[i, 1] == board[i, 2]) && (board[i, 1] == 'X') && board[i, 0] == '*')
            { cplay(i, 0); 
                a = true; }
	    }
	    return a;
    }
    bool vercheck()
    {
	    bool a=false;
	    for(int i=0;i<3;i++)
	    {
		    if((board[0,i]==board[1,i])&&(board[0,i]=='X')&&board[2,i]=='*')
            {cplay(2,i);
                a=true;}
		    else if((board[0,i]==board[2,i])&&(board[0,i]=='X')&&board[1,i]=='*')
			{cplay(1,i);
                a=true;}
            else if ((board[1, i] == board[2, i]) && (board[1, i] == 'X') && board[0, i] == '*')
            { cplay(0, i);
                a = true; }
	    }
	    return a;
    }
    bool diagcheck()
    {
	    bool a=false;
	    if((board[0,0]==board[1,1])&&board[1,1]=='X'&&board[2,2]=='*')
		{cplay(2,2);
            a=true;}
	    else if((board[0,0]==board[2,2])&&board[2,2]=='X'&&board[1,1]=='*')
		{cplay(1,1);
            a=true;}
	    else if((board[2,2]==board[1,1])&&board[1,1]=='X'&&board[0,0]=='*')
		{cplay(0,0);
            a=true;}
	    else if((board[0,2]==board[1,1])&&board[1,1]=='X'&&board[2,0]=='*')
		{cplay(2,0);
            a=true;}
	    else if((board[0,2]==board[2,0])&&board[0,2]=='X'&&board[1,1]=='*')
		{cplay(1,1);
            a=true;}
        else if ((board[1, 1] == board[2, 0]) && board[1, 1] == 'X' && board[0, 2] == '*')
        { cplay(0, 2);
            a = true; }
	    return a;
    }

    bool check1()
    {
           bool a, b=false, c=false;
            a = horcheck();
            if (a == false)
                b = vercheck();
            if (b == false && a == false)
                c = diagcheck();
            return (a || b || c);
    }
    bool darshan()
    {
	    bool a=false;
	    if((board[0,0]==board[1,1])&&board[1,1]=='X'&&board[2,2]=='O'&&board[2,0]=='*')
		{cplay(2,0);
            a=true;}
	    else if((board[0,0]==board[2,2])&&board[2,2]=='X'&&board[1,1]=='O'&&board[2,1]=='*')
		{cplay(2,1);
            a=true;}
	    else if((board[2,2]==board[1,1]) && board[1,1]=='X' && board[0,0]=='O' && board[0,2]=='*')
		{cplay(0,2);
            a=true;}
	    else if((board[0,2]==board[1,1])&&board[1,1]=='X'&&board[2,0]=='O'&&board[2,2]=='*')
		{cplay(2,2);
            a=true;}
	    else if((board[0,2]==board[2,0])&&board[0,2]=='X'&&board[1,1]=='O'&&board[2,1]=='*')
		{cplay(2,1);
            a=true;}
        else if ((board[1, 1] == board[2, 0]) && board[1, 1] == 'X' && board[0, 2] == 'O' && board[2, 0] == '*')
        { cplay(2, 0);
            a = true; }
	    return a;
    }

    void computer()
    {
        bool a = false, b = false, c = false, abc = false;
        int i, j;
        if (diff == 1)
        {
            if (board[1, 1] == '*')
                cplay(1, 1);
            else
            {
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (board[i, j] == '*')
                        {
                            cplay(i, j);
                            abc = true;
                            break;
                        }
                    }
                    if (abc)
                        break;
                }
            }
        }
        else
        {
            a = win();
            abc = false;
            if (a == false && diff == 3 && (cnt == 2 || cnt == 3))
                b = darshan();
            if (a==false && b == false )
                c = check1();
             if (a == false && b == false && c== false)
            {
                if (board[1, 1] == '*')
                    cplay(1, 1);
                else
                {
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            if (board[i, j] == '*')
                            {
                                cplay(i, j);
                                abc = true;
                                break;
                            }
                        }
                        if (abc)
                            break;
                    }
                }
            }
        }
    }
    void cplay(int i, int j)
    {
        Label cmp = link(i, j);
        cmp.Text = o.ToString();
        board[i, j] = o;
        cnt++;
        checkwin();
    }
        bool play(int l, int m)
        {
            if (board[l, m] == '*')
            {
                Label ctrl = link(l, m);
                ctrl.Text = x.ToString();
                cnt++;
                board[l, m] = x ;
                checkwin();
                return true;
            }
            else
                return false;
        }

        Label link(int l, int m)
        {
            if (l == 0)
            {
                if (m == 0)
                    return label1;
                if (m == 1)
                    return label2;
                if (m == 2)
                    return label3;
            }
            if (l == 1)
            {
                if (m == 0)
                    return label4;
                if (m == 1)
                    return label5;
                if (m == 2)
                    return label6;
            }
            if (l == 2)
            {
                if (m == 0)
                    return label7;
                if (m == 1)
                    return label8;
                if (m == 2)
                    return label9;
            }
            return null;
        }
        void checkwin()
        {
            int i;
            char key = '*';
            // Check Rows
            if (cnt > 4)
            {
                for (i = 0; i < 3; i++)
                    if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != '*') key = board[i, 0];
                // check Columns
                for (i = 0; i < 3; i++)
                    if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] != '*') key = board[0, i];
                // Check Diagonals
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[1, 1] != '*') key = board[1, 1];
                if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[1, 1] != '*') key = board[1, 1];

                //Declare Winner if any

                if (key == 'X')
                {
                    turn = false;
                    declare("You WIN");

                }

                else if (key == 'O')
                {
                    turn = false;
                    declare("Computer Wins");
                }
                else if (cnt == 9)
                {
                    turn = false;
                    declare("Draw");
                }
            }
        }
        void declare(string str)
        {
            if (MessageBox.Show(str + " Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                Application.Exit();
            }
            else
                reset();
        }
            



        private void label1_Click(object sender, EventArgs e)
        {
            if (play(0, 0) && turn == true)
                computer();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (play(0, 1) && turn == true)
                computer();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (play(0, 2) && turn == true)
                computer();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (play(1, 0) && turn == true)
                computer();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (play(1,1) && turn == true)
                computer();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (play(1, 2) && turn == true)
                computer();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (play(2, 0) && turn == true)
                computer();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (play(2, 1) && turn == true)
                computer();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (play(2,2) && turn == true)
                computer();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlyone();
            easyToolStripMenuItem.Checked = true;
            diff = 1;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlyone();
            mediumToolStripMenuItem.Checked = true;
            diff = 2;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlyone();
            hardToolStripMenuItem.Checked = true;
            diff = 3;
        }
        void onlyone()
        {
            easyToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = false;
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a  simple game  in which  Win  is achieved when\nthree consecutive blocks in a Row, Column or Diagonal\nare occupied before the opponent does the same.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: M.S.Darshan\nudaydarshan@gmail.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }


        







    }
}
