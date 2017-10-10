using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    public partial class View : Form, IView {


        public event Action<string> ChooseFileEvent;
        public event Action<string> OpenFileEvent;
        public event Action<bool> EnableButtonsEvent;
        public event Action<bool> GetNextWinnerEvent;
        public event Action UpdateRemainingContestantsEvent;


        public string CurrentFile { get; set; }

        public string CurrentWinner {
            get {
                return this.raffle_winner_lbl.Text;
            }
            set { }
        }

        public bool RemoveContestant {
            get {
                return this.remove_user_option.Checked;
            }
            set { }
        }

        public View() {
            InitializeComponent();
            this.Height = 160;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.EnableNewWinnerButton(false);
        }

        private void OpenRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            ChooseFileEvent?.Invoke(null);
        }

        private void Select_winner_btn_Click(object sender, EventArgs e) {
            AnimateWinner();
        }

        public void OpenFile(string name) {
            OpenFileEvent?.Invoke(name);
        }

        public void AnimateWinner() {
            Task.Factory.StartNew(() => {
                int milliseconds = 50;
                for (int i = 0; i < 25; i++) {
                    this.Invoke((MethodInvoker)delegate {
                        GetNextWinner(i == 24);
                    });
                    Thread.Sleep(milliseconds += 5);
                }
                this.Invoke((MethodInvoker)delegate {
                    EnableButtonsEvent?.Invoke(true);
                    UpdateRemainingContestantsEvent?.Invoke();
                });
            });
        }

        private void GetNextWinner(bool possibleRemove) {
            if (GetNextWinnerEvent != null) {
                EnableButtonsEvent?.Invoke(false);
                GetNextWinnerEvent(possibleRemove);
            }
        }

        public void SetNextWinner(string winner) {
            raffle_winner_lbl.Text = winner;
        }

        public void EnableButtons(bool enable) {
            openRaffleToolStripMenuItem.Enabled = enable;
            select_winner_btn.Enabled = enable;
            show_remaining_option.Enabled = enable;
            remove_user_option.Enabled = enable;
        }

        public void EnableNewWinnerButton(bool enable) {
            select_winner_btn.Enabled = enable;
        }

        private void remove_user_option_Click(object sender, EventArgs e) {
            this.remove_user_option.Checked = !this.remove_user_option.Checked;
        }

        private void showRemainingContestantsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.show_remaining_option.Checked = !this.show_remaining_option.Checked;
            if (this.show_remaining_option.Checked) {
                this.Height += 170;
                UpdateRemainingContestantsEvent?.Invoke();
                this.contestants_list.Visible = true;
            } else {
                this.Height -= 170;
                this.contestants_list.Visible = false;
            }
        }

        public void UpdateRemainingContestantsList(SortedSet<string> contestants) {
            this.contestants_list.Items.Clear();
            foreach (string name in contestants) {
                this.contestants_list.Items.Add(name);
            }
        }

    }

}
