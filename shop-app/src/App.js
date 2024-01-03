import './App.css';
import { ItemList } from './components/item-list/ItemList';
import { ShoppingList } from './components/shopping-list/ShoppingList';
import { NewItem } from './pages/new-item/NewItem';
import { GetCategoryOrder, GetCategoryOrders, CreateCategoryOrder, DeleteCategoryOrder } from './services/CategoryOrderService';

function App() {

  const item = [
    { "Name": "ItemName", "Category" : "Category", "Description": "A longer description that can take some space"},
    { "Name": "ItemName2", "Category2" : "Category", "Description": "A longer description that can take some space2"},
  ]

  const shoppingList = {
    "Name" : "Shopping list 1",
    "Items" : item
  }


  return (
    <div className="App">
      <ItemList list={item}/>
      <ShoppingList list={shoppingList} />
      <NewItem/>
      <button onClick={() => GetCategoryOrders().then(a => console.log(a))}>All</button>
      <button onClick={() => GetCategoryOrder("Fjøsanger", "Category2").then(a => console.log(a))}>One</button>
      <button onClick={() => CreateCategoryOrder({"category": "Category2", "shop" : "Fjøsanger", "order": 1}).then(a => console.log(a))}>Create</button>
      <button onClick={() => DeleteCategoryOrder("Fjøsanger", "Category2").then(a => console.log(a))}>Delete</button>
    </div>
  );
}

export default App;
