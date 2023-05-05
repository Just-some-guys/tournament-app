import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import AdbIcon from "@mui/icons-material/Adb";
import NotificationsNoneIcon from "@mui/icons-material/NotificationsNone";
import PortraitIcon from "@mui/icons-material/Portrait";
import routes from "../../routes/appRoutes";
import { Link, NavLink } from "react-router-dom";

const pages = routes;

function Topbar() {
  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };
  const [lang, setLang] = React.useState("");

  const handleChange = (event) => {
    setLang(event.target.value);
  };

  return (
    <AppBar position="sticky">
      <Toolbar
        disableGutters
        sx={{ backgroundColor: "#1E1E1E", justifyContent: "space-between" }}
      >
        <Box sx={{ display: { md: "flex" }, alignItems: "center" }}>
          <AdbIcon sx={{ display: { md: "flex" }, mr: 1, ml: 1 }} />
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { md: "flex" },
              fontSize: "30px",
              fontWeight: 700,
              color: "inherit",
              textDecoration: "none",
            }}
          >
            Tournament App
          </Typography>
        </Box>
        <Box sx={{ ml: "3rem", gap: "3rem", display: { md: "flex" } }}>
          {pages.map((page) => (
            <NavLink            
              key={page.title}
              variant="button"
              to={page.path}
              className={({ isActive }) => (isActive ? 'activeNavLink' : '')}
              style={{
                fontSize: "20px",
                color: "white",
                borderBottom: "3px #ADADAD solid",
                textDecoration: "none",
              }}
            >
              {page.title}
            </NavLink>
          ))}
        </Box>
        <Box
          sx={{
            ml: "3rem",
            gap: "3rem",
            alignItems: "center",
            display: { md: "flex" },
          }}
        >
          <NotificationsNoneIcon fontSize="large" />
          <Box sx={{ display: { md: "flex" }, alignItems: "center" }}>
            <PortraitIcon fontSize="large" />
            <Typography
              noWrap
              component="a"
              href="/"
              sx={{
                mr: 2,
                display: { md: "flex" },
                fontSize: "20px",
                fontWeight: 700,
                color: "inherit",
                textDecoration: "none",
              }}
            >
              AccountName
            </Typography>
          </Box>
          <Select
            sx={{
              color: "white",
              ".MuiOutlinedInput-notchedOutline": {
                borderColor: "rgba(228, 219, 233, 0.25)",
              },
              "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
                borderColor: "rgba(228, 219, 233, 0.25)",
              },
              "&:hover .MuiOutlinedInput-notchedOutline": {
                borderColor: "rgba(228, 219, 233, 0.25)",
              },
              ".MuiSvgIcon-root ": {
                fill: "white !important",
              },
              mr: 1,
            }}
            value={lang}
            onChange={handleChange}
          >
            <MenuItem value={"RU"}>RU</MenuItem>
            <MenuItem value={"ENG"}>ENG</MenuItem>
          </Select>
        </Box>
      </Toolbar>
    </AppBar>
  );
}
export default Topbar;
