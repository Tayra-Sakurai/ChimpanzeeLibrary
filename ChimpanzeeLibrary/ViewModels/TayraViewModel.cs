using ChimpanzeeLibrary.Contexts;
using ChimpanzeeLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChimpanzeeLibrary.ViewModels
{
    public partial class TayraViewModel : ObservableObject
    {
        private readonly ChimpanzeeContext _context;

        private Tayra tayra;

        [ObservableProperty]
        private DateTimeOffset date;

        [ObservableProperty]
        private TimeSpan timeOfDay;

        [ObservableProperty]
        private string evt;

        [ObservableProperty]
        private double cash;

        [ObservableProperty]
        private double icoca;

        [ObservableProperty]
        private double coop;

        public TayraViewModel()
        {
            _context = new ChimpanzeeContext();
            tayra = new Tayra();
            Date = new DateTimeOffset(tayra.Date.Date);
            TimeOfDay = tayra.Date.TimeOfDay;
            Evt = tayra.Event;
            Cash = (double)tayra.Cash;
            Icoca = (double)tayra.Icoca;
            Coop = (double)tayra.Coop;
        }

        public TayraViewModel(Tayra tayra)
        {
            _context = new ChimpanzeeContext();
            InitializeForExistingValue(tayra);
        }

        public void InitializeForExistingValue(Tayra value)
        {
            tayra = value;
            Date = new DateTimeOffset(tayra.Date.Date);
            TimeOfDay = tayra.Date.TimeOfDay;
            Evt = tayra.Event;
            Cash = (double)tayra.Cash;
            Icoca = (double)tayra.Icoca;
            Coop = (double)tayra.Coop;
        }

        [RelayCommand(CanExecute = nameof(CanDeleteOrUpdate))]
        public void Save()
        {
            tayra.Event = Evt;
            tayra.Cash = (decimal)Cash;
            tayra.Icoca = (decimal)Icoca;
            tayra.Coop = (decimal)Coop;
            DateTime datetime = Date.Date;
            datetime = datetime.Add(TimeOfDay);
            tayra.Date = datetime;
            _context.Update(tayra);
            DeleteCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanDeleteOrUpdate))]
        public void Delete()
        {
            _context.Remove(tayra);
        }

        [RelayCommand]
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool CanDeleteOrUpdate()
        {
            var entry = _context.Entry(tayra);
            if (entry == null)
            {
                return false;
            }
            else if (entry.State == EntityState.Deleted)
            {
                return false;
            }
            else if (entry.State == EntityState.Detached)
            {
                return false;
            }
            return true;
        }
    }
}
