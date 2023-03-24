import { Outlet } from "react-router-dom";
import { Box, Toolbar } from "@mui/material";
import colorConfigs from "../../configs/colorConfigs";
import sizeConfigs from "../../configs/sizeConfigs";
import Topbar from "../common/Topbar";

const MainLayout = () => {
  return (
    <Box sx={{background: colorConfigs.mainBg}}>
      <Topbar />
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          color: colorConfigs.mainFontColor,
          marginLeft: "10rem",
          marginRight: "10rem",
          minHeight: "100vh",
        }}
      >
        <Outlet />
      </Box>
    </Box>
  );
};

export default MainLayout;