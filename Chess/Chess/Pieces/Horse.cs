using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Horse : Piece
    {
        public Horse(int[] position, string color) : base(position, color)
        {

        }
        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaColonne = Math.Abs(_position[0] - nColonne[1]);
            int deltaLigne = Math.Abs(_position[1] - nLigne[1]);

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

            if (movable)
            {
                _position[0] = nColonne[1];
                _position[1] = nLigne[1];

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
