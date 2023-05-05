import TournamentPage from "../pages/TournamentPage";
import HomePage from "../pages/HomePage";
import OrganizationPage from "../pages/OrganizationPage";
import { Outlet } from "react-router-dom";
import UserOrganizationsPage from "../pages/UserOrganizationsPage";

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
    path: "/organization/:id",
    element: <OrganizationPage />,
    state: "installation",
    title: "Организация",
  },
  {
    path: "/userOrganizations/:userId",
    element: <UserOrganizationsPage />,
    state: "installation",
    title: "Организации пользователя",
  },
  {
    path: "/tournament/:id",
    element: <TournamentPage />,
    state: "installation",    
  },
];

export default routes;
