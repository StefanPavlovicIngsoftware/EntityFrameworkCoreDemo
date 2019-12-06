using Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationUnitOfWork : 
        IDisposable,
        IInfrastructure<IServiceProvider>,
        IDbContextDependencies, 
        IDbSetCache, 
        IDbContextPoolable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }

        ChangeTracker ChangeTracker { get; }
        DatabaseFacade Database { get; }
        IModel Model { get; }
        DbContextId ContextId { get; }

        EntityEntry Add([NotNullAttribute] object entity);
        EntityEntry<TEntity> Add<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        ValueTask<EntityEntry> AddAsync([NotNullAttribute] object entity, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNullAttribute] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        void AddRange([NotNullAttribute] params object[] entities);
        void AddRange([NotNullAttribute] IEnumerable<object> entities);
        Task AddRangeAsync([NotNullAttribute] IEnumerable<object> entities, CancellationToken cancellationToken = default);
        Task AddRangeAsync([NotNullAttribute] params object[] entities);
        EntityEntry Attach([NotNullAttribute] object entity);
        EntityEntry<TEntity> Attach<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        void AttachRange([NotNullAttribute] IEnumerable<object> entities);
        void AttachRange([NotNullAttribute] params object[] entities);
        void Dispose();
        ValueTask DisposeAsync();
        EntityEntry Entry([NotNullAttribute] object entity);
        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        bool Equals(object obj);
        TEntity Find<TEntity>([CanBeNullAttribute] params object[] keyValues) where TEntity : class;
        object Find([NotNullAttribute] Type entityType, [CanBeNullAttribute] params object[] keyValues);
        ValueTask<object> FindAsync([NotNullAttribute] Type entityType, [CanBeNullAttribute] object[] keyValues, CancellationToken cancellationToken);
        ValueTask<object> FindAsync([NotNullAttribute] Type entityType, [CanBeNullAttribute] params object[] keyValues);
        ValueTask<TEntity> FindAsync<TEntity>([CanBeNullAttribute] object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>([CanBeNullAttribute] params object[] keyValues) where TEntity : class;
        int GetHashCode();
        DbQuery<TQuery> Query<TQuery>() where TQuery : class;
        EntityEntry Remove([NotNullAttribute] object entity);
        EntityEntry<TEntity> Remove<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        void RemoveRange([NotNullAttribute] IEnumerable<object> entities);
        void RemoveRange([NotNullAttribute] params object[] entities);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
        EntityEntry Update([NotNullAttribute] object entity);
        EntityEntry<TEntity> Update<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        void UpdateRange([NotNullAttribute] IEnumerable<object> entities);
        void UpdateRange([NotNullAttribute] params object[] entities);
    }
}
