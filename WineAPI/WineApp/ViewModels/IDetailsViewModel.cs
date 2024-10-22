using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public interface IDetailsViewModel
    {
        ImageSource Photo { get; set; }
        Recipe DetectedRecipe { get; set; }
        ICommand ToggleFavoriteCommand { get; set; }
        ICommand ShowMoreWinesCommand { get; set; }
        ICommand NavigateToWineCommand { get; set; }
    }
}
