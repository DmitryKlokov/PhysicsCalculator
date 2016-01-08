using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace PC
{
    class Program
    {
        public static List<Operations> LOp = new List<Operations>();
        public static List<Si> LSi = new List<Si>();


        public static void Serialize<T>(string path, List<T> list)
        {
            var fs = new FileStream(path, FileMode.Create);
            var serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(fs, list);
            fs.Close();
        }

        public static List<T> Deserialize<T>(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            var serializer = new XmlSerializer(typeof(List<T>));
            var list = (List<T>)serializer.Deserialize(fs);
            fs.Close();
            return list;
        }

        private static void Main()
        {

            LOp = Deserialize<Operations>("formula.xml");
            LSi = Deserialize<Si>("si.xml");
            

            //var v1 = new Value(22, new List<Unit>() { new Unit("Метр", 1) });                                        //Metr
            var v2 = new Value(12, new List<Unit>() { new Unit("Час", 1) });                                    //Sek       //Metr/Sek
            var v3 = new Value(32, new List<Unit>() { new Unit("Метр/Секунда", 1) });
            // var v4 = new Value(32, new List<Unit>() { new Unit("Kgram", 1) });
            
            var v5 = v2 * v3;
            if (v5.Unit.Count > 1)
            {
                throw new InvalidOperationException("Nevernoe virazenie (sami konec)");
            }
            Console.WriteLine(v5.ToString());
        }
    }
}
