using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpanzeeLibrary.Models
{
    public class Tayra : IComparable<Tayra>
    {
        public int Id { get; set; }
        public string Event { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Cash { get; set; } = 0;
        public decimal Icoca { get; set; } = 0;
        public decimal Coop { get; set; } = 0;

        public int CompareTo(Tayra other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
