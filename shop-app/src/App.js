import './App.css';
import { GetCategoryOrder, GetCategoryOrders, CreateCategoryOrder, DeleteCategoryOrder } from './services/CategoryOrderService';

function App() {

  return (
    <div className="App">
      <button onClick={() => GetCategoryOrders().then(a => console.log(a))}>All</button>
      <button onClick={() => GetCategoryOrder("Fjøsanger", "Category2").then(a => console.log(a))}>One</button>
      <button onClick={() => CreateCategoryOrder({"category": "Category2", "shop" : "Fjøsanger", "order": 1}).then(a => console.log(a))}>Create</button>
      <button onClick={() => DeleteCategoryOrder("Fjøsanger", "Category2").then(a => console.log(a))}>Delete</button>
    </div>
  );
}

export default App;
