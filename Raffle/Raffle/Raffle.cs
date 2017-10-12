using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Raffle {
    class Raffle {

        private List<string> names;
        private int counter;

        public Raffle(string fileName) {
            if (fileName == null) {
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
                        string name = line.Split(',', '\t')[0];
                        if (line.Split(',', '\t').Length == 2) {
                            if (double.TryParse(line.Split(',', '\t')[1], out double count)) {
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
            return GetNextWinner(false);
        }

        public string GetNextWinner(bool remove) {
            if (!ReferenceEquals(names, null) && GetRemainingNames().Count > 1) {
                if (!remove) {
                    return names[counter++ % names.Count];
                } else {
                    string result = names[counter++ % names.Count];
                    names.RemoveAll(new Predicate<string>(result.Equals));
                    return result;
                }
            }
            if (ReferenceEquals(names, null))
                return "Select a raffle file first";
            return GetRemainingNames().Min;
        }

        public SortedSet<string> GetRemainingNames() {
            if (names != null)
                return new SortedSet<string>(names);
            else
                return new SortedSet<string>();
        }

        public SortedDictionary<string, int> GetRemainingNamesWithCount() {
            if (names != null) {
                SortedDictionary<string, int> result = new SortedDictionary<string, int>();
                foreach (string s in names) {
                    if (result.ContainsKey(s)) {
                        result[s]++;
                    } else {
                        result.Add(s, 1);
                    }
                }
                return result;
            }
            return new SortedDictionary<string, int>();
        }
    }
}
