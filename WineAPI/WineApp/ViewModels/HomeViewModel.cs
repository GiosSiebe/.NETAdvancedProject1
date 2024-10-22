using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineApp.Services;

namespace WineApp.ViewModels
{
    public class HomeViewModel : ObservableObject, IHomeViewModel
    {
        public ICommand AnalyzePictureCommand { get; set; }
        private INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService) {
            _navigationService = navigationService;
        }
        private void BindCommands()
        {
            AnalyzePictureCommand = new AsyncRelayCommand(GoToDetailsShow);
        }

        private async Task GoToDetailsShow()
        {
            await _navigationService.NavigateToDetailsAsync();
        }
    }
}
