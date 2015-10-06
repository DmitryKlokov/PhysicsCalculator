using System;

namespace PC
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
           return "("+value+")" + "^" + degree.ToString();
       }
       public override bool Equals(Object obj)
       {
           if (obj == null || GetType() != obj.GetType())return false;
           Unit p = (Unit)obj;
           return (value == p.value) && (degree == p.degree);
       }
       public override int GetHashCode()
       {
           return 12;
       }
    }
}
