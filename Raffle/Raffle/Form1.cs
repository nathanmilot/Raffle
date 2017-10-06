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

namespace Raffle {
    public partial class Form1 : Form {

        private List<string> names = new List<string>();

        public Form1() {
            InitializeComponent();
        }

        private void openRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            StreamReader myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    if ((myStream = new StreamReader(openFileDialog1.FileName)) != null) {
                        string line = myStream.ReadLine();
                        string name = line.Split(',')[0];
                        if(double.TryParse(line.Split(',')[1], out double count)) {
                            for(int i = 0; i < count; i++) {
                                names.Add(name);
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            //button1.Text = "List Size: " + names.Count;
        }
    }
}
