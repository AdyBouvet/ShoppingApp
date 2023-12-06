import axios from "axios";

/**
 * Returns Item objects from API
 * 
 * @param {string} category Category to filter on
 * @returns Item objects
 */
export const GetCategoryOrders = () => 
    axios.get("https://localhost:7205/api/CategoryOrder").then(res => res.data);

export const GetCategoryOrder = (shopName, categoryName) => 
    axios.get("https://localhost:7205/api/CategoryOrder/" + shopName + "/" + categoryName).then(res => res.data);

export const CreateCategoryOrder = (categoryOrder) => 
    axios.post("https://localhost:7205/api/CategoryOrder", categoryOrder).then(res => res.data).catch(err => console.log(err));

export const DeleteCategoryOrder = (shopName, categoryName) =>
    axios.delete("https://localhost:7205/api/CategoryOrder?shopName=" + shopName + "&categoryName=" + categoryName)
