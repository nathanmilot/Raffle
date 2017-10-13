using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raffle {
    public partial class View : Form, IView {

        private int sortColumn = 0;

        private int HeightMax = 390;
        private int HeightMin = 165;

        public event Action<string> ChooseFileEvent;
        public event Action<string> RemoveContestantEvent;
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
            Height = show_remaining_option.Checked ? HeightMax : HeightMin;
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
            if (contestants_list.Items.Count > 10) {
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
            if (contestants_list.Items.Count > 10) {
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
                Height = HeightMax;
                UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
                contestants_list.Visible = true;
            } else {
                Height = HeightMin;
                contestants_list.Visible = false;
            }
        }

        private void ShowContestantsCountToolStripMenuItem_Click(object sender, EventArgs e) {
            show_count_option.Checked = !show_count_option.Checked;
            UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
        }

        private void contestants_list_ColumnClick(object sender, ColumnClickEventArgs e) {

            if (e.Column != sortColumn) {
                sortColumn = e.Column;
                contestants_list.Sorting = SortOrder.Ascending;
            } else {
                if (contestants_list.Sorting == SortOrder.Ascending)
                    contestants_list.Sorting = SortOrder.Descending;
                else
                    contestants_list.Sorting = SortOrder.Ascending;
            }

            contestants_list.Sort();
            contestants_list.ListViewItemSorter = new ListViewItemComparer(e.Column, contestants_list.Sorting);
        }

        private void contestants_list_KeyUp(object sender, KeyEventArgs e) {
            if(select_winner_btn.Enabled && (e.KeyValue == 46 || e.KeyValue == 8)) {
                foreach(ListViewItem item in contestants_list.SelectedItems) {
                    RemoveContestantEvent?.Invoke(item.Text);
                }
                UpdateRemainingContestantsEvent?.Invoke(show_count_option.Checked);
                if(contestants_list.Items.Count == 0) {
                    select_winner_btn.Enabled = false;
                }
            }
        }

        private void Select_winner_btn_KeyUp(object sender, KeyEventArgs e) {
            if(select_winner_btn.Enabled && e.KeyValue == 13) {
                Select_winner_btn_Click(sender, e);
            }
        }
    }

    class ListViewItemComparer : IComparer {
        private int col;
        private SortOrder order;
        public ListViewItemComparer() {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order) {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y) {
            int returnVal = -1;
            int intX;
            int intY;
            if(((ListViewItem)x).SubItems.Count == col) {
                col = 0;
            }
            if (int.TryParse(((ListViewItem)x).SubItems[col].Text, out intX) && int.TryParse(((ListViewItem)y).SubItems[col].Text, out intY)) {
                returnVal = intX - intY;
            } else {
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }

}
