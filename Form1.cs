using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textbox_Schaltjahr_Prüfer
{
    public partial class Form1 : Form
    {
        private Color farbeFalsch = Color.Red;
        private Color farbeRichtig = Color.Green;

        private string bestätigung = "Das Datum liegt in einem Schaltjahr!";
        private string widerlegung = "Das Datum liegt nicht in einem Schaltjahr!";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FehlerAnzeigen()
        {
            label1.Text = "Die Eingabe ist falsch!\nDie Eingabe muss Einen der gültigen Formate für Daten besitzen.";
            label1.ForeColor = farbeFalsch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eingabe = textBox1.Text.Trim();

            int maxMonate = 12;
            int[] maxTage = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            bool istSchaltjahr;

            List<int> datum = new List<int>(); 
            
            try
            {
                string[] datumKomponente = eingabe.Split('.');

                foreach (string komponent in datumKomponente)
                {
                    datum.Add(Convert.ToInt32(komponent));
                }
            }
            catch
            {
                FehlerAnzeigen();
                return;
            }

            if ((datum[2] % 4 == 0 && datum[2] % 100 != 0) || datum[2] % 400 == 0)
            {
                istSchaltjahr = true;
            }
            else
            {
                istSchaltjahr = false;
            }

            int monat = datum[1];

            if (datum[1] >= maxMonate && datum[0] > maxTage[monat - 1])
            {
                label1.Text = istSchaltjahr ? bestätigung : widerlegung;
                label1.ForeColor = istSchaltjahr ? farbeRichtig : farbeFalsch;
            }
            else if (datum[1] == 1 && datum[0] == 29 && istSchaltjahr)
            {
                label1.Text = bestätigung;
                label2.ForeColor = farbeRichtig;
            }
            else
            {
                FehlerAnzeigen();
            }
        }
    }
}
