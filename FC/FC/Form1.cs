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



        private void button_calculate_Click(object sender, EventArgs e)
        {
            var v1 = new Value(22, new List<Unit>() { new Unit("KMetr", 1) });                                        //Metr
            var v2 = new Value(12, new List<Unit>() { new Unit("Sek", 1) });                                    //Sek             //Metr/Sek
            var v3 = new Value(32, new List<Unit>() { new Unit("Metr/Sek", 1) });
            var v5 = v1 / v2;
            if (v5.unit.Count>1) 
            { 
                throw new InvalidOperationException("Nevernoe virazenie (sami konec)"); 
            }
            MessageBox.Show(v5.ToString());
        }
    }
}
