using Application.Interfaces;
using Application.Models.Item;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemDTO>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return items.Select(i => new ItemDTO
            {
                Id = i.Id, 
                Name = i.Name,
                Price = i.Price,
                Stock = i.Stock,
                Available = i.Available,
                Description = i.Description
            }).ToList();
        }

        public async Task<ItemDTO?> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item == null) return null;

            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Stock = item.Stock,
                Available = item.Available,
                Description = item.Description,
            };
        }

        public async Task<List<ItemDTO>> GetAvailableItemsAsync()
        {
            var availableItems = await _itemRepository.GetAvailableItemsAsync();
            return availableItems.Select(i =>  new ItemDTO{
                Id = i.Id, 
                Name = i.Name,
                Price = i.Price,
                Stock = i.Stock,
                Available = i.Available,
                Description = i.Description
            }).ToList();
        }

        public async Task<ItemDTO?> AddAsync(CreateItemDTO item)
        {
            if (item == null) return null;
            if(item.Stock < 0)
            {
                throw new Exception("El stock no puede ser negativo");
            }

            var newItem = new Item
            {
                Name = item.Name,
                Price = item.Price,
                Stock = item.Stock,
                Available = item.Stock > 0,
                Description = item.Description,
            };

            var addedItem = await _itemRepository.AddAsync(newItem);
            if (addedItem == null) return null;

            return new ItemDTO
            {
                Id = addedItem.Id,
                Name = addedItem.Name,
                Price = addedItem.Price,
                Stock = addedItem.Stock,
                Available = addedItem.Available,
                Description = addedItem.Description,
            };
        }

        public async Task<ItemDTO?> UpdateAsync(ItemDTO item)
        {
            var updateItem = await _itemRepository.GetByIdAsync(item.Id);

            if (updateItem == null) return null;

            updateItem.Name = item.Name;
            updateItem.Price = item.Price;
            updateItem.Stock = item.Stock;
            updateItem.Available = item.Available;
            updateItem.Description = item.Description;

            await _itemRepository.UpdateAsync(updateItem);

            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = updateItem.Price,
                Stock = updateItem.Stock,
                Available = updateItem.Available,
                Description = updateItem.Description,
            };
        }

        public async Task<ItemDTO?> DeleteAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item == null) return null;

            await _itemRepository.DeleteAsync(id);

            return new ItemDTO
            {   
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Stock = item.Stock,
                Available = item.Available,
                Description = item.Description,
            };
        }
    }
}