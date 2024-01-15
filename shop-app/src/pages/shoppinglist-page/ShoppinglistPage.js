import { ItemList } from "../../components/item-list/ItemList";
import { useState, useEffect } from "react"
import { GetItems } from "../../services/ItemService";
import { SearchBar } from "../../components/search-bar/SearchBar"

export const ShoppinglistPage = () => {

    const [name, setName] = useState("")
    const [items, setItems] = useState([]);
    const [itemSearch, setItemSearch] = useState([])



    const onSearch = input => {
        if (typeof input == "string") {
            if (input.length === 0)
                setItemSearch([...items])
            else {
                var a = items.filter(item => item.name.toLowerCase().includes(input.toLowerCase()))
                console.log(a)
                setItemSearch(a)
            }
            setName(input)
        }
    }

    function getData() {
        GetItems().then(a => {
            setItems(a)
            setItemSearch(a)
        })
    }

    useEffect(() => {
        getData()
    }, [])

    return (
        <div onChange={onSearch}>
            <h1>Shoppinglist</h1>
            {items.length > 0 && <ItemList list={itemSearch} />}
            {items.length > 0 && <SearchBar search={name} setSearch={onSearch}></SearchBar>}
        </div>
    );
}