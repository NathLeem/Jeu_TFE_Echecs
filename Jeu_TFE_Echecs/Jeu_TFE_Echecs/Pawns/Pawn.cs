using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Pawn : Piece
    {
        private bool _passant;
        private bool _notMove;

        public Pawn(int[] position, string color, string typePiece) : base(position, color, typePiece)
        {
            this._passant = false;
            this._notMove = true;
        }
        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = nColonne[0] - nColonne[1];

            if(Color == "black")
            {
                if (_notMove)
                {
                    if (deltaColonne == -2 || deltaColonne == -1 && nLigne[0] == nLigne[1])
                    {
                        movable = true;
                        _notMove = false;
                    }
                }
                else
                {
                    if (deltaColonne == -1 && nLigne[0] == nLigne[1])
                    {
                        movable = true;
                    }
                }
            }
            else
            {
                if (_notMove)
                {
                    if (deltaColonne == 2 || deltaColonne == 1 && nLigne[0] == nLigne[1])
                    {
                        movable = true;
                        _notMove = false;
                    }
                }
                else
                {
                    if (deltaColonne == 1 && nLigne[0] == nLigne[1])
                    {
                        movable = true;
                    }
                }
            }
              
            return movable;
        }
    }
}
