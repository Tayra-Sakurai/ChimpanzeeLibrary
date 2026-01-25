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

        [ObservableProperty]
        private double cashTotal = 0;

        [ObservableProperty]
        private double icocaTotal = 0;

        [ObservableProperty]
        private double coopTotal = 0;

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
            CashTotal = 0;
            IcocaTotal = 0;
            CoopTotal = 0;
            List<Tayra> tayraList = await context.Tayras.ToListAsync();
            tayraList.Sort();
            foreach (Tayra item in tayraList)
            {
                Tayras.Add(item);
                CashTotal += (double)item.Cash;
                CoopTotal += (double)item.Coop;
                IcocaTotal += (double)item.Icoca;
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
