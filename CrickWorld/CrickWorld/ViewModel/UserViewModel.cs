using CrickWorld.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrickWorld.Annotations;
using Xamarin.Forms;

namespace CrickWorld.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private List<UserDetails> _userList;
        private UserDetails _selectedUser = new UserDetails();
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy=false;
        private string _statusMessage=null;

        public List<UserDetails> userList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                OnPropertyChanged();
            }
        }
        public UserDetails SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value; 
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage=value;
                OnPropertyChanged();
            }
        }

        public UserViewModel()
        {
            InitiliseDataAsync();

        }

        public Command PostCommand2
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var userServices = new UserServices();
                    var IsSuccess= await userServices.postUsersAsync(_selectedUser);

                    if (IsSuccess)
                    { StatusMessage = "Add Susseccfully"; }
                    else
                    { StatusMessage = "Sorry! Something went wronge."; }
                    IsBusy = false;

                });
            }

        }

        private async Task InitiliseDataAsync()
        {
            IsBusy = true;
            var userServices = new UserServices();
            userList = await userServices.GetUsersAsync();
            IsBusy = false;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
