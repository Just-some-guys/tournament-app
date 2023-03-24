import HomePage from "../pages/home/HomePage";
import { Outlet } from "react-router-dom";

const routes = [
  {
    index: true,
    element: <HomePage />,
    state: "home",
    title: "Турниры",
    path: "/"
  },  
  {
    path: "/organize-tournaments",
    element: <Outlet />,
    state: "installation",
    title: "Организовать турнир"
  },
  {
    path: "/joined-tournaments",
    element: <Outlet />,
    state: "installation",
    title: "Моё"
  }
];

export default routes;
