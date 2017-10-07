using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffle {
    public interface IView {

        string CurrentFile { get; set; }

        event Action<string> ChooseFileEvent;
        event Action<string> OpenFileEvent;
        void OpenFile(string name);

        void AnimateWinner();
    }
}
