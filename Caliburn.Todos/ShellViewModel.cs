using System.Linq;
using Caliburn.Micro;

namespace Caliburn.Todos
{
    public class ShellViewModel : Screen
    {
        BindableCollection<Task> tasks = new BindableCollection<Task>();
        string current;

        public ShellViewModel()
        {
            DisplayName = "Todos";

            tasks.CollectionChanged += (s, e) => TaskUpdated(new Task());
        }

        public string Current
        {
            get { return current; }
            set
            {
                current = value;
                NotifyOfPropertyChange(() => Current);
                NotifyOfPropertyChange(() => CanAdd);
            }
        }

        public BindableCollection<Task> Tasks
        {
            get { return tasks; }
        }

        public int Remaining
        {
            get { return tasks.Count(x => !x.Done); }
        }

        public string RemainingText
        {
            get
            {
                return string.Format("{0} item{1} left", 
                    Remaining, Remaining > 1 ? "s" : "");
            }
        }

        public bool CanAdd
        {
            get { return !string.IsNullOrWhiteSpace(current); }
        }

        public bool CanClearCompleted
        {
            get { return tasks.Any(x => x.Done); }
        }

        public void Add()
        {
            if (!CanAdd) return;

            tasks.Add(new Task { Content = current });
            Current = string.Empty;
        }

        public void Remove(Task task)
        {
            tasks.Remove(task);
        }

        public void TaskUpdated(Task task)
        {
            NotifyOfPropertyChange(() => RemainingText);
            NotifyOfPropertyChange(() => CanClearCompleted);
        }
        
        public void ClearCompleted()
        {
            tasks.Where(x => x.Done).ToList()
                .ForEach(Remove);
        }
    }
}
