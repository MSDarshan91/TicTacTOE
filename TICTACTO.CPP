#include<stdio.h>
#include<stdlib.h>
#include <graphics.h>
#include <conio.h>
#include<dos.h>
union REGS in, out;
int count=0,button,mx,my;
char board [3] [3]; // Remeber Indexing Starts at zer0
void drawcircle (int position) // Draws a circle on basis of Input use mathematics reduce complexity

 {
   int centrex;
   int centrey;
   centrex = 245 + (50*(position%3)) + 25;
   centrey = 165 + (50*(position/3)) + 25;
   fillellipse (centrex,centrey, 10,10);

 }

void drawcross (int position)

{

   int centrex;
   int centrey;
   centrex = 245 + (50*(position%3)) + 25;
   centrey = 165 + (50*(position/3)) + 25;
   line (centrex-5,centrey+5,centrex+5,centrey-5);
   line (centrex+5,centrey+5,centrex-5,centrey-5);


}

void mapboard ()
{
 int gdriver = DETECT, gmode;
 int i,j;
 closegraph ();
 initgraph (&gdriver, &gmode, "d:\\tc\\bgi");
 // Draw 4 Lines to Form Board
 line (295,165,295,315);
 line (345,165,345,315);
 line (245,215,395,215);
 line (245,265,395,265);
 for (i = 0; i <= 2; i++)
  {
    for (j = 0; j <= 2; j++)
     {
      if ( board [i] [j]  == 'X') drawcross (3*i + j);
      if ( board [i] [j]  == 'O') drawcircle (3*i + j);
     }
  }
}

void initiateboard ()
{
 int i,j;
 for (i = 0; i < 3 ; i++)
 {
  for (j = 0; j < 3; j++)
  {
      board [i] [j] = '*';
      putchar (board [i] [j]);

  }
 }
mapboard ();
}
void mouse_enable(void)
{
   _AX=1;
   geninterrupt(0x33);
}	/* mouse_enable */


/*----------------------------------------------------------------------*/

void mouse_disable(void)
{
   _AX=2;
   geninterrupt(0x33);
}	/* mouse_disable */

/*----------------------------------------------------------------------*/

void mouse_read_cursor(void)
{
   _AX=3;
   geninterrupt(0x33);
   button=_BX;
   mx=_CX;
   my=_DX;
}	/* mouse_read_cursor */

/*----------------------------------------------------------------------*/

void mouse_horizontal_range(int xmin, int xmax)
{
   _AX=7;
   _CX=xmin;
   _DX=xmax;
   geninterrupt(0x33);
}	/* mouse_vertical_range */

/*----------------------------------------------------------------------*/

void mouse_vertical_range(int ymin, int ymax)
{
   _AX=8;
   _CX=ymin;
   _DX=ymax;
   geninterrupt(0x33);
}	/* mouse_vertical_range */



void input ()

{
 int x,y,flag=0;
 while(!flag)
 {
    mouse_enable();
    mouse_horizontal_range(245, 395);
	mouse_vertical_range(165, 315);
    mouse_read_cursor();
	 if(button==1)
	 {
		 if(mx>245 && mx<295 && my>165 && my<215)
			x=0,y=0,flag=1;
		 else if(mx>295 && mx<345 && my>165 && my<215)
			x=0,y=1,flag=1;
		 else if(mx>345 && mx<395 && my>165 && my<215)
			x=0,y=2,flag=1;
		 else if(mx>245 && mx<295 && my>215 && my<265)
			x=1,y=0,flag=1;
		 else if(mx>295 && mx<345 && my>215 && my<265)
			x=1,y=1,flag=1;
		 else if(mx>345 && mx<395 && my>215 && my<265)
			x=1,y=2,flag=1;
		 else if(mx>245 && mx<295 && my>265 && my<315)
			x=2,y=0,flag=1;
		 else if(mx>295 && mx<345 && my>265 && my<315)
			x=2,y=1,flag=1;
		 else if(mx>345 && mx<395 && my>265 && my<315)
			x=2,y=2,flag=1;
	 }
	mouse_disable();
	}
	if (board [x][y] == '*')
		board [x][y] = 'X';
	else
	{

		input();
	}
}
int horwin()
{
	int a=0,i;
	for(i=0;i<3;i++)
	{
		if((board[i][0]==board[i][1])&&(board[i][0]=='O')&&board[i][2]=='*')
			board[i][2]='O',a=1;
		else if((board[i][0]==board[i][2])&&(board[i][0]=='O')&&board[i][1]=='*')
			board[i][1]='O',a=1;
		else if((board[i][1]==board[i][2])&&(board[i][1]=='O')&&board[i][0]=='*')
			board[i][0]='O',a=1;
	}
	return a;
}
int verwin()
{
	int a=0,i;
	for(i=0;i<3;i++)
	{
		if((board[0][i]==board[1][i])&&(board[0][i]=='O')&&board[2][i]=='*')
			board[2][i]='O',a=1;
		else if((board[0][i]==board[2][i])&&(board[0][i]=='O')&&board[1][i]=='*')
			board[1][i]='O',a=1;
		else if((board[1][i]==board[2][i])&&(board[1][i]=='O')&&board[0][i]=='*')
			board[0][i]='O',a=1;
	}
	return a;
}
int diagwin()
{
	int a=0,i;
	if((board[0][0]==board[1][1])&&board[1][1]=='O'&&board[2][2]=='*')
		board[2][2]='O',a=1;
	else if((board[0][0]==board[2][2])&&board[2][2]=='O'&&board[1][1]=='*')
		board[1][1]='O',a=1;
	else if((board[2][2]==board[1][1])&&board[1][1]=='O'&&board[0][0]=='*')
		board[0][0]='O',a=1;
	else if((board[0][2]==board[1][1])&&board[1][1]=='O'&&board[2][0]=='*')
		board[2][0]='O',a=1;
	else if((board[0][2]==board[2][0])&&board[0][2]=='O'&&board[1][1]=='*')
		board[1][1]='O',a=1;
	else if((board[1][1]==board[2][0])&&board[1][1]=='O'&&board[0][2]=='*')
		board[0][2]='O',a=1;
	return a;
}

int win()
{
	int a,b,c;
	a=horwin();
	if(a==0)
		b=verwin();
	if(b==0 && a==0)
		c=diagwin();
	return(a||b||c);
}
int horcheck()
{
	int a=0,i;
	for(i=0;i<3;i++)
	{
		if((board[i][0]==board[i][1])&&(board[i][0]=='X')&&board[i][2]=='*')
			board[i][2]='O',a=1;
		else if((board[i][0]==board[i][2])&&(board[i][0]=='X')&&board[i][1]=='*')
			board[i][1]='O',a=1;
		else if((board[i][1]==board[i][2])&&(board[i][1]=='X')&&board[i][0]=='*')
			board[i][0]='O',a=1;
	}
	return a;
}
int vercheck()
{
	int a=0,i;
	for(i=0;i<3;i++)
	{
		if((board[0][i]==board[1][i])&&(board[0][i]=='X')&&board[2][i]=='*')
			board[2][i]='O',a=1;
		else if((board[0][i]==board[2][i])&&(board[0][i]=='X')&&board[1][i]=='*')
			board[1][i]='O',a=1;
		else if((board[1][i]==board[2][i])&&(board[1][i]=='X')&&board[0][i]=='*')
			board[0][i]='O',a=1;
	}
	return a;
}
int diagcheck()
{
	int a=0,i;
	if((board[0][0]==board[1][1])&&board[1][1]=='X'&&board[2][2]=='*')
		board[2][2]='O',a=1;
	else if((board[0][0]==board[2][2])&&board[2][2]=='X'&&board[1][1]=='*')
		board[1][1]='O',a=1;
	else if((board[2][2]==board[1][1])&&board[1][1]=='X'&&board[0][0]=='*')
		board[0][0]='O',a=1;
	else if((board[0][2]==board[1][1])&&board[1][1]=='X'&&board[2][0]=='*')
		board[2][0]='O',a=1;
	else if((board[0][2]==board[2][0])&&board[0][2]=='X'&&board[1][1]=='*')
		board[1][1]='O',a=1;
	else if((board[1][1]==board[2][0])&&board[1][1]=='X'&&board[0][2]=='*')
		board[0][2]='O',a=1;
	return a;
}

int check1()
{
	int a,b,c;
	a=horcheck();
	if(a==0)
		b=vercheck();
	if(b==0 && a==0)
		c=diagcheck();
	return(a||b||c);
}
int darshan()
{
	int a=0,i;
	if((board[0][0]==board[1][1])&&board[1][1]=='X'&&board[2][2]=='O'&&board[2][0]=='*')
		board[2][0]='O',a=1;
	else if((board[0][0]==board[2][2])&&board[2][2]=='X'&&board[1][1]=='O'&&board[2][1]=='*')
		board[2][1]='O',a=1;
	else if((board[2][2]==board[1][1])&&board[1][1]=='X'&&board[0][0]=='O'&&board[2][0]=='*')
		board[2][0]='O',a=1;
	else if((board[0][2]==board[1][1])&&board[1][1]=='X'&&board[2][0]=='O'&&board[2][2]=='*')
		board[2][2]='O',a=1;
	else if((board[0][2]==board[2][0])&&board[0][2]=='X'&&board[1][1]=='O'&&board[2][1]=='*')
		board[2][1]='O',a=1;
	else if((board[1][1]==board[2][0])&&board[1][1]=='X'&&board[0][2]=='O'&&board[2][0]=='*')
		board[2][0]='O',a=1;
	return a;
}

void computer ()
{
 int a=0,b=0,c=0,i,j;
 a=win();
 if(a==0 && count == 1 || count == 2)
	b=darshan();
 if(b==0)
	c=check1();
 count++;
 if(a==0 && b==0 && c==0)
 {
	 if(board[1][1]=='*')
		 board[1][1]= 'O';
	 else
	 {
		for (i = 0; i < 3; i++)
			for (j = 0; j < 3; j++)
			{
				if (board [i] [j] == '*')
				{
					board [i] [j] = 'O';
					return;
				}

			}
	 }
 }
}

void check ()

{
  int i;
  char key = '*';
  // Check Rows
  for (i=0; i<3;i++)
  if (board [i][0] == board [i] [1] && board [i][0] == board [i] [2] && board [i] [0] != '*') key = board [i] [0];
  // check Columns
  for (i=0; i<3;i++)
  if (board [0][i] == board [1] [i] && board [0][i] == board [2] [i] && board [0] [i] != '*') key = board [0] [i];
  // Check Diagonals
  if (board [0][0] == board [1] [1] && board [1][1] == board [2] [2] && board [1] [1] != '*') key = board [1] [1];
  if (board [0][2] == board [1] [1] && board [1][1] == board [2] [0] && board [1] [1] != '*') key = board [1] [1];

  //Declare Winner if any

  if (key == 'X')
  {
   printf ("You Win");
   getch ();
   exit (1);
  }

  if (key == 'O')
  {
   printf ("Computer Win");
   getch ();
   exit (1);
  }



}

void play () // Ladies and Gentleman I give you our game engine.
{
  int i;
  for (i = 0; i<5;i++)
  {
   input ();
   computer ();
   mapboard ();
   check ();
  }
 printf ("\n\nGAME DRAW");

}


void main ()

{
 int gdriver = DETECT, gmode;
 initgraph (&gdriver, &gmode,"D:\TC\BGI");
 initiateboard ();
 play ();
 getch ();
 closegraph ();
}