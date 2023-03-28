using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class King : Piece
    {
        private bool _check;
        private bool _checkMate;

        public King(int[] position, string color, string typePiece, sbyte id) : base(position, color, typePiece, id)
        {
            _check = false;
            _checkMate = false;
        }

        public override bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate)
        {
            bool movable = false;

            int deltaLigne = Math.Abs(nLigne[0] - nLigne[1]);
            int deltaColonne = Math.Abs(nColonne[0] - nColonne[1]);
            int sommeDelta = Math.Abs(deltaColonne + deltaLigne);

            if (sommeDelta <= 2 && deltaLigne != 2 && deltaColonne != 2)
            {
                if(memPlate[nColonne[1], nLigne[1]] != null)
                {
                    if (memPlate[nColonne[0], nLigne[0]].Color != memPlate[nColonne[1], nLigne[1]].Color)
                    {
                        movable = true;
                    }
                }             
            }
            return movable;
        }
    }
}
