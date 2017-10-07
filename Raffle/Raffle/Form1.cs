using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Raffle {
    public partial class Form1 : Form {

        private List<string> names;
        private int counter;

        public Form1() {
            InitializeComponent();
        }

        private void openRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            Random rndm = new Random();
            StreamReader myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                names = new List<string>();
                counter = 0;
                try {
                    if ((myStream = new StreamReader(openFileDialog1.FileName)) != null) {
                        while (!myStream.EndOfStream) {
                            string line = myStream.ReadLine();
                            string name = line.Split(',')[0];
                            if (double.TryParse(line.Split(',')[1], out double count)) {
                                for (int i = 0; i < count; i++) {
                                    names.Insert(rndm.Next(0, names.Count), name);
                                }

                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            } else {
                return;
            }
            select_winner_btn_Click(sender, e);
        }

        private void select_winner_btn_Click(object sender, EventArgs e) {
            raffle_winner_lbl.Text = "Winner: " + GetNextWinner();
        }

        private string GetNextWinner() {
            if (!ReferenceEquals(names, null) && names.Count > 0)
                return names[counter++ % names.Count];
            return "select a raffle file first";
        }
    }

}
