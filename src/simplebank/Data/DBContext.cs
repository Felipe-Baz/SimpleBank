using Microsoft.EntityFrameworkCore;
using simplebank.Model;

namespace simplebank.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        
        public User GetUserByIdWithDeleted(int userId)
        {
            return Users.IgnoreQueryFilters().FirstOrDefault(u => u.Id == userId);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // Define campo unico
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();
            
            // Define campo como required
            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .IsRequired();
            
            // Define campo unico
            modelBuilder.Entity<User>()
                .HasIndex(user => user.PhoneNumber)
                .IsUnique();
            
            // Define campo como required
            modelBuilder.Entity<User>()
                .Property(user => user.PhoneNumber)
                .IsRequired();
            
            // Define campo como required
            modelBuilder.Entity<User>()
                .Property(user => user.Fullname)
                .IsRequired();
            
            // Define campo como required
            modelBuilder.Entity<Transfer>()
                .Property(user => user.FromUserId)
                .IsRequired();
            
            // Define campo como required
            modelBuilder.Entity<Transfer>()
                .Property(user => user.ToUserId)
                .IsRequired();

            // Soft Delete dos Users
            modelBuilder.Entity<User>().HasQueryFilter(u => u.Status != "DELETED");

            // Relação entre Transferencia e User (Remetente)
            modelBuilder.Entity<Transfer>()
                .HasOne(transfer => transfer.FromUser)
                .WithMany(user => user.SendTransfers)
                .HasForeignKey(transferencia => transferencia.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Relação entre Transferencia e User (Destinatario)
            modelBuilder.Entity<Transfer>()
                .HasOne(transferencia => transferencia.ToUser)
                .WithMany(user => user.ReceiveTransfers)
                .HasForeignKey(transferencia => transferencia.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}