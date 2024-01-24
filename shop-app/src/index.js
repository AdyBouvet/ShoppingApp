import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.min.css';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import { NewItemPage } from './pages/new-item/NewItemPage';
import { ShoppinglistPage } from './pages/shoppinglist-page/ShoppinglistPage';
import { NewCategory } from './components/new-category/NewCategory';
import { FrontPage } from './pages/front-page/FrontPage';
import { NewShoppingList } from './pages/new-shopping-list/NewShoppingList';

const router = createBrowserRouter([
  {
    path: "/",
    element: <FrontPage/>
  },
  {
    path: "new-item",
    element: <NewItemPage/>
  },
  {
    path: "add-item",
    element: <ShoppinglistPage/>
  },
  {
    path: "new-category",
    element: <NewCategory/>
  },
  {
    path: "new-shopping-list",
    element: <NewShoppingList/>
  }
]);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
    <RouterProvider router={router} />
  </React.StrictMode>
  
);

<link
  rel="stylesheet"
  href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"
  integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM"
  crossorigin="anonymous"
/>

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
