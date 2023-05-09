import TournamentPage from "../pages/TournamentPage";
import HomePage from "../pages/HomePage";
import OrganizationPage from "../pages/OrganizationPage";
import { Outlet } from "react-router-dom";
import UserOrganizationsPage from "../pages/UserOrganizationsPage";
import OrganizationUpsertPage from "../pages/OrganizationUpsertPage";

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
    children: [{
      path: "/userOrganizations/:userId",
      element: <Outlet />,
      state: "installation",
      title: "Мои организации",
    },
    {
      path: "/userTournaments/:userId",
      element: <Outlet />,
      state: "installation",
      title: "Мои турниры",
    },
    {
      path: "/userTeams/:userId",
      element: <Outlet />,
      state: "installation",
      title: "Мои команды",
    },  ]
  },
  
  {
    path: "/organization/:id",
    element: <OrganizationPage />,
    state: "installation",
    title: "Организация",
  },
  {
    path: "/organization/edit/:id",
    element: <OrganizationUpsertPage />,
    state: "installation",
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
