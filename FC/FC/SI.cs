using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC
{
    public class SI
    {
        public Unit main;
        public List<Unit> dochernie;
        public SI()
        {
            dochernie = new List<Unit>();
            main =  new Unit();
        }
    }
}
