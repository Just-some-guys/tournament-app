import DashboardPageLayout from "../pages/dashboard/DashboardPageLayout";
import HomePage from "../pages/home/HomePage";
import HomeIcon from "@mui/icons-material/Home";
import EventIcon from "@mui/icons-material/Event";
import BuildIcon from "@mui/icons-material/Build";

const appRoutes = [
  {
    index: true,
    element: <HomePage />,
    state: "home",
  },
  {
    path: "/",
    element: <DashboardPageLayout />,
    state: "home",
    sidebarProps: {
      displayText: "Home",
      icon: <HomeIcon />,
    },
  },
  {
    path: "/joined-tournaments",
    element: <DashboardPageLayout />,
    state: "installation",
    sidebarProps: {
      displayText: "Joined tournaments",
      icon: <EventIcon />,
    },
  },
  {
    path: "/organize-tournaments",
    element: <DashboardPageLayout />,
    state: "installation",
    sidebarProps: {
      displayText: "Organize tournaments",
      icon: <BuildIcon />,
    },
  },
];

export default appRoutes;
