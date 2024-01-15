import axios from "axios";

const url = "https://hashoppinglist.azurewebsites.net/api/"

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetCategories = () => 
    axios.get(url + "Category").then(res => res.data);

export const GetCategory = (name) => 
    axios.get(url +"Category/" + name).then(res => res.data);

export const CreateCategory = (category) => 
    axios.post(url + "Category", category).then(res => res.data);

export const DeleteCategory = (name) =>
    axios.delete(url + "Category?name=" + name)
