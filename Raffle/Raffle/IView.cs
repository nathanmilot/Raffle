using System;
using System.Collections.Generic;

namespace Raffle {
    public interface IView {

        string CurrentFile { get; set; }

        string CurrentWinner { get; set; }

        bool RemoveContestant { get; set; }

        event Action<string> ChooseFileEvent;

        event Action<string> RemoveContestantEvent;

        event Action<string, bool> OpenFileEvent;

        event Action<bool> EnableButtonsEvent;

        event Action<bool> GetNextWinnerEvent;

        event Action<bool> UpdateRemainingContestantsEvent;

        void OpenFile(string name);

        void AnimateWinner();

        void SetNextWinner(string winner);

        void EnableButtons(bool enable);

        void EnableNewWinnerButton(bool enable);

        void UpdateRemainingContestantsList(SortedSet<string> contestants);

        void UpdateRemainingContestantsList(SortedDictionary<string, int> contestants);

        void UpdateAndAnimate();

    }
}
