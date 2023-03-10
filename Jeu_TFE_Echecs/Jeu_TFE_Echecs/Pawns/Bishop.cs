using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Bishop : Piece
    {
        public Bishop(int[] position, string color, string typePïece) : base(position, color, typePïece)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            return movable;
        }
    }
}
