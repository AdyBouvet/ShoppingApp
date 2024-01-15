export const Item = ({ item }) => {
    return(
        <div>
            <p>{item.name}</p>
            <p>{item.category}</p>
            <p>{item.description}</p>
        </div>
    )
}