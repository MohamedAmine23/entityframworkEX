using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro {
    class ListePers : IEnumerable<Personne> {
        private List<Personne> _liste = new();

        public ListePers() {
            Personne p1 = new Personne("paul", "dupond", Genre.H);
            Personne p2 = new Personne("isabelle", "durand", Genre.F);
            Personne p3 = new Personne("Claude", "van Laer", Genre.ND);
            _liste.AddRange(new Personne[] { p1, p2, p3 });

        }
        public int NbElem => _liste.Count;
        public void  AddElem(Personne p) =>  _liste.Add(p);
        
        public bool RemoveElem(Personne p) => _liste.Remove(p);  

        public Personne this[int n] =>_liste[n];

        public void SortBy(Comparison<Personne> comp) => _liste.Sort(comp);
      
        public IEnumerator<Personne> GetEnumerator() =>_liste.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => _liste.GetEnumerator();
        
    }
}
