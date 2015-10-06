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

        private void Serialize(String path,Type t,string s)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(t);
            switch (s)
            {
                case "si": { serializer.Serialize(fs, LSi); break; }
                case "op" :{ serializer.Serialize(fs, LOp);break; }
            }
            fs.Close();
        }

        private void Deserialize(String path, string s)
        {
            FileStream fs = new FileStream(path, FileMode.Open);            
            switch (s)
            {
                case "si": { XmlSerializer serializer = new XmlSerializer(typeof(List<SI>)); LSi = (List<SI>)serializer.Deserialize(fs); break; }
                case "op": { XmlSerializer serializer = new XmlSerializer(typeof(List<Operations>)); LOp = (List<Operations>)serializer.Deserialize(fs); break; }
            }
            fs.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Deserialize("formula.xml","op");
           Deserialize("si.xml", "si");
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            var v1 = new Value(12, new List<Unit>() { new Unit("Amper", 1) });
            var v2 = new Value(12, new List<Unit>() { new Unit("Om", 1) });
            var v3 = new Value(12, new List<Unit>() { new Unit("Null", 2) });
            var v4 = new Value(12, new List<Unit>() { new Unit("Null", 2) });

            var v5 = v1*v2*v4*v3;
            if (v5.unit.Count > 1) { throw new InvalidOperationException("Nevernoe virazenie (sami konec)"); }
            MessageBox.Show(v5.ToString());
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_mainSI.Text != "")
            {
                SI s = new SI();
                s.main.value= textBox_mainSI.Text;
                s.main.degree = int.Parse(textBoxmainSiDeg.Text);
                LSi.Add(s);
                Serialize("si.xml", typeof(List<SI>),"si");
            }
            panel_SI.Visible = false;
        }

        private void button_addSI_Click(object sender, EventArgs e)
        {
            panel_SI.Visible = true;
        }
    }
}
