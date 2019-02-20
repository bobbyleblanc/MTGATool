using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGATool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    int index = text.IndexOf("\"constructedMatchesWon\": ");
                    size = index;
                    label2.Text = text.Substring(index + 25, 2);
                    index = text.IndexOf("\"constructedMatchesLost\": ");
                    label3.Text = text.Substring(index + 26, 2);
                    index = text.IndexOf("\"limitedMatchesWon\": ");
                    label7.Text = text.Substring(index + 21, 2);
                    index = text.IndexOf("\"limitedMatchesLost\": ");
                    label6.Text = text.Substring(index + 22, 2);

                    double contructedPercentage = Math.Round(Convert.ToDouble(label2.Text) / (Convert.ToDouble(label3.Text) + Convert.ToDouble(label2.Text))*10000)/100;
                    label4.Text = contructedPercentage.ToString();
                    double limitedPercentage = Math.Round(Convert.ToDouble(label7.Text) / (Convert.ToDouble(label7.Text) + Convert.ToDouble(label6.Text))*10000)/100;
                    label5.Text = limitedPercentage.ToString();
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
        
    }
}
