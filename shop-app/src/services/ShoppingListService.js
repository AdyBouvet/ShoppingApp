import axios from "axios";

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetShoppingLists = () => 
    axios.get("https://localhost:7205/api/ShoppingList").then(res => res.data);

export const GetShoppingList = (name) => 
    axios.get("https://localhost:7205/api/ShoppingList/" + name).then(res => res.data);

export const CreateShoppingList = (list) => 
    axios.post("https://localhost:7205/api/ShoppingList", list).then(res => res.data).catch(err => console.log(err));

export const DeleteShoppingList = (name) =>
    axios.delete("https://localhost:7205/api/ShoppingList?name=" + name)

export const AddShoppingList = (itemName, listName, amount, comment) =>
    axios.post("https://localhost:7205/api/ShoppingList/add?itemName=" + itemName + "&listName=" + listName +"&amount=" + amount + "&comment=" + comment)

export const RemoveShoppingList = (itemName, listName) =>
    axios.delete("https://localhost:7205/api/ShoppingList/remove?itemName=" + itemName + "&listName=" + listName)