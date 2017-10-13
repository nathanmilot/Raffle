using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    public partial class View : Form, IView {

        public event Action<string> ChooseFileEvent;
        public event Action<string, bool> OpenFileEvent;
        public event Action<bool> EnableButtonsEvent;
        public event Action<bool> GetNextWinnerEvent;
        public event Action<bool> UpdateRemainingContestantsEvent;

        public string CurrentFile { get; set; }

        public string CurrentWinner {
            get {
                return raffle_winner_lbl.Text;
            }
            set { }
        }

        public bool RemoveContestant {
            get {
                return remove_user_option.Checked;
            }
            set { }
        }

        public View() {
            InitializeComponent();
            Height = show_remaining_option.Checked ? 330 : 160;
            contestants_list.Columns[0].Width = contestants_list.Width - 4;
            contestants_list.Columns[1].Width = 0;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            EnableNewWinnerButton(false);
            contestants_list.Columns[0].TextAlign = HorizontalAlignment.Center;
        }

        public void OpenFile(string name) {
            OpenFileEvent?.Invoke(name, show_count_option.Checked);
        }

        public void AnimateWinner() {
            Task.Factory.StartNew(() => {
                int milliseconds = 50;
                for (int i = 0; i < 25; i++) {
                    Invoke((MethodInvoker)delegate {
                        GetNextWinner(i == 24);
                    });
                    Thread.Sleep(milliseconds += 5);
                }
                Invoke((MethodInvoker)delegate {
                    EnableButtonsEvent?.Invoke(true);
                    UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
                });
            });
        }

        public void SetNextWinner(string winner) {
            raffle_winner_lbl.Text = winner;
        }

        public void EnableButtons(bool enable) {
            openRaffleToolStripMenuItem.Enabled = enable;
            select_winner_btn.Enabled = enable;
            show_remaining_option.Enabled = enable;
            remove_user_option.Enabled = enable;
            show_count_option.Enabled = enable;
        }

        public void EnableNewWinnerButton(bool enable) {
            select_winner_btn.Enabled = enable;
        }

        public void UpdateRemainingContestantsList(SortedSet<string> contestants) {
            contestants_list.Items.Clear();
            contestants_list.Columns[1].Width = 0;
            foreach (string name in contestants) {
                contestants_list.Items.Add(name);
            }
            if (contestants_list.Items.Count > 7) {
                contestants_list.Columns[0].Width = contestants_list.Width - 4 - SystemInformation.VerticalScrollBarWidth;
            } else {
                contestants_list.Columns[0].Width = contestants_list.Width - 4;
            }
        }

        public void UpdateRemainingContestantsList(SortedDictionary<string, int> contestants) {
            contestants_list.Items.Clear();
            foreach (string name in contestants.Keys) {
                contestants_list.Items.Add(new ListViewItem(new string[] { name, contestants[name].ToString() }));
            }
            if (contestants_list.Items.Count > 7) {
                contestants_list.Columns[0].Width = contestants_list.Width / 2 - 2 - SystemInformation.VerticalScrollBarWidth / 2;
                contestants_list.Columns[1].Width = contestants_list.Width / 2 - 2 - SystemInformation.VerticalScrollBarWidth / 2;
            } else {
                contestants_list.Columns[0].Width = contestants_list.Width / 2 - 2;
                contestants_list.Columns[1].Width = contestants_list.Width / 2 - 2;
            }
        }

        public void UpdateAndAnimate() {
            Task.Factory.StartNew(() => {
                this.Invoke((MethodInvoker)delegate {
                    UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
                    AnimateWinner();
                });
            });
        }

        private void OpenRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            ChooseFileEvent?.Invoke(null);
        }

        private void Select_winner_btn_Click(object sender, EventArgs e) {
            AnimateWinner();
        }

        private void GetNextWinner(bool possibleRemove) {
            if (GetNextWinnerEvent != null) {
                EnableButtonsEvent?.Invoke(false);
                GetNextWinnerEvent(possibleRemove);
            }
        }

        private void Remove_user_option_Click(object sender, EventArgs e) {
            remove_user_option.Checked = !remove_user_option.Checked;
        }

        private void ShowRemainingContestantsToolStripMenuItem_Click(object sender, EventArgs e) {
            show_remaining_option.Checked = !show_remaining_option.Checked;
            if (show_remaining_option.Checked) {
                Height += 170;
                UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
                contestants_list.Visible = true;
            } else {
                Height -= 170;
                contestants_list.Visible = false;
            }
        }

        private void ShowContestantsCountToolStripMenuItem_Click(object sender, EventArgs e) {
            show_count_option.Checked = !show_count_option.Checked;
            UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
        }

    }

}
