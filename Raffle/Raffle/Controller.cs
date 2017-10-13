using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    class Controller {

        private IView window;
        private Raffle model;

        public Controller(IView window) {
            this.window = window;
            model = new Raffle(window.CurrentFile);

            window.ChooseFileEvent += HandleChooseFile;
            window.OpenFileEvent += HandleOpenFile;
            window.GetNextWinnerEvent += HandleGetNextWinner;
            window.EnableButtonsEvent += HandleEnableButtons;
            window.UpdateRemainingContestantsEvent += HandleUpdateRemainingContestants;
        }

        public void HandleOpenFile(string filename, bool showCount) {
            Task.Factory.StartNew(() => {
                try {
                    model = new Raffle(filename.Replace("\\", "/"));
                    window.UpdateAndAnimate();
                } catch (Exception) {
                    MessageBox.Show("There was an error loading the file");
                }
            });
        }

        private void HandleUpdateRemainingContestants(bool showCount) {
            if (showCount)
                window.UpdateRemainingContestantsList(model.GetRemainingNamesWithCount());
            else
                window.UpdateRemainingContestantsList(model.GetRemainingNames());
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

    }
}
