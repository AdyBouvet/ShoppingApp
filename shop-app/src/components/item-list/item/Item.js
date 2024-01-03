export const Item = ({ item }) => {
    return(
        <div>
            <p>{item.Name}</p>
            <p>{item.Category}</p>
            <p>{item.Description}</p>
        </div>
    )
}