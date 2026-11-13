using Application.Interfaces;
using Application.Models.Item;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<ItemDTO> GetAll()
        {
            var items = _itemRepository.GetAll();
            return items.Select(i => new ItemDTO
            {
                Id = i.Id, 
                Name = i.Name,
                Price = i.Price,
                Stock = i.Stock,
                Available = i.Available,
                Description = i.Description,
            }).ToList();
        }

        public ItemDTO? GetById(int id)
        {
            var item = _itemRepository.GetById(id);

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

        public ItemDTO? Add(CreateItemDTO item)
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

            var addedItem = _itemRepository.Add(newItem);

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

        public ItemDTO? Update(ItemDTO item)
        {
            var updateItem = _itemRepository.GetById(item.Id);

            if (updateItem == null) return null;

            updateItem.Name = item.Name;
            updateItem.Price = item.Price;
            updateItem.Stock = item.Stock;
            updateItem.Available = item.Available;
            updateItem.Description = item.Description;

            _itemRepository.Update(updateItem);

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

        public ItemDTO? Delete(int id)
        {
            var item = _itemRepository.GetById(id);

            if (item == null) return null;

            _itemRepository.Delete(id);

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