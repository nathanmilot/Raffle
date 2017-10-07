using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    class Controller {

        private IView window;
        private Raffle model;
        private View window1;

        public Controller(IView window) {
            this.window = window;
            this.model = new Raffle(window.CurrentFile);

            window.ChooseFileEvent += HandleChooseFile;
            window.OpenFileEvent += HandleOpenFile;
        }

        public Controller(View window1) {
            this.window1 = window1;
        }

        private void HandleChooseFile(string from) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open Raffle File";
            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "Raffle File|*.csv|All files|*.*";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.Yes || result == DialogResult.OK) {
                window.OpenFile(fileDialog.FileName.Replace("\\", "/"));
            } else if (from != null) {
                throw new Exception("User canceled the selection");
            }
            fileDialog.Dispose();
        }

        public void HandleOpenFile(string filename) {
            StreamReader inputFile = null;
            try {
                model = new Raffle(filename.Replace("\\", "/"));
            } catch (Exception) {
                MessageBox.Show("There was an error loading the file");
            }
            inputFile.Close();
            window.AnimateWinner();
        }
    }
}
