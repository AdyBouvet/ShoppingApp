import { useState } from "react";
import { Form } from "react-bootstrap"
import { Item } from "../item-list/item/Item"

export const SearchBar = ({ search, setSearch }) => {

    const onInputChange = ({ target: { value } }) => {
        setSearch(value)
    }

    return (
        <div>
            <Form>
                <Form.Group className="mb-3" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control required type="text" placeholder="Enter name" value={search} onChange={onInputChange} />
                </Form.Group>
            </Form>
        </div>
    );
}
