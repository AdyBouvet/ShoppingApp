import axios from "axios";

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetItems = (category) => 
    axios.get("https://localhost:7205/api/Item").then(res => res.data);

export const GetItem = (name) => 
    axios.get("https://localhost:7205/api/Item/" + name).then(res => res.data);

export const CreateItem = (item) => 
    axios.post("https://localhost:7205/api/Item", item).then(res => res.data).catch(err => console.log(err));

export const DeleteItem = (name) =>
    axios.delete("https://localhost:7205/api/Item?name=" + name)
