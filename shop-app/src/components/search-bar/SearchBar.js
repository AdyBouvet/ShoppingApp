import { useState } from "react";
import { Form } from "react-bootstrap"

export const SearchBar = ({ items, setEmpty }) => {

    const [input, setInput] = useState("")
    const onInputChange = ({ target: { value } }) => {
        setInput(value)
        setEmpty(!items.map(item => item.toLowerCase().includes(value.toLowerCase())).some(x => x === true))
    }

    return (
        <div>
            {items.map(item => item.toLowerCase().includes(input.toLowerCase()) && <p key={item}>{item}</p>)}
            <Form>
                <Form.Group className="mb-3" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control required type="text" placeholder="Enter name" value={input} onChange={onInputChange} />
                </Form.Group>
            </Form>
        </div>
    );
}
