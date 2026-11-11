using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Item>> GetAllAsync()
        {
            var items = await _context.Items.ToListAsync();
            return items;
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) return null;
            return item;
        }

        public async Task<List<Item>> GetAvailableItemsAsync()
        {
            var availableItems = await _context.Items.Where(i => i.Available).ToListAsync();
            return availableItems;
        }

        public async Task<Item?> AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            return item;
        }

        public async Task<Item?> UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            return item;
        }

        public async Task<Item?> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if(item == null) return null;

            _context.Items.Remove(item);
            return item;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}