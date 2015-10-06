using System;
using System.Collections.Generic;
using System.Linq;

namespace PC
{
    public class Value
    {
        public double value;
        public List<Unit> unit ;

        public static Value operator +(Value vLeft, Value vRight)
        {
            if (compareTwoList(vLeft.unit, vRight.unit))//если единицы измерения совпали все окей +
            {
                return new Value(vLeft.value + vRight.value, vLeft.unit);
            }
            else { throw new InvalidOperationException("Nevernoe virazenie(+)"); }
        }

        private static bool compareTwoList(List<Unit> a, List<Unit> b)
        {
            if (a.Count != b.Count) return false; //если не равны размеры то сразу false
            int count = 0;
            foreach (Unit u in a)
            {
                if (b.Contains(u)) count++; //если один содержит все элементы лругого
            }
            if (count == a.Count) return true;
            else return false;
        }

        public static Value operator - (Value vLeft, Value vRight)
        {
            if (compareTwoList(vLeft.unit, vRight.unit))//если единицы измерения совпали все окей отнимаем
            {
                return new Value(vLeft.value - vRight.value, vLeft.unit);
            }
            else { throw new InvalidOperationException("Nevernoe virazenie(+)"); }
        }

        public static Value FindFormula(Value v)
        {
            for (int i = 0; i < Program.LOp.Count; i++)//идем по всем формулам
            {
                if (Program.LOp[i].lu.Count == v.unit.Count)//если количество переменных совпало
                {
                    int count = 0;
                    for (int j = 0; j < v.unit.Count; j++)//ищем наши переменные в формуле
                    {
                        if (Program.LOp[i].lu.Contains(v.unit[j])) count++;
                    }

                    if (count == v.unit.Count)//если все окей 
                    {
                        v.unit.Clear();
                        v.unit.Add(Program.LOp[i].result);
                        break;
                    }
                }
            }
            return v;
        }
        public static int FindSameUnit(Value v, String value)
        {
            for (int i = 0; i < v.unit.Count; i++)
            {
                if (v.unit[i].value == value)
                    return i;
            }
            return -1;
        }
        public static Value CheckValueInTheSI(Value v)
        {
            for (int i = 0; i < Program.LSi.Count; i++) //идем по всей таблице си и сравниваем наше значение с главными
            {
                if (Program.LSi[i].main == v.unit)
                 {
                     return v;
                 }
             }
            for (int i = 0; i < Program.LSi.Count; i++)//ищем наше значение в дочерних
             {
                 foreach (Unit s in Program.LSi[i].dochernie)
                 {
                     if (s.value == v.unit[0].value)
                     {
                         v.unit = Program.LSi[i].main;//если нашлось то переводим
                         //надо добавить правило перевода!!!
                         return v; 
                     }
                 }
             }
            return v;
        }

        public static Value operator /(Value vLeft, Value vRight)
        {
            vLeft = CheckValueInTheSI( vLeft);//проверяем нашу переменную на си
            vRight = CheckValueInTheSI( vRight);
            vLeft.value = vLeft.value / vRight.value;//выполняем арифм операцию
            foreach (Unit u in vRight.unit) //переносим все юниты в левую переменную
            {
                int index = FindSameUnit(vLeft, u.value); //поиск переменных с одинаковыми юнитами
                if (index == -1)
                {
                    u.degree *= -1;
                    vLeft.unit.Add(u);//если не нашли то добавили к левой
                }
                else
                {
                    vLeft.unit[index].degree-=u.degree;//если нашли то умен степень
                    if (vLeft.unit[index].degree == 0) vLeft.unit.RemoveAt(index);
                }
            }
            return FindFormula(vLeft);//ищем формулу в нашем выражении
        }
        public static Value operator *(Value vLeft, Value vRight)
        {
            vLeft = CheckValueInTheSI(vLeft);//проверяем нашу переменную на си
            vRight = CheckValueInTheSI(vRight);
            vLeft.value = vLeft.value * vRight.value;//выполняем арифм операцию
            foreach (Unit u in vRight.unit)//переносим все юниты в левую переменную
            {
                int index = FindSameUnit(vLeft, u.value);//поиск переменных с одинаковыми юнитами
                if ( index == -1)
                {
                    vLeft.unit.Add(u);//если не нашли то добавили к левой
                }
                else
                {
                    vLeft.unit[index].degree += u.degree;//если нашли то увел степень
                }
            }
            return FindFormula(vLeft);//ищем формулу в нашем выражении
        }

        public Value()
        {
            unit = new List<Unit>();
        }
        public Value(double value, List<Unit> unit)
        {
            this.value = value;
            this.unit = unit;
        }
        public override string ToString()
        {
            return value.ToString() + " " + unit[0].ToString();
        }
    }
}
