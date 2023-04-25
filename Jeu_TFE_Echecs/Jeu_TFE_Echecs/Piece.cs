using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu_TFE_Echecs
{
    abstract class Piece
    {
        protected int[] _position;
        protected string _color;
        protected string _typePiece;
        protected sbyte _id;
        private List<string> _moves = new List<string>();

        public Piece(int[] position, string color, string typePiece, sbyte id)
        {
            this._position = position;
            this._color = color;
            this._typePiece = typePiece;
            this._id = id;
        }

        public abstract bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate);

        public virtual bool IsChecked(Piece[,] memPlate)
        {
            return true;
        }
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
