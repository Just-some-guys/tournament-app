import TournamentPage from "../pages/TournamentPage";
import HomePage from "../pages/HomePage";
import { Outlet } from "react-router-dom";

const routes = [
  {
    index: true,
    element: <HomePage />,
    state: "home",
    title: "Турниры",
    path: "/",
  },
  {
    path: "/organize-tournaments",
    element: <Outlet />,
    state: "installation",
    title: "Организовать турнир",
  },
  {
    path: "/joined-tournaments",
    element: <Outlet />,
    state: "installation",
    title: "Моё",
  },
  {
    path: "/tournament/:id",
    element: <TournamentPage />,
    state: "installation",    
  },
];

export default routes;
