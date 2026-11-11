using Application.Models.Item;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IItemService
    {
        Task<List<ItemDTO>> GetAllAsync();
        Task<ItemDTO?> GetByIdAsync(int id);
        Task<List<ItemDTO>> GetAvailableItemsAsync();
        Task<ItemDTO?> AddAsync(CreateItemDTO item);
        Task<ItemDTO?> UpdateAsync(ItemDTO item);
        Task<ItemDTO?> DeleteAsync(int id);
    }
}