using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml.Serialization;

namespace FC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<Operations> LOp = new List<Operations>();
        public static List<SI> LSi = new List<SI>();


        public void Serialize<T>(String path, List<T> list)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>)); 
            serializer.Serialize(fs, list);
            fs.Close();
        }

        public List<T> Deserialize<T>(String path) 
        {
            List<T> list = new List<T>();
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>)); 
            list = (List<T>)serializer.Deserialize(fs);
            fs.Close();
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LOp = Deserialize<Operations>("formula.xml");
            LSi = Deserialize<SI>("si.xml");
            //Serialize<SI>("si.xml", LSi);
            //Serialize<Operations>("formula.xml", LOp);
        }

        public bool checkedResult(Value v)
        {
            for (int i = 0; i < LSi.Count; i++) //идем по всей таблице си и сравниваем наше значение с главными
            {
                if (LSi[i].main == v.unit)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            var v1 = new Value(12, new List<Unit>() { new Unit("Amper", 1) });
            var v2 = new Value(12, new List<Unit>() { new Unit("Om", 1) });
            var v3 = new Value(12, new List<Unit>() { new Unit("Null", 2) });
            var v4 = new Value(12, new List<Unit>() { new Unit("Null", 2) });
            var v5 = v1 * v2 * v3 * v4;
            if (checkedResult(v5)) 
            { 
                throw new InvalidOperationException("Nevernoe virazenie (sami konec)"); 
            }
            MessageBox.Show(v5.ToString());
        }
    }
}
