using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            LoadFootballers();
            //setareListaCautare();

        }

        /*public void setareListaCautare()
        {
            listaCautare.Items.Add("Nume");
            listaCautare.Items.Add("Prenume");
            listaCautare.Items.Add("Varsta");
            listaCautare.Items.Add("Echipa");
            listaCautare.Items.Add("Meciuri");
            listaCautare.Items.Add("Goluri");


            listaCautare.Text = "Nume";
        }*/

        private void LoadFootballers()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");

            foreach (XmlNode node in doc.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist"))
            {

                string nume = node.SelectSingleNode("nume").InnerText;
                string prenume = node.SelectSingleNode("prenume").InnerText;
                int age = int.Parse(node["age"].InnerText);
                string team = node.SelectSingleNode("team").InnerText;
                int games = int.Parse(node["games"].InnerText);
                int goals = Int32.Parse(node["goals"].InnerText);
                listBox.Items.Add(new fotbalist(nume, prenume, age, team, games, goals));


            }
        }

        private void listaReguli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaCautare.SelectedItem.ToString() == "Cauta Fotbalist A.")
            {
                comboBox1.Enabled = true;
                textBox2.Enabled = false;
                button5.Enabled = true;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Nume");
                comboBox1.Items.Add("Prenume");
                comboBox1.Items.Add("Varsta");
                comboBox1.Items.Add("Echipa");
                comboBox1.Items.Add("Meciuri");
                comboBox1.Items.Add("Goluri");


                comboBox1.Text = "Nume";

            }
        }



        private void listBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                propertyGrid.SelectedObject = listBox.SelectedItem;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string fileName = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XDocument doc = XDocument.Load(fileName);

            if (txtNume.Text == "" || txtPrenume.Text == "" ||
                    txtVarsta.Text == "" || txtEchipa.Text == "" ||
                    txtMeciuri.Text == "" || txtGoluri.Text == ""
                    )
            {
                MessageBox.Show("Completati toate campurile!");

            }
            try
            {
                int nr = Int32.Parse(txtVarsta.Text);
                if (nr <= 0)
                {
                    MessageBox.Show("Introduceti un nr pozitiv pentru varsta.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Introduceti un nr pentru varsta");

            }

            try
            {
                int nr = Int32.Parse(txtMeciuri.Text);
                if (nr <= 0)
                {
                    MessageBox.Show("Introduceti un nr pozitiv pentru meciuri.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Introduceti un nr pentru meciuri");

            }


            try
            {
                int nr = Int32.Parse(txtGoluri.Text);
                if (nr <= 0)
                {
                    MessageBox.Show("Introduceti un nr pozitiv pentru goluri.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Introduceti un nr pentru goluri");

            }
            try
            {
                XElement root = new XElement("fotbalist");

                root.Add(new XAttribute("id", "fotbalist" + getNrFotbalisti()));
                root.Add(new XElement("nume", txtNume.Text));
                root.Add(new XElement("prenume", txtPrenume.Text));
                root.Add(new XElement("age", txtVarsta.Text));
                root.Add(new XElement("team", txtEchipa.Text));
                root.Add(new XElement("games", txtMeciuri.Text));
                root.Add(new XElement("goals", txtGoluri.Text));

                doc.Element("root").Element("fotbalisti").Add(root);
                doc.Save(fileName);
                MessageBox.Show("Fotbalist adaugat");
                listBox.Items.Clear();
                LoadFootballers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");
            foreach (XmlNode xnode in xdoc.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist"))
                if (xnode.SelectSingleNode("nume").InnerText == textBox1.Text) xnode.ParentNode.RemoveChild(xnode);
            xdoc.Save(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");
            MessageBox.Show("Fotbalist eliminat");
            listBox.Items.Clear();
            LoadFootballers();




        }

        public int getNrFotbalisti()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");
            XmlNodeList nodes = document.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist");
            return nodes.Count + 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/root/reguli/regula");
            List<string> tipReguli = new List<string>();
            foreach (XmlNode nod in nodes)
            {
                tipReguli.Add(nod.SelectSingleNode("tip").InnerText);
            }
            listaCautare.Items.Clear();
            foreach (string regula in tipReguli)
            {
                listaCautare.Items.Add(regula);
            }
        }

        public string cautaFotbalistA(string Fotbalist, XmlNode nod)
        {
            string filename = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNodeList nodes = document.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist");
            bool exista = false;
            foreach (XmlNode fot in nodes)
            {
                if (fot.SelectSingleNode("nume").InnerText == Fotbalist)
                {

                    exista = true;

                }
            }
            if (exista == true)
            {
                return nod.SelectSingleNode("then").InnerText.Replace("%1", Fotbalist);
            }
            else
            {
                return nod.SelectSingleNode("else").InnerText;
            }
        }
        public void getFotbalistiCuAMeciuri(int nrMeciuri, XmlNode nod)
        {
            string filename = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNodeList nodes = document.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist");
            List<fotbalist> jocuri = new List<fotbalist>();
            richTextBox1.Clear();
            foreach (XmlNode nodA in nodes)
            {
                if (Int32.Parse(nodA.SelectSingleNode("games").InnerText) >= nrMeciuri)
                {

                    richTextBox1.AppendText(nodA.SelectSingleNode("prenume").InnerText + " " + nodA.SelectSingleNode("nume").InnerText + "\r\n");
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listaCautare.SelectedItem != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml");

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/root/reguli/regula");

                bool entered = false;

                foreach (XmlNode nod in nodes)
                {
                    if (nod.SelectSingleNode("tip").InnerText == listaCautare.SelectedItem.ToString())
                    {
                        entered = true;
                        //regula 1
                        if (listaCautare.SelectedItem.ToString() == "Cauta fotbalist A.")
                        {
                            string Fotbalist = textBox2.Text;
                            string query = cautaFotbalistA(Fotbalist, nod);
                            richTextBox1.AppendText(query + "\r\n");
                        }


                        //regula 2
                        else if (listaCautare.SelectedItem.ToString() == "Fotbalisti cu cel putin A meciuri.")
                        {

                            try
                            {
                                int NrMeciuri = 0;
                                try
                                {
                                    NrMeciuri = Int32.Parse(textBox5.Text);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Introduceti un numar");
                                }
                                if (NrMeciuri <= 0)
                                {
                                    MessageBox.Show("Introduceti un numar >0.");

                                }
                                richTextBox1.Clear();
                                getFotbalistiCuAMeciuri(NrMeciuri, nod);

                            }
                            catch (Exception ex)
                            {

                            }

                        }
                        //regula 3
                        else if (listaCautare.SelectedItem.ToString() == "Cauta fotbalist A si fotbalist B.")
                        {
                            string fotbalistA = textBox7.Text;
                            string fotbalistB = textBox6.Text;
                            string mesaj = cautaFotbalistAsiEchipaB(fotbalistA, fotbalistB, nod);
                            richTextBox1.Clear();
                            richTextBox1.AppendText(mesaj + "\r\n");
                        }

                        // regula 4
                        else if (listaCautare.SelectedItem.ToString() == "Cauta fotbalisti care au intre A si B goluri.")
                        {
                            int golMin = Int32.Parse(textBox3.Text);
                            int golMax = Int32.Parse(textBox4.Text);
                            string query = cautaFotbalistiGoluriAB(golMin, golMax, nod);
                            richTextBox1.Clear();
                            richTextBox1.AppendText(query + "\r\n");
                        }
                    }
                }
                if (!entered)
                {
                    MessageBox.Show("Alegeti o regula!");
                }
            }
        }

        public string cautaFotbalistiGoluriAB(int min, int max, XmlNode nod)
        {
            string filename = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNodeList nodes = document.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist");

            string listaFotbalisti = "";
            int entered = 0;

            foreach (XmlNode fot in nodes)
            {
                int nrGoluri = Int32.Parse(fot.SelectSingleNode("goals").InnerText);
                string nume = fot.SelectSingleNode("prenume").InnerText +" "+ fot.SelectSingleNode("nume").InnerText;
                if (nrGoluri >= min && nrGoluri <= max)
                {
                    listaFotbalisti += nume + "\r\n";
                }
            }

            if (listaFotbalisti != "")
            {
                return nod.SelectSingleNode("then").InnerText.Replace("%1", listaFotbalisti);
            } else
            {
                return nod.SelectSingleNode("else").InnerText;
            }
        }

        public string cautaFotbalistAsiEchipaB(string Fotbalist1, string Fotbalist2, XmlNode nod)
        {

            string filename = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNodeList nodes = document.DocumentElement.SelectNodes("/root/fotbalisti/fotbalist");

            bool existaFotbalist1 = false;
            bool existaFotbalist2 = false;
            string echipaFotbalist1 = "";
            string echipaFotbalist2 = "";
            foreach (XmlNode fot in nodes)
            {
                if (fot.SelectSingleNode("nume").InnerText.ToString() == Fotbalist1)
                {
                    existaFotbalist1 = true;
                    echipaFotbalist1 = fot.SelectSingleNode("team").InnerText;


                }
                if (fot.SelectSingleNode("nume").InnerText.ToString() == Fotbalist2)
                {
                    existaFotbalist2 = true;
                    echipaFotbalist2 = fot.SelectSingleNode("team").InnerText;


                }
            }
            if (existaFotbalist1 && existaFotbalist2)
            {

                return nod.SelectSingleNode("then").InnerText.Replace("%1",Fotbalist1).Replace("%2", echipaFotbalist1).Replace("%3", Fotbalist2).Replace("%4", echipaFotbalist2);

            }
            else
            {
                return nod.SelectSingleNode("else").InnerText;
            }
        }
        private void listaCautare_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Users\Alexander\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\fotbalist.xml";
            XmlDocument document = new XmlDocument();
            document.Load(filename);

            richTextBox2.Text = System.Xml.Linq.XDocument.Parse(document.InnerXml).ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Echipa_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }


}
