using ChallengeMAUI.Challenges.Jour_1.Datas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMAUI.Challenges.Jour_1.ViewModels
{
    public class TaskManageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskModel> TaskMorning { get; set; }
        public ObservableCollection<TaskModel> TaskAfternoon { get; set; }
        public ObservableCollection<TaskModel> TaskEvening { get; set; }

        public TaskManageViewModel()
        {
            TaskMorning = CreateTasks(new[]
            {
            new TaskModel { User = "@alice", TaskDescription = "Check emails Lorem Ipsum is simply dummy text", Time = "20min" },
            new TaskModel { User = "@bob", TaskDescription = "Prepare report Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has", Time = "50min" },
            new TaskModel { User = "@charlie", TaskDescription = "Call supplier Lorem Ipsum is simply dummy text of the printing and ", Time = "30min" }
        }, TaskMorning_Reorder);

            TaskAfternoon = CreateTasks(new[]
            {
            new TaskModel { User = "@diana", TaskDescription = "Team meeting Lorem Ips typesetting industry. Lorem Ipsum has", Time = "45min" },
            new TaskModel { User = "@edward", TaskDescription = "Code review Lorem Ipsum . Lorem Ipsum has", Time = "35min" }
        }, TaskAfternoon_Reorder);

            TaskEvening = CreateTasks(new[]
            {
            new TaskModel { User = "@frank", TaskDescription = "Update dashboard Lorem Ipsum is simply dtry. Lorem Ipsum has", Time = "40min" },
            new TaskModel { User = "@grace", TaskDescription = "Plan next sprint Lorem Ipsum is simply Lorem Ipsum has", Time = "25min" }
        }, TaskEvening_Reorder);
        }

        private ObservableCollection<TaskModel> CreateTasks(IEnumerable<TaskModel> tasks, Action reorderAction)
        {
            var collection = new ObservableCollection<TaskModel>(tasks);

            foreach (var task in collection)
            {
                task.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(TaskModel.Iselected))
                        reorderAction.Invoke();
                };
            }

            return collection;
        }

        private void TaskMorning_Reorder()
        {
            ReorderList(TaskMorning);
        }

        private void TaskAfternoon_Reorder()
        {
            ReorderList(TaskAfternoon);
        }

        private void TaskEvening_Reorder()
        {
            ReorderList(TaskEvening);
        }

        private void ReorderList(ObservableCollection<TaskModel> list)
        {
            var sorted = list.OrderByDescending(t => t.Iselected).ThenBy(t => t.User).ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                if (!Equals(list[i], sorted[i]))
                {
                    list.Move(list.IndexOf(sorted[i]), i);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
