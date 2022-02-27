using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro {
    enum Genre { H,F, ND };
    class Personne {
        public Personne(string prenom,string nom, Genre genre) {
            Prenom = prenom;
            Nom = nom;
            Genre = genre;
        }

        private string _nom;
        public string Nom {
            get => _nom; 
            set => _nom = value.ToUpper();
            
        }
        private string _prenom;
        public string Prenom {
            get => _prenom;
            set =>_prenom = value.ToLower();
            
        }

        public string  NomPrenom => $"{_nom} {_prenom}";
        private Genre _genre;
        public Genre Genre {
            get=> _genre; 
            set => _genre = value;
            
        }

        public override string ToString() {
            return _prenom + "\t" + _nom + "\t" + Genre;
        }


    }
}
