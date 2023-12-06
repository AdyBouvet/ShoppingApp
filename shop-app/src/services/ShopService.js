import axios from "axios";

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetShops = () => 
    axios.get("https://localhost:7205/api/Shop").then(res => res.data);

export const GetShop = (name) => 
    axios.get("https://localhost:7205/api/Shop/" + name).then(res => res.data);

export const CreateShop = (shop) => 
    axios.post("https://localhost:7205/api/Shop", shop).then(res => res.data).catch(err => console.log(err));

export const DeleteShop = (name) =>
    axios.delete("https://localhost:7205/api/Shop?name=" + name)