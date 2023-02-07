using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs
{
    class Pawn : Piece
    {
        private bool _passant;
        private bool _notMove;

        public Pawn(int[] position, string color) : base(position, color)
        {
            this._passant = false;
            this._notMove = false;
        }
    }
}
