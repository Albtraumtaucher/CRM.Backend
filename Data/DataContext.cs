using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CRM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data
{
        public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
            UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IHttpContextAccessor _accessor;

        public DataContext(IHttpContextAccessor accessor, DbContextOptions<DataContext> options) : base (options) {
            _accessor = accessor;
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadStatus> LeadStatus { get; set; }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<AdressType> AdressTypes { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            
            builder.Entity<Lead>().Property(lead => lead.CreatedOn).HasField("_createdOn");
            builder.Entity<Lead>().Property(lead => lead.CreatedBy).HasField("_createdBy");
            builder.Entity<Lead>().Property(lead => lead.UpdatedOn).HasField("_updatedOn");
            builder.Entity<Lead>().Property(lead => lead.UpdatedBy).HasField("_updatedBy");
            builder.Entity<Lead>().Property(lead => lead.DeletedOn).HasField("_deletedOn");
            builder.Entity<Lead>().Property(lead => lead.DeletedBy).HasField("_deletedBy");
            builder.Entity<Lead>().Property(lead => lead.IsDeleted).HasField("_isDeleted");

            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.CreatedOn).HasField("_createdOn");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.CreatedBy).HasField("_createdBy");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.UpdatedOn).HasField("_updatedOn");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.UpdatedBy).HasField("_updatedBy");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.DeletedOn).HasField("_deletedOn");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.DeletedBy).HasField("_deletedBy");
            builder.Entity<LeadStatus>().Property(leadStatus => leadStatus.IsDeleted).HasField("_isDeleted");
            
            builder.Entity<Lead>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<LeadStatus>().HasQueryFilter(p => !p.IsDeleted);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if(entry.Entity is Lead lead || entry.Entity is LeadStatus leadStatus )
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues["UpdatedOn"] = now;
                            entry.CurrentValues["UpdatedBy"] = user;
                            break;
                        
                        case EntityState.Added:
                            entry.CurrentValues["CreatedOn"] = now;
                            entry.CurrentValues["CreatedBy"] = user;
                            entry.CurrentValues["UpdatedOn"] = now;
                            entry.CurrentValues["UpdatedBy"] = user;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["DeletedOn"] = now;
                            entry.CurrentValues["DeletedBy"] = user;
                            break;
                    }
                }
            }
        }

        private int GetCurrentUser()
        {
            var user = _accessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();

            return Int32.Parse(user);
        }
    }
    
}