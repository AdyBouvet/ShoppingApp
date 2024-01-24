import { Button } from "react-bootstrap"
import { AddShoppingList, Buy } from "../../../services/ShoppingListService"
import { Numpad } from "../../numpad/Numpad"
import { useState } from "react"

export const Item = ({ item, shoppingList, remove = false, add = false }) => {

    const [numpad, setNumpad] = useState(false)
    const [name, setName] = useState("")
    const [render, rerender] = useState(false);

    const onAdd = (name) => {
        setName(name)
        setNumpad(true)
    }

    const buy = () => {
        Buy(item.name, shoppingList, !item.bought).then(res => { item.bought = !item.bought; rerender(!render) })
    }

    const onNumber = (num) => {
        setNumpad(false)
        AddShoppingList(name, shoppingList, num, "SomeDescription").then(res => console.log(res))
    }

    return (
        <div>
            {add && <Button onClick={() => onAdd(item.name)}>{item.name}</Button>}
            {add === false && 
                <Button variant={item.bought ? "danger" : "success"} onClick={() => buy()}>
                    <p style={{ textDecorationLine: item.bought ? 'line-through' : "none", textDecorationStyle: 'solid' }}>{item.amount} {item.name}</p>
                </Button>
            }
            {remove && <Button variant="danger">Delete</Button>}
            {numpad && <Numpad selected={onNumber}></Numpad>}
        </div>
    )
}