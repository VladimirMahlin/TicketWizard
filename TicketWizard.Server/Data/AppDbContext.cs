using TicketWizard.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketWizard.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<EventPerformer> EventPerformers { get; set; }
        public DbSet<EventOrganiser> EventOrganisers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasIndex(e => e.Username)
                      .IsUnique();

                entity.Property(e => e.FirstName)
                      .HasMaxLength(255);

                entity.Property(e => e.LastName)
                      .HasMaxLength(255);

                entity.Property(e => e.Phone)
                      .HasMaxLength(50);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasIndex(e => e.Email)
                      .IsUnique();

                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.RememberToken)
                      .HasMaxLength(255);

                entity.HasMany(e => e.Orders)
                      .WithOne(e => e.User)
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.HasKey(e => e.VenueId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.VenueName)
                      .HasMaxLength(255);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasOne(d => d.Country)
                      .WithMany(p => p.Venues)
                      .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.City)
                      .WithMany(p => p.Venues)
                      .HasForeignKey(d => d.CityId);

                entity.Property(e => e.Address1)
                      .HasMaxLength(255);

                entity.Property(e => e.Address2)
                      .HasMaxLength(255);

                entity.Property(e => e.PostalCode)
                      .HasMaxLength(20);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EventName)
                      .HasMaxLength(255);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasMany(e => e.EventPerformers)
                      .WithOne(e => e.Event)
                      .HasForeignKey(e => e.EventId);

                entity.HasMany(e => e.EventOrganisers)
                      .WithOne(e => e.Event)
                      .HasForeignKey(e => e.EventId);

                entity.HasMany(e => e.Orders)
                      .WithOne(e => e.Event)
                      .HasForeignKey(e => e.EventId);
                
                entity.HasMany(t => t.Tickets)
                      .WithOne(t => t.Event)
                      .HasForeignKey(t => t.EventId);
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasKey(e => e.PerformerId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PerformerName)
                      .HasMaxLength(255);

                entity.HasMany(e => e.EventPerformers)
                      .WithOne(e => e.Performer)
                      .HasForeignKey(e => e.PerformerId);
            });

            modelBuilder.Entity<Organiser>(entity =>
            {
                entity.HasKey(e => e.OrganiserId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrganiserName)
                      .HasMaxLength(255);

                entity.Property(e => e.About)
                      .HasMaxLength(1000);

                entity.Property(e => e.Email)
                      .HasMaxLength(255);

                entity.Property(e => e.Phone)
                      .HasMaxLength(50);

                entity.Property(e => e.Facebook)
                      .HasMaxLength(255);

                entity.Property(e => e.Twitter)
                      .HasMaxLength(255);

                entity.HasMany(e => e.EventOrganisers)
                      .WithOne(e => e.Organiser)
                      .HasForeignKey(e => e.OrganiserId);
            });

            modelBuilder.Entity<EventPerformer>(entity =>
            {
                entity.HasKey(e => e.EventPerformerId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Event)
                      .WithMany(p => p.EventPerformers)
                      .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Performer)
                      .WithMany(p => p.EventPerformers)
                      .HasForeignKey(d => d.PerformerId);
                
                entity.HasIndex(e => e.EventId);
                entity.HasIndex(e => e.PerformerId);
                entity.HasIndex(e => new { e.EventId, e.PerformerId })
                      .IsUnique();
            });

            modelBuilder.Entity<EventOrganiser>(entity =>
            {
                entity.HasKey(e => e.EventOrganiserId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Event)
                      .WithMany(p => p.EventOrganisers)
                      .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Organiser)
                      .WithMany(p => p.EventOrganisers)
                      .HasForeignKey(d => d.OrganiserId);

                entity.HasIndex(e => e.EventId);
                entity.HasIndex(e => e.OrganiserId);
                entity.HasIndex(e => new { e.EventId, e.OrganiserId })
                      .IsUnique();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CountryName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasIndex(e => e.CountryName)
                      .IsUnique();

                entity.Property(e => e.CountryCode)
                      .IsRequired()
                      .HasMaxLength(3);

                entity.HasIndex(e => e.CountryCode)
                      .IsUnique();

                entity.HasOne(d => d.Currency)
                      .WithMany(p => p.Countries)
                      .HasForeignKey(d => d.CurrencyId);

                entity.Property(e => e.Iso31661)
                      .HasMaxLength(5);

                entity.HasIndex(e => e.Iso31661)
                      .IsUnique();

                entity.Property(e => e.RegionCode)
                      .HasMaxLength(10);

                entity.Property(e => e.SubRegionCode)
                      .HasMaxLength(10);

                entity.HasMany(e => e.Venues)
                      .WithOne(e => e.Country)
                      .HasForeignKey(e => e.CountryId);

                entity.HasMany(e => e.Cities)
                      .WithOne(e => e.Country)
                      .HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CityName)
                      .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                      .WithMany(p => p.Cities)
                      .HasForeignKey(d => d.CountryId);
                
                entity.HasMany(e => e.Venues)
                      .WithOne(e => e.City)
                      .HasForeignKey(e => e.CityId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.OrderStatus)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(d => d.OrderStatusId);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Event)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(d => d.EventId);

                entity.HasOne(o => o.Transaction)
                      .WithOne(t => t.Order)
                      .HasForeignKey<Order>(o => o.TransactionId);

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AmountRefunded)
                      .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Notes)
                      .HasMaxLength(1000);

                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.EventId);
                entity.HasIndex(e => e.TransactionId)
                      .IsUnique();
                entity.HasIndex(e => e.OrderStatusId);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.HasMany(e => e.Orders)
                      .WithOne(e => e.OrderStatus)
                      .HasForeignKey(e => e.OrderStatusId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.TransactionType)
                      .WithMany(p => p.Transactions)
                      .HasForeignKey(d => d.TransactionTypeId);

                entity.HasOne(d => d.TransactionStatus)
                      .WithMany(p => p.Transactions)
                      .HasForeignKey(d => d.TransactionStatusId);

                entity.Property(e => e.TransactionDate)
                      .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Currency)
                      .WithMany(p => p.Transactions)
                      .HasForeignKey(d => d.CurrencyId);

                entity.HasOne(d => d.PaymentMethod)
                      .WithMany(p => p.Transactions)
                      .HasForeignKey(d => d.PaymentMethodId);

                entity.Property(e => e.TransactionReference)
                      .HasMaxLength(255);

                entity.HasOne(t => t.Order)
                      .WithOne(o => o.Transaction)
                      .HasForeignKey<Order>(o => o.TransactionId);
                
                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasOne(d => d.Gateway)
                      .WithMany(p => p.Transactions)
                      .HasForeignKey(d => d.GatewayId);

                entity.Property(e => e.Fees)
                      .HasColumnType("decimal(10, 2)");

                entity.HasIndex(e => e.OrderId);
                entity.HasIndex(e => e.RefundId);
                entity.HasIndex(e => e.CurrencyId);
                entity.HasIndex(e => e.PaymentMethodId);
                entity.HasIndex(e => e.GatewayId);
                entity.HasIndex(e => e.TransactionTypeId);
                entity.HasIndex(e => e.TransactionStatusId);
                
                entity.HasMany(e => e.Refunds)
                      .WithOne(e => e.Transaction)
                      .HasForeignKey(e => e.TransactionId);
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.HasKey(e => e.RefundId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Transaction)
                      .WithMany(p => p.Refunds)
                      .HasForeignKey(d => d.TransactionId);

                entity.Property(e => e.RefundDate)
                      .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Reason)
                      .HasMaxLength(1000);

                entity.HasIndex(e => e.TransactionId);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasMany(e => e.Transactions)
                      .WithOne(e => e.TransactionType)
                      .HasForeignKey(e => e.TransactionTypeId);
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.HasKey(e => e.TransactionStatusId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasMany(e => e.Transactions)
                      .WithOne(e => e.TransactionStatus)
                      .HasForeignKey(e => e.TransactionStatusId);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Code)
                      .IsRequired()
                      .HasMaxLength(3);

                entity.HasIndex(e => e.Code)
                      .IsUnique();

                entity.Property(e => e.Symbol)
                      .HasMaxLength(5);

                entity.Property(e => e.SubCurrency)
                      .HasMaxLength(50);

                entity.HasMany(e => e.Countries)
                      .WithOne(e => e.Currency)
                      .HasForeignKey(e => e.CurrencyId);

                entity.HasMany(e => e.Transactions)
                      .WithOne(e => e.Currency)
                      .HasForeignKey(e => e.CurrencyId);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasMany(e => e.Transactions)
                      .WithOne(e => e.PaymentMethod)
                      .HasForeignKey(e => e.PaymentMethodId);
            });

            modelBuilder.Entity<Gateway>(entity =>
            {
                entity.HasKey(e => e.GatewayId);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                entity.HasMany(e => e.Transactions)
                      .WithOne(e => e.Gateway)
                      .HasForeignKey(e => e.GatewayId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketId);

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Event)
                      .WithMany(p => p.Tickets)
                      .HasForeignKey(d => d.EventId)
                      .IsRequired();

                entity.HasOne(d => d.Order)
                      .WithMany(p => p.Tickets)
                      .HasForeignKey(d => d.OrderId);
            });
        }
    }
}