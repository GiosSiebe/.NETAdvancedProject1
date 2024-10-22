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
        Wine DetectedWine { get; set; }
        ICommand ToggleFavoriteCommand { get; set; }
        ICommand ShowMoreRecipesCommand { get; set; }
        ICommand EditRecipesCommand { get; set; }
    }
}
