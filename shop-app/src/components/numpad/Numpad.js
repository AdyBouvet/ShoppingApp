import { Button } from "react-bootstrap"

export const Numpad = ({ selected }) => {

    const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9]

    return (
        <div>
            {numbers.map(x => <Button  onClick={() => selected(x)}>{x}</Button>)}
        </div>
    )
}