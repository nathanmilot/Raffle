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
            window.UpdateRemainingContestantsEvent += HandleUpdateRemainingContestants;
        }

        private void HandleUpdateRemainingContestants() {
            window.UpdateRemainingContestantsList(model.GetRemainingNames());
        }

        public Controller(System.Windows.Forms.View window1) {
            this.window1 = window1;
        }

        private void HandleEnableButtons(bool enable) {
            window.EnableButtons(enable);
            if (model.GetRemainingNames().Count == 1 && window.CurrentWinner.Equals(model.GetRemainingNames().Min))
                window.EnableNewWinnerButton(false);
        }

        private void HandleGetNextWinner(bool possibleRemove) {
            if (possibleRemove)
                window.SetNextWinner(model.GetNextWinner(window.RemoveContestant));
            else
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
                window.EnableNewWinnerButton(true);
            } else if (from != null) {
                throw new Exception("User canceled the selection");
            }
            fileDialog.Dispose();
        }

        public void HandleOpenFile(string filename) {
            try {
                model = new Raffle(filename.Replace("\\", "/"));
                window.UpdateRemainingContestantsList(model.GetRemainingNames());
                window.AnimateWinner();

            } catch (Exception) {
                MessageBox.Show("There was an error loading the file");
            }
        }

    }
}
