import { Item } from "./item/Item"

export const ItemList = ({ list, shoppingList, mode, rerender }) => {
    return(
        <div>
            {list.map(item => <Item item={item} shoppingList={shoppingList} mode={mode} rerender={rerender}/>)}
        </div>
    )
}