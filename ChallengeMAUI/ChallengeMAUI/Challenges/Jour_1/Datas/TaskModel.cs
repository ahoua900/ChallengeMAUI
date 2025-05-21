using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMAUI.Challenges.Jour_1.Datas
{
    public class TaskModel : INotifyPropertyChanged
    {
        private bool _iselected;

        public string User { get; set; }
        public string TaskDescription { get; set; }
        public string Time { get; set; }

        public bool Iselected
        {
            get => _iselected;
            set
            {
                if (_iselected != value)
                {
                    _iselected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Iselected)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
