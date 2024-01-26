import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import {
  createBrowserRouter,
  RouterProvider
} from "react-router-dom";
import CreateOrder from './components/CreateOrder';
import Inventario from './components/Inventario';
import ViewOrders from './components/ViewOrders';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement: (<><h1>No existe la pagina</h1></>),

    children: [
      {
        path: "/crear-pedido",
        element: <CreateOrder />
      },
      {
        path: "/inventario",
        element: <Inventario />
      },
      {
        path: "/pedidos",
        element: <ViewOrders />
      }
    ],
  }
]);
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <RouterProvider router={router} />
);
