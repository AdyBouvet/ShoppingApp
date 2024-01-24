import { useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap"
import { GetShoppingLists, CreateShoppingList } from "../../services/ShoppingListService"

export const NewShoppingList = () => {

    const [name, setName] = useState("")
    const [shoppingLists, setShoppingLists] = useState(["A", "B"]);
    const [success, setSuccess] = useState("Default")

    const onNameInput = ({ target: { value } }) => setName(value)

    const onFormSubmit = e => {
        const response = { "Name": name }
        CreateShoppingList(response).then(data => {
            setName("")
            setSuccess(data)
        }).catch(err => {
            setSuccess(err.response.data)
        })
        e.preventDefault()
    }

    function getData() {
        GetShoppingLists().then(a => {
            setShoppingLists(a)
        })
    }

    useEffect(() => {
        getData()
    }, [])

    return (
        <div>
            <h1>Add new shopping list</h1>
            <Form onSubmit={onFormSubmit}>
                <Form.Group className="mb-3" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control required isInvalid={shoppingLists.some(i => i.name === name) || name < 1 } type="text" placeholder="Enter name" value={name} onChange={onNameInput} />
                    <Form.Control.Feedback type="invalid">
                        ShoppingList exists
                    </Form.Control.Feedback>
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
            {success !== "Default" && <p>{success}</p>}
        </div>
    );
}