import axios from "axios";

const url = "https://hashoppinglist.azurewebsites.net/api/"

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetShoppingLists = () => 
    axios.get(url + "ShoppingList").then(res => res.data);

export const GetShoppingList = (name) => 
    axios.get(url + "ShoppingList/" + name).then(res => res.data);

export const CreateShoppingList = (list) => 
    axios.post(url + "ShoppingList", list).then(res => res.data);

export const DeleteShoppingList = (name) =>
    axios.delete(url +"ShoppingList?name=" + name)

export const AddShoppingList = (itemName, listName, amount, comment) =>
    axios.post(url + "ShoppingList/add?itemName=" + itemName + "&listName=" + listName +"&amount=" + amount + "&comment=" + comment)

export const RemoveShoppingList = (itemName, listName) =>
    axios.delete(url + "ShoppingList/remove?itemName=" + itemName + "&listName=" + listName)