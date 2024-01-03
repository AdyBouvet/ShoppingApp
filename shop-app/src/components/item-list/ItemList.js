import { Item } from "./item/Item"

export const ItemList = ({ list }) => {
    return(
        <div>
            {list.map(item => <Item item={item}/>)}
        </div>
    )
}