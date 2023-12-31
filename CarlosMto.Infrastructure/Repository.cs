﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlosMto.Entity.Entities;
using CarlosMto.Infrastructure.Context;

namespace CarlosMto.Infrastructure
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductDbContext _dbContext;
        private DbSet<T> _dbSet;

        private DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

        public Repository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(_ => (_ as EntityBase).Id == id);
        }
        public async Task<List<T>> GetAll()
        {
            return DbSet.ToList();
        }
        public async Task<List<T>> GetByRange(IDictionary<string, string> parameters)
        {
            var query = DbSet.AsQueryable();

            foreach (var parameter in parameters)
            {
                query = query.Where(item => EF.Property<string>(item, parameter.Key) == parameter.Value);
            }

            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }

    //public class Repository<T> : IRepository<T> where T : class
    //{
    //    private readonly DbContext _dbContext;
    //    private DbSet<T> _dbSet;

    //    private DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

    //    public Repository(DbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public void Add(T entity)
    //    {
    //        DbSet.Add(entity);
    //    }

    //    public void Delete(T entity)
    //    {
    //        DbSet.Remove(entity);
    //    }

    //    public async Task<T> GetAsync(int id)
    //    {
    //        // Asumo que todas las entidades tienen una propiedad "Id"
    //        var entity = await DbSet.FindAsync(id);
    //        return entity;
    //    }

    //    public async Task<List<T>> GetAll()
    //    {
    //        return await DbSet.ToListAsync();
    //    }

    //    public async Task<List<T>> GetByRange(IDictionary<string, string> parameters)
    //    {
    //        var query = DbSet.AsQueryable();

    //        foreach (var parameter in parameters)
    //        {
    //            query = query.Where(item => EF.Property<string>(item, parameter.Key) == parameter.Value);
    //        }

    //        return await query.ToListAsync();
    //    }

    //    public void Update(T entity)
    //    {
    //        DbSet.Update(entity);
    //    }
    //}
}