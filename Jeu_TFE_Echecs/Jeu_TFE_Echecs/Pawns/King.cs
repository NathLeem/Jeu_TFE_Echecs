using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs.Pawns
{
    class King : Piece
    {
        private bool _check;
        private bool _checkMate;

        public King(int[] position, string color, string typePiece) : base(position, color, typePiece)
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
                movable = true;
            }

            return movable;
        }
    }
}
