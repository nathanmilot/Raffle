using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Raffle {
    class Raffle {

        private List<string> names;
        private int counter;

        public Raffle(string fileName) {
            if(fileName == null) {
                return;
            }
            Random rndm = new Random();
            StreamReader myStream = null;

            names = new List<string>();
            counter = 0;
            try {
                if ((myStream = new StreamReader(fileName)) != null) {
                    while (!myStream.EndOfStream) {
                        string line = myStream.ReadLine();
                        string name = line.Split(',','\t')[0];

                        if (line.Split(',', '\t').Length == 2) {
                            if (double.TryParse(line.Split(',','\t')[1], out double count)) {
                                for (int i = 0; i < count; i++) {
                                    names.Insert(rndm.Next(0, names.Count), name);
                                }
                            } 
                        } else {
                            names.Insert(rndm.Next(0, names.Count), name);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        public string GetNextWinner() {
            if (!ReferenceEquals(names, null) && names.Count > 0)
                return names[counter++ % names.Count];
            return "select a raffle file first";
        }

    }
}
