import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import {
  createBrowserRouter,
  RouterProvider
} from "react-router-dom";
import Pedidos from './components/Pedidos';
import Inventario from './components/Inventario';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement: (<><h1>No existe la pagina</h1></>),

    children: [
      {
        path: "/pedidos",
        element: <Pedidos />
      },
      {
        path: "/inventario",
        element: <Inventario />
      }
    ],
  }
]);
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <RouterProvider router={router} />
);
