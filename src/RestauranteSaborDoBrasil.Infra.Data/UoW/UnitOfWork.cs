﻿using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Infra.Data.Context;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WritingDbContext _context;

        public UnitOfWork(WritingDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return (rowsAffected > 0);
        }

        public async Task<bool> CommitAsync()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
