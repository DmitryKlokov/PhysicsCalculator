using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC
{
    public class Unit 
    { 
       public string value;
       public int degree;
       public Unit(){}
       public Unit(string value,int degree)
       {
           this.value = value;
           this.degree = degree; 
       }
       public override string ToString()
       {
           return value + "^" + degree.ToString();
       }
       public override bool Equals(Object obj)
       {
           // Check for null values and compare run-time types.
           if (obj == null || GetType() != obj.GetType())
               return false;

           Unit p = (Unit)obj;
           return (value == p.value) && (degree == p.degree);
       }
       public override int GetHashCode()
       {
           return 12;
       }
    }
}
