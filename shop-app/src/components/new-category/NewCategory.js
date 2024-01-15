import { useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap"
import { GetCategories, CreateCategory } from "../../services/CategoryService"

export const NewCategory = () => {

    const [name, setName] = useState("")
    const [categories, setCategories] = useState(["A", "B"]);
    const [success, setSuccess] = useState("Default")

    const onNameInput = ({ target: { value } }) => setName(value)

    const onFormSubmit = e => {
        const response = { "Name": name }
        CreateCategory(response).then(data => {
            setName("")
            setSuccess(data)
        }).catch(err => {
            setSuccess(err.response.data)
        })
        e.preventDefault()
    }

    function getData() {
        GetCategories().then(a => {
            setCategories(a)
        })
    }

    useEffect(() => {
        getData()
    }, [])

    return (
        <div>
            <h1>Add new category</h1>
            <Form onSubmit={onFormSubmit}>
                <Form.Group className="mb-3" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control required isInvalid={categories.some(i => i.name === name) || name < 1 } type="text" placeholder="Enter name" value={name} onChange={onNameInput} />
                    <Form.Control.Feedback type="invalid">
                        Category exists
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