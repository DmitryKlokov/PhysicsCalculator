using System;
using System.Collections.Generic;
using System.Linq;

namespace PC
{
    public class Value
    {
        private double _value;
        public List<Unit> Unit;

        public static Value operator +(Value vLeft, Value vRight)
        {
            if (CompareTwoList(vLeft.Unit, vRight.Unit))//если единицы измерения совпали все окей +
            {
                return new Value(vLeft._value + vRight._value, vLeft.Unit);
            }
            throw new InvalidOperationException("Nevernoe virazenie(+)");
        }

        private static bool CompareTwoList(ICollection<Unit> a, ICollection<Unit> b)
        {
            if (a.Count != b.Count) return false; //если не равны размеры то сразу false
            var count = a.Count(b.Contains);      //если один содержит все элементы лругого
            return count == a.Count;
        }

        public static Value operator - (Value vLeft, Value vRight)
        {
            if (CompareTwoList(vLeft.Unit, vRight.Unit))//если единицы измерения совпали все окей отнимаем
            {
                return new Value(vLeft._value - vRight._value, vLeft.Unit);
            }
            throw new InvalidOperationException("Nevernoe virazenie(+)");
        }

        public static Value FindFormula(Value v)
        {
            foreach (var t1 in Program.LOp)//идем по всем формулам
            {
                if (t1.Lu.Count != v.Unit.Count) continue;
                //если количество переменных совпало
                var count = v.Unit.Count(t => t1.Lu.Contains(t));//ищем наши переменные в формуле
                if (count != v.Unit.Count) continue;
                //если все окей 
                v.Unit.Clear();
                v.Unit.Add(t1.Result);
                break;
            }
            return v;
        }

        public static int FindSameUnit(Value v, string value)
        {
            for (var i = 0; i < v.Unit.Count; i++)
            {
                if (v.Unit[i].Value == value)
                    return i;
            }
            return -1;
        }

        public static Value CheckValueInTheSi(Value v)
        {
            if (Program.LSi.Any(t => t.Main == v.Unit))//идем по всей таблице си и сравниваем наше значение с главными
            {
                return v;
            }
            foreach (var si in Program.LSi)
            {
                foreach (var child in si.Сhildren.Where(child => child.Value == v.Unit[0].Value))
                {
                    v.Unit = si.Main;
                    v._value = v._value * Math.Pow(child.ConvertValue, v.Unit[0].Degree);
                    return v;
                }
            }
            return v;
        }

        public static Value operator /(Value vLeft, Value vRight)
        {
            vLeft = CheckValueInTheSi( vLeft);//проверяем нашу переменную на си
            vRight = CheckValueInTheSi( vRight);
            vLeft._value = vLeft._value / vRight._value;//выполняем арифм операцию
            foreach (var u in vRight.Unit) //переносим все юниты в левую переменную
            {
                var index = FindSameUnit(vLeft, u.Value); //поиск переменных с одинаковыми юнитами
                if (index == -1)
                {
                    u.Degree *= -1;
                    vLeft.Unit.Add(u);//если не нашли то добавили к левой
                }
                else
                {
                    vLeft.Unit[index].Degree-=u.Degree;//если нашли то умен степень
                    if (vLeft.Unit[index].Degree == 0) vLeft.Unit.RemoveAt(index);
                }
            }
            return FindFormula(vLeft);//ищем формулу в нашем выражении
        }

        public static Value operator *(Value vLeft, Value vRight)
        {
            vLeft = CheckValueInTheSi(vLeft);//проверяем нашу переменную на си
            vRight = CheckValueInTheSi(vRight);
            vLeft._value = vLeft._value * vRight._value;//выполняем арифм операцию
            foreach (var u in vRight.Unit)//переносим все юниты в левую переменную
            {
                var index = FindSameUnit(vLeft, u.Value);//поиск переменных с одинаковыми юнитами
                if ( index == -1)
                {
                    vLeft.Unit.Add(u);//если не нашли то добавили к левой
                }
                else
                {
                    vLeft.Unit[index].Degree += u.Degree;//если нашли то увел степень
                }
            }
            return FindFormula(vLeft);//ищем формулу в нашем выражении
        }

        public Value()
        {
            Unit = new List<Unit>();
        }
        public Value(double value, List<Unit> unit)
        {
            _value = value;
            Unit = unit;
        }
        public override string ToString()
        {
            return _value + " " + Unit[0];
        }
    }
}
