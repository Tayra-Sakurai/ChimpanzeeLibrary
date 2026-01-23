using ChimpanzeeLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChimpanzeeLibrary.Contexts
{
    public partial class ChimpanzeeContext : DbContext
    {
        public DbSet<Tayra> Tayras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chimpanzee;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tayra>(
                tayra =>
                {
                    tayra.ToTable("Tayras");
                    tayra.HasKey(t => t.Id);
                    tayra.Property(t => t.Date)
                    .IsRequired()
                    .HasDefaultValueSql("getdate()");
                    tayra.Property(t => t.Cash)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValue(0)
                    .IsRequired();
                    tayra.Property(t => t.Icoca)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValue(0)
                    .IsRequired();
                    tayra.Property(t => t.Coop)
                    .HasColumnType("decimal(18,0)")
                    .IsRequired()
                    .HasDefaultValue(0);
                    tayra.Property(t => t.Event)
                    .IsRequired()
                    .HasColumnType("ntext");
                }
            );
        }
    }
}
