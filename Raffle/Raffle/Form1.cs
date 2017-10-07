using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    public partial class Form1 : Form {

        private List<string> names;
        private int counter;
        private bool running = false;

        public Form1() {
            InitializeComponent();
        }

        private void openRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!running) {
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
                AnimateWinner();
            }

        }

        private void select_winner_btn_Click(object sender, EventArgs e) {
            AnimateWinner();
        }

        public void AnimateWinner() {
            if (!running) {
                running = true;
                Task.Factory.StartNew(() => {
                    int milliseconds = 50;
                    for (int i = 0; i < 50; i++) {
                        this.Invoke((MethodInvoker)delegate {
                            raffle_winner_lbl.Text = "Winner: " + GetNextWinner();
                        });
                        Thread.Sleep(milliseconds += 5);
                    }
                    running = false;
                });
            }
        }

        private string GetNextWinner() {
            if (!ReferenceEquals(names, null) && names.Count > 0)
                return names[counter++ % names.Count];
            return "select a raffle file first";
        }
    }

}
