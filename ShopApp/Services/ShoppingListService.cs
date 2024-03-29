﻿using ShopApp.Converters;
using ShopApp.Migrations;
using ShopApp.Models;
using ShopApp.Models.DTO;
using ShopApp.Repositories;
using ShopApp.Utils;
using System.Diagnostics.Eventing.Reader;

namespace ShopApp.Services
{
    public class ShoppingListService
    {

        private readonly ShoppingListRepository _repo;
        private readonly ItemRepository _itemRepo;
        private readonly ItemShoppingListRepository _itemShopRepo;
        private readonly ShoppingListConverter _converter;

        public ShoppingListService(ShoppingListRepository repo, ShoppingListConverter converter, ItemRepository itemRepo, ItemShoppingListRepository itemShopRepo)
        {
            _repo = repo;
            _converter = converter;
            _itemRepo = itemRepo;
            _itemShopRepo = itemShopRepo;
        }

        public List<ShoppingListDTO> GetAll()
        {
            List<ShoppingList> shoppingLists = _repo.GetAll();
            List<ShoppingListDTO> response = _converter.Convert(shoppingLists);
            return response;
        }

        public ShoppingListDTO? Get(string name) =>
            _converter.Convert(_repo.Get(name));

        public Output Create(ShoppingListDTO shoppingList)
        {
            if (_repo.Get(shoppingList.Name) != null)
                return Out.Exists(shoppingList.Name);

            _repo.Create(_converter.Convert(shoppingList));
            return Out.Created(shoppingList.Name);
        }

        public Output Add(string itemName, string listName, int amount, string comment, bool bought = false)
        {
            Item? item = _itemRepo.Get(itemName);
            if (item == null)
                return Out.NotFound(itemName);

            ShoppingList? list = _repo.Get(listName);
            if (list == null)
                return Out.NotFound(listName);

            if (list.Item.Any(x => x.Item.Name == item.Name))
                return Out.Exists(item.Name);

            ItemShoppingList itemShop = new()
            {
                ShoppingList = list,
                Item = item,
                Amount = amount,
                Comment = comment,
                Bought = bought
            };

            _itemShopRepo.Create(itemShop);

            _repo.Update(list);
            return Out.Added(itemName, listName);
        }

        public Output Remove(string itemName, string listName)
        {
            ShoppingList? list = _repo.Get(listName);
            if (list == null)
                return Out.NotFound(listName);

            Item? item = _itemRepo.Get(itemName);
            if (item == null)
                return Out.NotFound(itemName);

            ItemShoppingList? itemShopList = _itemShopRepo.Get(item, list);
            if (itemShopList == null)
                return Out.NotFound(itemName);

            _itemShopRepo.Delete(itemShopList);
            return Out.Removed(itemName, listName);

        }
        public Output Delete(string name)
        {
            ShoppingList? list = _repo.Get(name);
            if (list != null)
            {
                _repo.Delete(list);
                return Out.Deleted(name);
            }
            return Out.NotFound(name);
        }

        public Output Buy(string itemName, string listName, bool bought)
        {
            ShoppingList? list = _repo.Get(listName);
            if (list == null)
                return Out.NotFound(listName);

            ItemShoppingList? item = list.Item.FirstOrDefault(x => x.Item.Name == itemName);
            if (item == null)
                return Out.NotFound(itemName);

            Remove(itemName, listName);

            return Add(itemName, listName, item.Amount, item.Comment, bought);
        }


    }
}
