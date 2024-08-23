﻿using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities.Common;
using System.Linq.Expressions;


namespace ECommerceServer.Application.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntitiy
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
