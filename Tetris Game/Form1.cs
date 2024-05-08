using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Game.Properties;
using static Tetris_Game.ClsTetromino;
using System.Numerics;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;
using WMPLib;

namespace Tetris_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            GetNewPiece();
            PlaceThePieceInBoard();

            player.URL = "C:\\Original Tetris theme (Tetris Soundtrack) (320 kbps).mp3";
            playerRemoveCompleteLines.URL = "C:\\videoplayback.m4a";
            player2.URL = "C:\\videoplayback2.m4a";

            player2.settings.volume = 5;
            player.settings.volume = 3;
        }

        List<int> RowToDelete = new List<int>();


        WindowsMediaPlayer player = new WindowsMediaPlayer();
        WindowsMediaPlayer playerRemoveCompleteLines = new WindowsMediaPlayer();
        WindowsMediaPlayer player2 = new WindowsMediaPlayer();

        string[,] Board = new string[20, 10];
        enum enPiece { O_piece = 1, I_piece = 2, T_piece = 3, L_piece = 4, Z_piece = 5, S_piece = 6, J_piece = 7 };

        ClsTetromino piece = new ClsTetromino();


        public  int CharToInt(char c)
        {
            if (!char.IsDigit(c))
            {
                throw new ArgumentException("يجب أن يكون char رقمًا.");
            }

            return c - '0';
        }


        public void GetNewPiece()
         {      

            Random random = new Random();
            sbyte Number_Piece = (sbyte)random.Next(1, 8);
           

            switch ((enPiece)Number_Piece)
            {
                case enPiece.O_piece:
                    piece.O_piece();
                    break;

                case enPiece.I_piece:
                    piece.I_piece();
                    break;

                case enPiece.T_piece:
                    piece.T_piece();
                    break;

                case enPiece.L_piece:
                    piece.L_piece();
                    break;

                case enPiece.Z_piece:
                    piece.Z_piece();
                    break;

                case enPiece.S_piece:
                    piece.S_piece();
                    break;

                case enPiece.J_piece:
                    piece.J_piece();
                    break;
                
            }

         }

        void PlaceThePieceInBoard()
        {
            for(int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {
                    if (piece.Shape[i,j] != "")
                    { 
                    int absoluteX = piece.x + j;
                    int absoluteY = piece.y + i;
                    
                    Board[absoluteY, absoluteX] = piece.Shape[i, j];
                    }
                }
            }
        }

        void DrawBoard(Graphics g, int squareSize)
        {
            Pen gridPen = new Pen(Color.White);
          

            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    int x = (col * squareSize)+150;
                    int y = row * squareSize;

                    // رسم شبكة الخانات
                    g.DrawRectangle(gridPen, x, y, squareSize, squareSize);

                    // ملء المربعات المشغولة
                    if (Board[row, col] != ""&& Board[row, col] !=null)
                    {
                        g.FillRectangle(ClsTetromino.ColorPiece(CharToInt(Board[row, col].ToString()[0])), x + 1, y + 1, squareSize - 2, squareSize - 2);
                    } 
                    
                  
                }
            }
        }
        
        void DrawBoard2( int squareSize)
        {
            Graphics g = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black);

            

            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    int x = (col * squareSize)+150;
                    int y = row * squareSize;

                   
                    // ملء المربعات المشغولة
                    if (Board[row, col] != "" && Board[row, col] != null)
                    { 
                        if(Board[row, col].ToString()[1] != 'F' && row < 3)
                    {
                        GameOver();
                            return;
                    }
                        g.FillRectangle(ClsTetromino.ColorPiece(CharToInt(Board[row, col].ToString()[0])), x + 1, y + 1, squareSize - 2, squareSize - 2);
                    } 
                    else
                    {
                        g.FillRectangle(blackPen.Brush, x + 1, y + 1, squareSize - 2, squareSize - 2);
                    }

                   


                }
            }
        }

        void MovePieceDown()
       {

            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = null;
                    }
                }
            }  
            
            piece.y++;


            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = piece.Shape[i,j];
                    }
                }
            }

        }

        void MoveLeftOrRight(bool isLeft)
        {
            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = null;
                    }
                }
            }

            piece.x = (isLeft)? piece.x -=1 : piece.x +=1;


            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = piece.Shape[i, j];
                    }
                }
            }
        }
        bool CheckCollision( int x, int y)
        {
           
            string[,] rotation = piece.Shape;


            for (int i = 0; i < rotation.GetLength(0); i++)
            {
                for (int j = 0; j < rotation.GetLength(1); j++)
                {
                    
                    if (rotation[i, j] != "")
                    {
                        
                        int absoluteX = x + j ;
                        int absoluteY = y + i;

                      
                        if (absoluteX < 0 || absoluteX >= Board.GetLength(1) || absoluteY >= Board.GetLength(0))
                        {
                            return true; // Collision detected
                        }

                        // Check if the block overlaps with an existing block on the grid
                        if (absoluteY >= 0 && Board[absoluteY, absoluteX] != null && Board[absoluteY, absoluteX].ToString()[1] != 'F')
                        {
                            return true; // Collision detected
                        }
                    }
                }
            }

            // No collision detected
            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics, 30);
        }

        private bool PieceStability()
        {
            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = piece.Shape[i, j].ToString()[0]+"S";
                    }
                }
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            player.controls.play() ;
            

            if (!CheckCollision( piece.x, piece.y + 1)) { 
            MovePieceDown();
            DrawBoard2( 30);
            }
               

            else
            {
                
                player2.controls.play();
                PieceStability();
                GetNewPiece();
            } 
            if (CheckLineComplete())
                {
                    ExitThePieceFromTheBoard();
                }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && !CheckCollision(piece.x, piece.y + 1))
            {
                MovePieceDown();
                DrawBoard2( 30);
                return;
            }
             if (e.KeyCode == Keys.Left && !CheckCollision(piece.x - 1, piece.y ))
            {
                MoveLeftOrRight(true);
                DrawBoard2( 30);
                return;
            }
          

            if (e.KeyCode == Keys.Right && !CheckCollision(piece.x + 1, piece.y ))
            {
                MoveLeftOrRight(false);
                DrawBoard2( 30);
                return;
            } 
           

             if (e.KeyCode == Keys.Up && piece.NamePiece != ePiece.O_piece )
            {
                DeletePiece();
                string[,] rotation = piece.Shape;

                PieceRotation();

                if (CheckCollision(piece.x, piece.y))
                {
                    piece.Shape = rotation;
                }
                DrawBoard2( 30);
                
              
                return;
            }
        }

        private bool CheckLineComplete()
        {
            
            for (int i = Board.GetLength(0)-1; i >= 0; i--)
            {
                for (int j = Board.GetLength(1)-1 ; j >= 0; j--)
                {

                     if (Board[i,j] == null || Board[i, j].ToString()[1] != 'S')
                     {
                         break; // Collision detected
                     }
                     if(j == 0)
                     {
                        RowToDelete.Add(i);
                     }
                }
            }
            if (RowToDelete.Count > 0)
                return true;
            else
            return false;
        }

        private void RemoveCompleteLines(int RowToDelete2,int LandingRow)
        {


                for (int j = 0; j < Board.GetLength(1); j++)
                {

                    Board[RowToDelete2, j] = null;
                }
           
            
            for (int i = RowToDelete2; i > LandingRow; i--)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                   
                        Board[i, j] = Board[i-1, j];
                    
                }
            }

        }

        private void PieceRotation()
        {
            
            switch (piece.NamePiece)
            {
                case ePiece.I_piece:
                    piece.I_PieceRotation();
                    break;

                case ePiece.T_piece:
                    piece.T_PieceRotation();
                    break;

                case ePiece.L_piece:
                    piece.L_ieceRotation();
                    break;

                case ePiece.Z_piece:
                    piece.Z_PieceRotation();
                    break;

                case ePiece.S_piece:
                    piece.S_PieceRotation();
                    break;

                case ePiece.J_piece:
                    piece.J_PieceRotation();
                    break;

            }
        }

        void DeletePiece() 
        {
            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {

                    if (piece.Shape[i, j] != "")
                    {

                        int absoluteX = piece.x + j;
                        int absoluteY = piece.y + i;


                        Board[absoluteY, absoluteX] = null;
                    }
                }
            }
        }

        void ExitThePieceFromTheBoard()
        {
            if(RowToDelete.Count() == 1)
            {
                RemoveCompleteLines(RowToDelete[0],0);
                RowToDelete.Clear();
                return;
            }
            for (int i = 0; i  < RowToDelete.Count();i++)
            {
                if (i+1 != RowToDelete.Count()) { 
                    RemoveCompleteLines(RowToDelete[i], RowToDelete[i+1]) ;
                }
                else
                {
                    RemoveCompleteLines(RowToDelete[i], 0);
                }

            }
            RowToDelete.Clear();

            playerRemoveCompleteLines.controls.play();
        }

        private void GameOver()
        {

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {

                    Board[i, j] = null;

                }
            }
            DrawBoard2(30);

            Form2 form2 = new Form2();
            form2.ShowDialog();


            if(form2.Bt == Form2.enBt.eBtYes)
            {
                form2.Close();
            }
            else
            {
                form2.Close();
                this.Close();
            }
        }

    }
}