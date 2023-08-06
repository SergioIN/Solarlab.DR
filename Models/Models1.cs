using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Solarlab.DR.Models
{
    internal class Models1: INotifyPropertyChanged
    {
		
		private string _initials;

		public string Initials
        {
			get { return _initials ; }
			set { _initials = value; }
		}


        private string _datesText;

		public string DatesText
        {
            get { return _datesText; }
            set
            {
                if (_datesText == value)
                    return;
                _datesText = value;
                OnPropertyChanged("DatesText");

            }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;
                _status = value;
                OnPropertyChanged(Status);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        




    }
}
