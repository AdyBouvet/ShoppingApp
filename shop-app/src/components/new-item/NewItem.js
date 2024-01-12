import { useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap"
import { CreateItem, GetItems } from "../../services/ItemService"
import { GetCategories } from "../../services/CategoryService"

export const NewItem = () => {

    const [name, setName] = useState("")
    const [category, setCategory] = useState("Default")
    const [description, setDescription] = useState("")
    const [loading, setLoading] = useState(false)
    const [items, setItems] = useState([]);
    const [categories, setCategories] = useState(["A", "B"]);

    const onNameInput = ({ target: { value } }) => setName(value)
    const onCategoryInput = ({ target: { value } }) => setCategory(value)
    const onDescriptionInput = ({ target: { value } }) => setDescription(value)

    const onFormSubmit = e => {
        if (category === "Default" || items.includes(name)) {
            console.log("failed")
            e.preventDefault()
        } else {
            const response = { "Name": name, "Category": category, "Description": description }
            CreateItem(response)
            e.preventDefault()
        }
    }

    function getData() {
        GetCategories().then(a => {
            setCategories(a)
        })
        GetItems().then(a => {
            setItems(a)
        })
    }

    useEffect(() => {
        getData()
    }, [])

    return (
        <div>
            {categories.length > 0 && <Form onSubmit={onFormSubmit}>
                <Form.Group className="mb-3" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control required isInvalid={items.includes(name)} type="text" placeholder="Enter name" value={name} onChange={onNameInput} />
                    <Form.Control.Feedback type="invalid">
                        Item exists
                    </Form.Control.Feedback>
                </Form.Group>

                <Form.Group className="mb-3" controlId="category">
                    <Form.Label>Category</Form.Label>
                    <Form.Select isInvalid={category === "Default"} aria-label="Default select example" value={category} onChange={onCategoryInput}>
                        {categories.map(x => <option key={x.name} value={x.name}>{x.name}</option>)}
                    </Form.Select>
                    <Form.Control.Feedback type="invalid">
                        Select a category
                    </Form.Control.Feedback>
                </Form.Group>
                <Form.Group className="mb-3" controlId="description">
                    <Form.Label>Description</Form.Label>
                    <Form.Control type="text" placeholder="Enter description" value={description} onChange={onDescriptionInput} />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>}
        </div>
    );
}