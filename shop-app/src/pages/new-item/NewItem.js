import { useState } from "react";
import { Button, Form } from "react-bootstrap"

export const NewItem = () => {

    const [name, setName] = useState("")
    const [category, setCategory] = useState("")
    const [description, setDescription] = useState("")

    const onNameInput = ({ target: { value } }) => setName(value)
    const onCategoryInput = ({ target: { value } }) => setCategory(value)
    const onDescriptionInput = ({ target: { value } }) => setDescription(value)
    
    const onFormSubmit = e => {
        e.preventDefault()
        const response = { "Name": name, "Category": category, "Description": description }
        console.log(response)
    }

    return (
        <Form noValidate onSubmit={onFormSubmit}>
            <Form.Group className="mb-3" controlId="name">
                <Form.Label>Name</Form.Label>
                <Form.Control required type="text" placeholder="Enter name" value={name} onChange={onNameInput} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="category">
                <Form.Label>Category</Form.Label>
                <Form.Select aria-label="Default select example" value={category} onChange={onCategoryInput}>
                    <option disabled>Open this select menu</option>
                    <option value="Category1">Category1</option>
                    <option value="Category2">Category2</option>
                    <option value="Category3">Category3</option>
                </Form.Select>
            </Form.Group>
            <Form.Group className="mb-3" controlId="description">
                <Form.Label>Description</Form.Label>
                <Form.Control type="text" placeholder="Enter description" value={description} onChange={onDescriptionInput} />
            </Form.Group>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>
    );
}