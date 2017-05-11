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
        public UserViewModel()
        {
             InitiliseDataAsync();

        }

        public Command PostCommand2
        {
            get
            { 
                return new Command(async() => {

                    var userServices = new UserServices();
                   await userServices.postUsersAsync(_selectedUser);
                });
            }

        }

        private async Task InitiliseDataAsync()
        {
            var userServices = new UserServices();
            userList = await userServices.GetUsersAsync();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
