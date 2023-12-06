import axios from "axios";

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetCategories = () => 
    axios.get("https://localhost:7205/api/Category").then(res => res.data);

export const GetCategory = (name) => 
    axios.get("https://localhost:7205/api/Category/" + name).then(res => res.data);

export const CreateCategory = (category) => 
    axios.post("https://localhost:7205/api/Category", category).then(res => res.data).catch(err => console.log(err));

export const DeleteCategory = (name) =>
    axios.delete("https://localhost:7205/api/Category?name=" + name)
