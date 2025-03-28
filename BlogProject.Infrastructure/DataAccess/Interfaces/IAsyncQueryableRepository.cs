﻿using BlogProject.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BlogProject.Infrastructure.DataAccess.Interfaces;

public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllDataAsync(bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes);
}
