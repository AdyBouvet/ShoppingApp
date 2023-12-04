using ShopApp.Converters;
using ShopApp.Models;
using ShopApp.Models.DTO;

namespace ShopApp.Converters
{
    public class ShoppingListConverter
    {

        private readonly ItemConverter _itemConverter;

        public ShoppingListConverter(ItemConverter itemConverter)
        {
            _itemConverter = itemConverter;
        }

        public ShoppingList Convert(ShoppingListDTO shoppingList)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = shoppingList.Name,
                Type = shoppingList.Type,
            };
        }


        public List<ShoppingList> Convert(List<ShoppingListDTO> shoppingList) =>
            shoppingList.Select(list => Convert(list)).ToList();

        public ShoppingListDTO? Convert(ShoppingList shoppingList)
        {
            return new()
            {
                Type = shoppingList.Type,
                Name = shoppingList.Name,
                Items = _itemConverter.Convert(shoppingList.Item)

            };
        }


        public List<ShoppingListDTO?> Convert(List<ShoppingList> shoppingList) =>
            shoppingList.Select(list => Convert(list)).ToList();
    }
}
