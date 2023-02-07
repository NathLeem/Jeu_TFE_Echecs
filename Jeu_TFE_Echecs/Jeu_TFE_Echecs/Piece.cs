using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs
{
    class Piece
    {
        protected bool _dead;
        protected int[] _position = new int[2];
        protected string _color;
        private List<string> _moves = new List<string>();

        public Piece(int[] position, string color)
        {
            _dead = false;
            this._position = position;
            this._color = color;
        }
    }
}
