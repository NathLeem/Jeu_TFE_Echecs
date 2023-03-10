using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs
{
    abstract class Piece
    {
        protected int[] _position = new int[2];
        protected string _color;
        protected string _typePiece;
        private List<string> _moves = new List<string>();

        public Piece(int[] position, string color, string typePiece)
        {
            this._position = position;
            this._color = color;
            this._typePiece = typePiece;
        }

        public abstract bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate);

        public string TypePiece
        {
            get { return _typePiece; }
        }
        public string Color
        {
            get { return _color; }
        }
    }
}
