import { useState } from "react";
import { SearchBar } from "../../components/search-bar/SearchBar";
import { NewItem } from "../../components/new-item/NewItem";


export const NewItemPage = () => {

    const [empty, setEmpty] = useState(false)

    return (
        <div>
            <NewItem/>
            {/*<SearchBar items={items} setEmpty={setEmpty}/>*/}
        </div>
    );
}