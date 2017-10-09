using System;
using System.Windows.Forms;

namespace Raffle {
    public interface IView {

        string CurrentFile { get; set; }

        event Action<string> ChooseFileEvent;

        event Action<string> OpenFileEvent;

        event Action<bool> EnableButtonsEvent;

        event Action GetNextWinnerEvent;


        void OpenFile(string name);

        void AnimateWinner();

        void SetNextWinner(string winner);

        void EnableButtons(bool enable);
    }
}
