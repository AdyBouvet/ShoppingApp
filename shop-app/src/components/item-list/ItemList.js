import { Item } from "./item/Item"

export const ItemList = ({ list, shoppingList, remove, add }) => {
    return(
        <div>
            {list.map(item => <Item item={item} shoppingList={shoppingList} remove={remove} add={add}/>)}
        </div>
    )
}