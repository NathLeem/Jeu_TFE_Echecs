using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public abstract class Piece //Classe mère et principale de toutes les pièces confondues du jeu qui leur donne toutes leurs propriétés communes
    {
        protected int[] _position;      //Enregistre la position de la pièce
        protected string _color;        //Détermine sa couleur

        public Piece(int[] position, string color)  //Constructeur des pièces
        {
            this._position = position;
            this._color = color;
        }

        public abstract bool Moving(int[] nColonne, int[] nLigne, Piece[,] memPlate);   //Fonction qui détermine à chaque pièce sa manière de se déplacer

        public virtual bool IsChecked(Piece[,] memPlate)    //Fonction propre au roi pour voir si il est en échecs, mais est appelé depuis ici par simplification
        {
            return true;    //Code brouillon, facultatif
        }

        public string Color //Renvoie la couleur
        {
            get { return _color; }
        }
    }
}
