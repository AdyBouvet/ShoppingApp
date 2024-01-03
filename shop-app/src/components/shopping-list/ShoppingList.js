import { ItemList } from "../item-list/ItemList"

export const ShoppingList = ({ list }) => {
    return(
        <div>
            <h1>{list.Name}</h1>
            <ItemList list={list.Items}/>
        </div>
    )
}