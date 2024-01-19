import { ItemList } from "../../components/item-list/ItemList";
import { useState, useEffect } from "react"
import { GetItems } from "../../services/ItemService";
import { SearchBar } from "../../components/search-bar/SearchBar"
import { Button, Form } from "react-bootstrap"
import { GetShoppingList, GetShoppingLists } from "../../services/ShoppingListService"

export const ShoppinglistPage = () => {

    const [name, setName] = useState("")
    const [items, setItems] = useState([]);
    const [itemSearch, setItemSearch] = useState([])
    const [category, setCategory] = useState("Default")
    const [categories, setCategories] = useState(["A", "B"]);
    const [show, setShow] = useState(true)

    const onCategoryInput = ({ target: { value } }) => setCategory(value)

    const onSearch = input => {
        if (typeof input == "string") {
            if (input.length === 0)
                setItemSearch([...items])
            else {
                var a = items.filter(item => item.name.toLowerCase().includes(input.toLowerCase()))
                setItemSearch(a)
            }
            setName(input)
        }
    }
    const onSwitch = (type) => {
        if (type === "show") {
            setShow(true)
            if (category !== "Default") {
                GetShoppingList(category).then(a => {
                    setItems(a.items)
                    setItemSearch(a.items)
                })

            }
        } else {
            setShow(false)
            GetItems().then(a => {
                setItems(a)
                setItemSearch(a)
            })
        }
    }

    function getData() {
        GetShoppingLists().then(a => {
            setCategories(a)
        })
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
            <div>
                <Button onClick={() => onSwitch("show")}>Show</Button>
                <Button onClick={() => onSwitch("add")}>Add</Button>
            </div>
            <Form>
                <Form.Group className="mb-3" controlId="category">
                    <Form.Label>Shoppinglist name</Form.Label>
                    <Form.Select isInvalid={category === "Default"} aria-label="Default select example" value={category} onChange={onCategoryInput}>
                        <option value="Default">Select category</option>
                        {categories.map(x => <option key={x.name} value={x.name}>{x.name}</option>)}
                    </Form.Select>
                    <Form.Control.Feedback type="invalid">
                        Select a category
                    </Form.Control.Feedback>
                </Form.Group>
            </Form>
            {items.length > 0 && <ItemList list={itemSearch} add={!show} shoppingList={category}/>}
            {items.length > 0 && <SearchBar search={name} setSearch={onSearch}></SearchBar>}
        </div>
    );
}