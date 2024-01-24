import { Item } from "./item/Item"

export const ItemList = ({ list, shoppingList, mode }) => {
    return(
        <div>
            {list.map(item => <Item item={item} shoppingList={shoppingList} mode={mode}/>)}
        </div>
    )
}