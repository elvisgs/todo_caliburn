using Caliburn.Micro;

namespace Caliburn.Todos
{
    public class Task : PropertyChangedBase
    {
        string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                NotifyOfPropertyChange(() => Content);
            }
        }

        bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                NotifyOfPropertyChange(() => Done);
            }
        }
    }
}
