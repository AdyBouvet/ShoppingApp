import './App.css';
import { NewCategory } from './components/new-category/NewCategory';
import { NewItemPage } from './pages/new-item/NewItemPage';

function App() {

  return (
    <div className="App">
      <NewItemPage/>
      <br/>
      <br/>
      <br/>
      <NewCategory/>
    </div>
  );
}

export default App;
