using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Pawn : Piece
    {
        private bool _passant;
        private bool _notMove;

        public Pawn(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {
            this._passant = false;
            this._notMove = true;
        }
        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = nColonne[0] - nColonne[1];
            int deltaLigne = nLigne[0] - nLigne[1];
         
            if (Color == "black")
            {
                if (_notMove)
                {
                    if (deltaColonne == -2 || deltaColonne == -1 && nLigne[0] == nLigne[1])
                    {
                        if (deltaColonne == -2)
                        {
                            if (memPlate[2, nLigne[0]] == null)
                            {
                                movable = true;
                            }
                        }
                        _notMove = false;
                    }
                }
                else
                {
                    if ((deltaColonne == -1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == -1))
                    {
                        if (Math.Abs(deltaLigne) == 1 && deltaColonne == -1)
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null)
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color)
                                {
                                    movable = true;
                                }
                            }
                        }
                        else if (deltaColonne == -1 && nLigne[0] == nLigne[1])
                        {
                            if (memPlate[nColonne[1], nLigne[1]] == null)
                            {
                                movable = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (_notMove)
                {
                    if ((deltaColonne == 2 || deltaColonne == 1) && nLigne[0] == nLigne[1])
                    {
                        if (deltaColonne == 2)
                        {
                            if (memPlate[5, nLigne[0]] == null)
                            {
                                movable = true;
                            }
                        }

                        _notMove = false;
                    }
                }
                else
                {
                    if ((deltaColonne == 1 && nLigne[0] == nLigne[1]) || (Math.Abs(deltaLigne) == 1 && deltaColonne == 1))
                    {
                        if(Math.Abs(deltaLigne) == 1 && deltaColonne == 1)
                        {
                            if (memPlate[nColonne[1], nLigne[1]] != null)
                            {
                                if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color)
                                {
                                    movable = true;
                                }
                            }
                        }                   
                        else if(deltaColonne == 1 && nLigne[0] == nLigne[1])
                        {
                            if(memPlate[nColonne[1], nLigne[1]] == null)
                            {
                                movable = true;
                            }                          
                        }
                        
                    }
                }
            }

            if (memPlate[nColonne[1], nLigne[1]] != null)
            {
                if (memPlate[nColonne[0], nLigne[0]].Color == memPlate[nColonne[1], nLigne[1]].Color)
                {
                    movable = false;
                }
            }
            return movable;
        }

    }
}
