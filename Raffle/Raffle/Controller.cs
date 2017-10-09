using System;
using System.Windows.Forms;

namespace Raffle {
    class Controller {

        private IView window;
        private Raffle model;
        private System.Windows.Forms.View window1;

        public Controller(IView window) {
            this.window = window;
            this.model = new Raffle(window.CurrentFile);

            window.ChooseFileEvent += HandleChooseFile;
            window.OpenFileEvent += HandleOpenFile;
            window.GetNextWinnerEvent += HandleGetNextWinner;
            window.EnableButtonsEvent += HandleEnableButtons;
        }

        public Controller(System.Windows.Forms.View window1) {
            this.window1 = window1;
        }

        private void HandleEnableButtons(bool enable) {
            window.EnableButtons(enable);
        }

        private void HandleGetNextWinner() {
            window.SetNextWinner(model.GetNextWinner());
        }

        private void HandleChooseFile(string from) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open Raffle File";
            fileDialog.DefaultExt = ".csv;.tsv;.txt;";
            fileDialog.Filter = "Raffle File|*.csv;*.tsv;*.txt; |All files|*.*";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.Yes || result == DialogResult.OK) {
                window.OpenFile(fileDialog.FileName.Replace("\\", "/"));
            } else if (from != null) {
                throw new Exception("User canceled the selection");
            }
            fileDialog.Dispose();
        }

        public void HandleOpenFile(string filename) {
            try {
                model = new Raffle(filename.Replace("\\", "/"));
            } catch (Exception) {
                MessageBox.Show("There was an error loading the file");
            }
            window.AnimateWinner();
        }

    }
}
