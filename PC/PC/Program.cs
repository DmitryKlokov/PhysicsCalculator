using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace PC
{
    class Program
    {
        public static List<Operations> LOp = new List<Operations>();
        public static List<SI> LSi = new List<SI>();


        public static void Serialize<T>(String path, List<T> list)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(fs, list);
            fs.Close();
        }

        public static List<T> Deserialize<T>(String path)
        {
            List<T> list = new List<T>();
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            list = (List<T>)serializer.Deserialize(fs);
            fs.Close();
            return list;
        }

        static void Main(string[] args)
        {

            LOp = Deserialize<Operations>("formula.xml");
            LSi = Deserialize<SI>("si.xml");
            //Serialize<SI>("si.xml", LSi);
            //Serialize<Operations>("formula.xml", LOp);




            var v1 = new Value(22, new List<Unit>() { new Unit("Metr", 1) });                                        //Metr
            var v2 = new Value(12, new List<Unit>() { new Unit("Sek", 1) });                                    //Sek       //Metr/Sek
            var v3 = new Value(32, new List<Unit>() { new Unit("Metr/Sek", 1) });
            var v4 = new Value(32, new List<Unit>() { new Unit("Kgram", 1) });
            
            var v5 = v2 * v3;
            if (v5.unit.Count > 1)
            {
                throw new InvalidOperationException("Nevernoe virazenie (sami konec)");
            }
            Console.WriteLine(v5.ToString());
        }
    }
}
