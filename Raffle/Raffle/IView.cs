using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Raffle {
    public interface IView {

        string CurrentFile { get; set; }

        string CurrentWinner { get; set; }

        bool RemoveContestant { get; set; }

        event Action<string> ChooseFileEvent;

        event Action<string> OpenFileEvent;

        event Action<bool> EnableButtonsEvent;

        event Action<bool> GetNextWinnerEvent;

        event Action UpdateRemainingContestantsEvent;

        void OpenFile(string name);

        void AnimateWinner();

        void SetNextWinner(string winner);

        void EnableButtons(bool enable);

        void EnableNewWinnerButton(bool enable);

        void UpdateRemainingContestantsList(SortedSet<string> contestants);
    }
}
