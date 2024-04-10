import { Button } from "react-bootstrap"
import { AddShoppingList, Buy, RemoveShoppingList } from "../../../services/ShoppingListService"
import { Numpad } from "../../numpad/Numpad"
import { useState } from "react"

export const Item = ({ item, shoppingList, mode, rerender }) => {

    const [numpad, setNumpad] = useState(false)
    const [name, setName] = useState("")

    const onAdd = (name) => {
        setName(name)
        setNumpad(true)
    }

    const onRemove = (name) => {
        RemoveShoppingList(name, shoppingList).then(() => rerender())
    }

    const buy = () => {
        Buy(item.name, shoppingList, !item.bought).then(res => { item.bought = !item.bought; rerender() })
    }

    const onNumber = (num) => {
        setNumpad(false)
        AddShoppingList(name, shoppingList, num, "SomeDescription").then(res => console.log(res))
    }

    return (
        <div>
            {mode === "add" && <Button onClick={() => onAdd(item.name)}>{item.name}</Button>}
            {mode === "show" && 
                <Button variant={item.bought ? "danger" : "success"} onClick={() => buy()}>
                    <p style={{ textDecorationLine: item.bought ? 'line-through' : "none", textDecorationStyle: 'solid' }}>{item.amount} {item.name}</p>
                </Button>
            }
            {mode === "remove" && <Button variant="danger" onClick={() => onRemove(item.name)}>{item.name}</Button>}
            {numpad && <Numpad selected={onNumber}></Numpad>}
        </div>
    )
}