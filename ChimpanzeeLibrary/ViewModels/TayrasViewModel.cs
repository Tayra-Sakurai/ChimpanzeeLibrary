using ChimpanzeeLibrary.Contexts;
using ChimpanzeeLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
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

        public TayrasViewModel(ChimpanzeeContext context)
        {
            this.context = context;
            Tayras = new ObservableCollection<Tayra>();
        }

        [RelayCommand]
        public async Task LoadAsync()
        {
            Tayras.Clear();
            List<Tayra> tayraList = await context.Tayras.ToListAsync();
            tayraList.Sort();
            foreach (Tayra item in tayraList)
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
