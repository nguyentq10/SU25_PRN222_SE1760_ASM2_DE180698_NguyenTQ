﻿using DNATest.Repositories.NguyenTQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ.Basic
{
    public class GenericRepository<T> where T : class
    {
        protected SU25_PRN222_SE1706_G6_ADNTestServiceContext _context;

        public GenericRepository()
        {
            _context ??= new SU25_PRN222_SE1706_G6_ADNTestServiceContext();
        }

        public GenericRepository(SU25_PRN222_SE1706_G6_ADNTestServiceContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<int> CreateAsync(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            //// Turning off Tracking for UpdateAsync in Entity Framework
            _context.ChangeTracker.Clear();
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            //// Turning off Tracking for UpdateAsync in Entity Framework
            _context.ChangeTracker.Clear();
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            return await _context.SaveChangesAsync();

            /*
            try
            {
                // Get primary key dynamically
                var keyValues = _context.Model.FindEntityType(typeof(T))
                                ?.FindPrimaryKey()
                                ?.Properties
                                ?.Select(p => p.PropertyInfo.GetValue(entity))
                                .ToArray();

                if (keyValues == null || keyValues.Length == 0)
                    throw new InvalidOperationException("No primary key defined for entity.");

                // Fetch existing entity without tracking
                var existingEntity = await _context.Set<T>().FindAsync(keyValues);

                if (existingEntity == null) return 0;

                _context.Entry(existingEntity).State = EntityState.Detached; // ✅ Prevent tracking conflicts
                _context.Entry(entity).State = EntityState.Modified; // ✅ Mark for update

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }           
             */
        }

        public bool Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(string code)
        {
            return _context.Set<T>().Find(code);
        }

        public async Task<T> GetByIdAsync(string code)
        {
            return await _context.Set<T>().FindAsync(code);
        }

        /*
        https://guidgenerator.com/
        daacb4fb-ff73-46ef-98f1-4af9aab2a30a
         */
        public T GetById(Guid code)
        {
            return _context.Set<T>().Find(code);
        }

        public async Task<T> GetByIdAsync(Guid code)
        {
            return await _context.Set<T>().FindAsync(code);
        }


        #region Separating asigned entity and save operators        

        public void PrepareCreate(T entity)
        {
            _context.Add(entity);
        }

        public void PrepareUpdate(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
        }

        public void PrepareRemove(T entity)
        {
            _context.Remove(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion Separating asign entity and save operators
    }
}
