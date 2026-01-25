using ChimpanzeeLibrary.Contexts;
using ChimpanzeeLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpanzeeLibrary.ViewModels
{
    public partial class TayrasViewModel : ObservableObject
    {
        private ChimpanzeeContext context;

        [ObservableProperty]
        private ObservableCollection<Tayra> tayras;

        public TayrasViewModel()
        {
            context = new ChimpanzeeContext();
            Tayras = new ObservableCollection<Tayra>();
        }

        [RelayCommand]
        public async Task LoadAsync()
        {
            Tayras.Clear();
            await foreach (Tayra item in context.Tayras.AsAsyncEnumerable())
            {
                Tayras.Add(item);
            }
        }

        [RelayCommand]
        public async Task AddAsync()
        {
            context.Add(new Tayra());
            await context.SaveChangesAsync();
            await LoadAsync();
        }
    }
}
