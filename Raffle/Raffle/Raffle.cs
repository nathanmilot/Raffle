using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    class Raffle {

        private List<string> names;
        private int counter;
        private bool running = false;

        public Raffle(string fileName) {
            Random rndm = new Random();
            StreamReader myStream = null;

            names = new List<string>();
            counter = 0;
            try {
                if ((myStream = new StreamReader(fileName)) != null) {
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
        }

        public string GetNextWinner() {
            if (!ReferenceEquals(names, null) && names.Count > 0)
                return names[counter++ % names.Count];
            return "select a raffle file first";
        }

    }
}
