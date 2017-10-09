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
        public event Action GetNextWinnerEvent;


        public string CurrentFile { get; set; }

        public View() {
            InitializeComponent();
        }

        private void openRaffleToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ChooseFileEvent != null) {
                ChooseFileEvent(null);
            }
        }

        private void select_winner_btn_Click(object sender, EventArgs e) {
            AnimateWinner();
        }

        public void OpenFile(string name) {
            if (OpenFileEvent != null) {
                OpenFileEvent(name);
            }
        }

        public void AnimateWinner() {
            Task.Factory.StartNew(() => {
                int milliseconds = 50;
                for (int i = 0; i < 50; i++) {
                    this.Invoke((MethodInvoker)delegate {
                        GetNextWinner();
                    });
                    Thread.Sleep(milliseconds += 5);
                }
                if (EnableButtonsEvent != null) {
                    //EnableButtonsEvent(true);
                }
            });
        }

        private void GetNextWinner() {
            if (GetNextWinnerEvent != null) {
                if (EnableButtonsEvent != null) {
                    //EnableButtonsEvent(false); 
                }
                GetNextWinnerEvent();
            }
        }

        public void SetNextWinner(string winner) {
            raffle_winner_lbl.Text = "Winner: " + winner;
        }

        public void EnableButtons(bool enable) {
            openRaffleToolStripMenuItem.Enabled = enable;
            select_winner_btn.Enabled = enable;
        }
    }

}
