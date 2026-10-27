using Application.Models.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IItemService
    {
        public List<ItemDTO> GetAll();
        public ItemDTO? GetById(int id);
        public ItemDTO? Add(CreateItemDTO item);
        public ItemDTO? Update(ItemDTO item);
        public ItemDTO? Delete(int id);
    }
}
