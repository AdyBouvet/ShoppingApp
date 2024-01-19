import { Button } from "react-bootstrap"
import { AddShoppingList } from "../../../services/ShoppingListService"
import { Numpad } from "../../numpad/Numpad"
import { useState } from "react"

export const Item = ({ item, shoppingList, remove = false, add = false }) => {

    const [numpad, setNumpad] = useState(false)
    const [name, setName] = useState("")

    const onAdd = (name) => {
        setName(name)
        setNumpad(true)
    }

    const onNumber = (num) => {
        setNumpad(false)
        AddShoppingList(name, shoppingList, num, "SomeDescription").then(res => console.log(res))
    }

    return (
        <div>
            {add && <Button onClick={() => onAdd(item.name)}>{item.name}</Button>}
            {add === false && <div>
                <p>{item.name}: {item.amount}</p>
            </div>}
            {remove && <Button variant="danger">Delete</Button>}
            {numpad && <Numpad selected={onNumber}></Numpad>}
        </div>
    )
}