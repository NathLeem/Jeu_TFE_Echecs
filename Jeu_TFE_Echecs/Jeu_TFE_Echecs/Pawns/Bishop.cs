using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Bishop : Piece
    {
        public Bishop(int[] position, string color, string typePiece) : base(position, color, typePiece)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);
            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);

            if (deltaLigne == deltaColonne)
            {
                movable = true;
            }

            return movable;
        }
    }
}
