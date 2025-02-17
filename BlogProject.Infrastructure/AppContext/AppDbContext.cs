using BlogProject.Domain.Core.BaseEntities;
using BlogProject.Domain.Entities;
using BlogProject.Domain.Enums;
using BlogProject.Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.AppContext;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public const string DevConnectionString = "AppConnectionDev";
    private readonly IHttpContextAccessor? _httpContextAccessor;
    
    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor? httpContextAccessor = null) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }

    /// <summary>
    /// Configures the entity models using Fluent API configurations.
    /// This method automatically applies all entity configurations 
    /// from the assembly where <see cref="IEntityConfiguration"/> is defined.
    /// </summary>
    /// <param name="builder">The model builder used to configure entity mappings.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        var userId = _httpContextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "UserNotFound";
        foreach (var entry in entries)
        {
            SetIfAdded(entry, userId);
            SetIfModified(entry, userId);
            SetIfDeleted(entry, userId);
        }
    }

    private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State != EntityState.Deleted)
            return;
        if (entry.Entity is not AuditableEntity entity)
            return;
        entry.Entity.Status = Status.Deleted;
        entry.State = EntityState.Modified;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = userId;

    }

    private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State != EntityState.Modified)
            return;
        entry.Entity.Status = Status.Updated;
        entry.Entity.UpdatedDate = DateTime.UtcNow;
        entry.Entity.UpdatedBy = userId;
    }

    private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
    {
        if (entry.State != EntityState.Added)
            return;
        entry.Entity.Status = Status.Added;
        entry.Entity.UpdatedDate= DateTime.UtcNow;
        entry.Entity.UpdatedBy = userId;
    }
}
