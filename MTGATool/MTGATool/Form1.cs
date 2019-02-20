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
using System.Runtime.Serialization;
using Newtonsoft.Json;

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
            Data data = new Data();
            int size = -1;
            int index = 0;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string json = "";
                    var x = 0;
                    foreach (var line in File.ReadAllLines(file))
                    {
                        if (line.Contains(@"<== Event.GetCombinedRankInfo(11)"))
                        {
                            x = index + 22;
                        }
                        else if (x > 0 & index < x)
                        {
                            json += line;
                        }
                        else if (x > 0 & index == x)
                        {
                            data = JsonConvert.DeserializeObject<Data>(json);
                            break;
                        }
                        index++;
                    }
                    
                    label2.Text = data.constructedMatchesWon.ToString();
                    label3.Text = data.constructedMatchesLost.ToString();
                    label7.Text = data.limitedMatchesWon.ToString();
                    label6.Text = data.limitedMatchesLost.ToString();

                    double contructedPercentage = Math.Round(Convert.ToDouble(data.constructedMatchesWon) / (Convert.ToDouble(data.constructedMatchesLost) + Convert.ToDouble(data.constructedMatchesWon))*10000)/100;
                    label4.Text = contructedPercentage.ToString();
                    double limitedPercentage = Math.Round(Convert.ToDouble(data.limitedMatchesWon) / (Convert.ToDouble(data.limitedMatchesWon) + Convert.ToDouble(data.limitedMatchesLost))*10000)/100;
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
