import axios from "axios";


const url = "https://hashoppinglist.azurewebsites.net/api/"
/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetItems = (category) => 
    axios.get(url + "Item").then(res => res.data);

export const GetItem = (name) => 
    axios.get(url + "Item/" + name).then(res => res.data);

export const CreateItem = (item) => 
    axios.post(url + "Item", item).then(res => res.data);

export const DeleteItem = (name) =>
    axios.delete(url + "Item?name=" + name)
