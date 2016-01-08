using System;

namespace PC
{
    public class Unit 
    { 
       public string Value;
       public int Degree;
       public double ConvertValue;

       public Unit(){}

       public Unit(string value,int degree)
       {
           Value = value;
           Degree = degree;
       }
       public override string ToString()
       {
           return "("+Value+")" + "^" + Degree;
       }
       public override bool Equals(object obj)
       {
           if (obj == null) throw new ArgumentNullException(nameof(obj));
           if (GetType() != obj.GetType())return false;
           var p = (Unit)obj;
           return (Value == p.Value) && (Degree == p.Degree);
       }
       public override int GetHashCode()
       {
           return 12;
       }
    }
}
