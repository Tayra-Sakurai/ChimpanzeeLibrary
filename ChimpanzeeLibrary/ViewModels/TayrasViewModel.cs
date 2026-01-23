using ChimpanzeeLibrary.Contexts;
using ChimpanzeeLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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

        public async Task LoadAsync()
        {
            Tayras.Clear();
            await foreach (Tayra item in context.Tayras.AsAsyncEnumerable())
            {
                Tayras.Add(item);
            }
        }
    }
}
