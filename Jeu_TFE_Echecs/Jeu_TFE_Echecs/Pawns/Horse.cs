using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class Horse : Piece 
    {
        public Horse(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {

        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);
            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);

            if ((deltaLigne == 2 && deltaColonne == 1) || (deltaLigne == 1 && deltaColonne == 2))
            {
                movable = true;
            }

            if (memPlate[nColonne[1], nLigne[1]] != null)
            {
                if (_color == memPlate[nColonne[1], nLigne[1]].Color)
                {
                    movable = false;
                }
            }

            return movable;
        }
    }
}
