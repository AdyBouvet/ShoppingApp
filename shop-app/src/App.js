import './App.css';
import { NewCategory } from './components/new-category/NewCategory';
import { NewItemPage } from './pages/new-item/NewItemPage';
import { ShoppinglistPage } from './pages/shoppinglist-page/ShoppinglistPage';

function App() {

  return (
    <div className="App">
      <ShoppinglistPage/>
      <br/>
      <br/>
      <br/>
      {/*<NewItemPage/>
      <br/>
      <br/>
      <br/>
      <NewCategory/>*/}
    </div>
  );
}

export default App;
