using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris_Game.ClsTetromino;

namespace Tetris_Game
{
    internal class ClsTetromino
    {

        public enum ePiece { O_piece = 1, I_piece = 2, T_piece = 3,Z_piece = 4 , L_piece = 5, S_piece = 6, J_piece = 7 };

        public ePiece NamePiece { get; private set; }
        public string[,] Shape { get;  set; }
        public Color Color { get; private set; }
        // إحداثيات القطع في Board
        public int x { get; set; }
        public int y { get; set; }
        
        // إحداثيات المرجعة
        public sbyte i { get; set; }
        public sbyte j { get; set; }
        
        public ClsTetromino()
         {
            
         }
      
       
        void choicePiece(ePiece piece)
        {
          switch (piece)
          {
              case ePiece.O_piece:
                  O_piece();
                  break;

              case ePiece.I_piece:
                  I_piece();
                  break;

              case ePiece.T_piece:
                  T_piece();
                  break;

              case ePiece.L_piece:
                  L_piece();
                  break;

              case ePiece.Z_piece:
                  Z_piece();
                  break;

              case ePiece.S_piece:
                  S_piece();
                  break;

              case ePiece.J_piece:
                  J_piece();
                  break;

          }
            }

        public void I_piece()
        {
            NamePiece = ePiece.I_piece;

            Shape = new string[4, 4]
           {
             { "2F1", "2F1" ,"2F1", "2F1"}, 
             { "", "" ,"", ""}, 
             { "", "" ,"", ""}, 
             { "", "" ,"", ""},
           };
            i = 0;
            j = 0;
            
            x = 5; y = 0;
        } 
        public void O_piece()
        {
            NamePiece = ePiece.O_piece;

            Shape = new string[2, 2]
          {
             { "1F", "1F" },
             { "1F", "1F" },

          };
            i = 0;
            j = 0;

            x = 5; y = 0;
        } 
        public void T_piece()
        {

            NamePiece = ePiece.T_piece;

            Shape = new string[3, 3]
          {
             { "", "3F1" ,""},
             { "3F1", "3F1" ,"3F1"},
             { "", "" ,""},
          };
            i = 0;
            j = 0;

            x = 5; y = 0;
        } 
        public void Z_piece()
        {

            NamePiece = ePiece.Z_piece;

            Shape = new string[3, 3]
          {
             { "4F1", "4F1" ,""},
             { "", "4F1" ,"4F1"},
             { "", "" ,""},

          };

            i = 0;
            j = 0;

            x = 5; y = 0;
        }  
        public void S_piece()
        {
            NamePiece = ePiece.S_piece;

            Shape = new string[3, 3]
            {
             { "", "6F1" ,"6F1"},
             { "6F1", "6F1" ,""},
             { "", "" ,""},

            };
           
            x = 5; y = 0;
        }  
        public void J_piece()
        {
            NamePiece = ePiece.J_piece;

            Shape = new string[3, 3]
            {
             { "7F1", "" , "" }, // صف 1
             { "7F1", "7F1" , "7F1" }, // صف 2
             { "", "" , "" }, // صف 3
            };


            i = 0;
            j = 0;

            x = 5; y = 0;
        }
        public void L_piece()
        {
            NamePiece = ePiece.L_piece;

            Shape = new string[3, 3]
            {
             { "", "", "5F1" }, // صف 1
             { "5F1", "5F1", "5F1" }, // صف 2
             { "", "", "" }, // صف 3
            };

            i = 0;
            j = 0;

            x = 5; y = 0;
        }

        static public TextureBrush ColorPiece(int NumberPiece)
        {
            TextureBrush imageBrush;
            
            Image image;

            
            switch ((ePiece)NumberPiece)
            {
                case ePiece.O_piece:
                    image = Properties.Resources.TileYellow1 ;
                    return imageBrush = new TextureBrush(image);
                case ePiece.I_piece:
                    image = Properties.Resources.TileBlue1;
                    return imageBrush = new TextureBrush(image);
                case ePiece.T_piece:
                    image = Properties.Resources.TilePurple1;
                    return imageBrush = new TextureBrush(image);
                case ePiece.L_piece:
                    image = Properties.Resources.TileOrange1;
                    return imageBrush = new TextureBrush(image);
                case ePiece.Z_piece:
                    image = Properties.Resources.TileRed1;
                    return imageBrush = new TextureBrush(image);
                case ePiece.S_piece:
                    image = Properties.Resources.TileGreen1;
                    return imageBrush = new TextureBrush(image);
                case ePiece.J_piece:
                    image = Properties.Resources.TileCyan1;
                    return imageBrush = new TextureBrush(image);
            }
            return imageBrush = null;
        }

       public void S_PieceRotation()
       {
            if (Shape[1, 1].ToString()[2] != '2')   {
                Shape = new string[3, 3]
             {
             { "6F2", "" ,""},
             { "6F2", "6F2" ,""},
             { "", "6F2" ,""},

             };
            }

            else
            {
                Shape = new string[3, 3]
           {
             { "", "6F1" ,"6F1"},
             { "6F1", "6F1" ,""},
             { "", "" ,""},

           };
                if (x >= 8)
                {
                    x -= 2;
                };
            }
        }
       public void Z_PieceRotation()
       {
            if (Shape[1, 1].ToString()[2] != '2') {
                           
            Shape = new string[3, 3]
             {
             { "", "4F2" ,""},
             { "4F2", "4F2" ,""},
             { "4F2", "" ,""},

             };
            }
            else
            {
                Shape = new string[3, 3]
      {
             { "4F1", "4F1" ,""},
             { "", "4F1" ,"4F1"},
             { "", "" ,""},

      };

            }                if (x >= 8)
               
            {
                    x -= 2;
                }
        }
       public void T_PieceRotation()
       {
            switch (Shape[1, 1].ToString()[2])
            {
                case '1':
                    Shape = new string[3, 3]
            {
             { "", "3F2" ,""},
             { "", "3F2" ,"3F2"},
             { "", "3F2" ,""},
            };
                    break;
                
                case '2':
                    Shape = new string[3, 3]
            {
             { "", "" ,""},
             { "3F3", "3F3" ,"3F3"},
             { "", "3F3" ,""},
            };
                    break;
                
                case '3':
                    Shape = new string[3, 3]
            {
             { "", "3F4" ,""},
             { "3F4", "3F4" ,""},
             { "", "3F4" ,""},
            };
                    break;

                default:

                    Shape = new string[3, 3]
       {
             { "", "3F1" ,""},
             { "3F1", "3F1" ,"3F1"},
             { "", "" ,""},
       };
                    break;
            }
        }
       public void L_ieceRotation()
       {
            char Angle = ' ';
            if (Shape[0, 0] != "")
            {
                Angle = Shape[0, 0].ToString()[2];
            }
            else
            {
                Angle = Shape[1, 0].ToString()[2];
            }
            switch (Angle)
            {
                case '1':
                    Shape = new string[3, 3]
            {
             { "5F2", "5F2", "" }, 
             { "", "5F2", "" }, 
             { "", "5F2", "" },
            };
                    break;

                case '2':
                    Shape = new string[3, 3]
            {
             { "5F3", "5F3", "5F3" }, 
             { "5F3", "", "" }, 
             { "", "", "" },
            };
                    break;

                case '3':
                    Shape = new string[3, 3]
            {
              { "5F4", "", "" }, 
             { "5F4", "", "" }, 
             { "5F4", "5F4", "" },
            };
                    break;

                default:
                    Shape = new string[3, 3]
            {
             { "", "", "5F1" }, // صف 1
             { "5F1", "5F1", "5F1" }, // صف 2
             { "", "", "" }, // صف 3
            };
                    break;
            }
            if (x >= 8)
            {
              x -= 2;
            };
        }
       public void J_PieceRotation()
       {

            char Angle = ' ';
            
                for (int i = 0; i < Shape.GetLength(1);  i++)
                {
                    if (Shape[0,i] != "")
                    {
                        Angle = Shape[0, i].ToString()[2];
                    }
                }
            

            switch (Angle)
            {
                case '1':
                    Shape = new string[3, 3]
            {
                 { "7F2", "7F2" , "" }, // صف 1
                 { "7F2", "" , "" }, // صف 2
                 { "7F2", "" , "" }, // صف 3
            };
                    break;
 
                case '2':
                    Shape = new string[3, 3]
            {
              { "7F3", "7F3" , "7F3" }, // صف 1
             { "", "" , "7F3" }, // صف 2
             { "", "" , "" }, // صف 3
            };
                    break;
 
                case '3':
                    Shape = new string[3, 3]
            {
                  { "", "7F4" , "" }, // صف 1
                  { "", "7F4" , "" }, // صف 2
                  { "7F4", "7F4" , "" }, // صف 3
            };
                    break;
 
                default:
                    Shape = new string[3, 3]
            {
             { "7F1", "" , "" }, // صف 1
             { "7F1", "7F1" , "7F1" }, // صف 2
             { "", "" , "" }, // صف 3
            };
                    break;
            }
            if (x >= 8)
            {
                x -= 2;
            };
        }

       public void I_PieceRotation()
        {
            if (Shape[0, 0].ToString()[2] != '2')
            {
                Shape = new string[4, 4]
            {
             { "2F2", "" ,"", ""},
             { "2F2", "" ,"", ""},
             { "2F2", "" ,"", ""},
             { "2F2", "" ,"", ""},
            };
            }

            else
            {
                Shape = new string[4, 4]
         {
             { "2F1", "2F1" ,"2F1", "2F1"},
             { "", "" ,"", ""},
             { "", "" ,"", ""},
             { "", "" ,"", ""},
               
            };
                if (x >= 8)
                {
                    x -= 3;
                };
            }
        }

    }
}