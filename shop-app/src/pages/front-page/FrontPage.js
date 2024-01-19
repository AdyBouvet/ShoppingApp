import { Link } from "react-router-dom"

export const FrontPage = () => {
    return(
        <div>
            <Link to={"add-item"}>Add item</Link>
            <Link to={"new-item"}>New item</Link>
            <Link to={"new-category"}>New category</Link>
        </div>
    )
}