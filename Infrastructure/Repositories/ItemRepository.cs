using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Item> GetAll()
        {
            return _context.Items;
        }

        public Item? GetById(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return null;
            return item;
        }

        public Item Add(Item item)
        {
            _context.Items.Add(item);
            return item;
        }

        public Item Update(Item item)
        {
            var index = _context.Items.FindIndex(i => i.Id == item.Id);
            if (index == -1) return item;

            _context.Items[index] = item;
            return item;
        }

        public Item? Delete(int id)
        {
            var item = GetById(id);
            if(item == null) return null;

            _context.Items.Remove(item);
            return item;
        }
    }
}