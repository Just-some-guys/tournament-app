import React from "react";
import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import { Link, NavLink } from "react-router-dom";
import "./DropDownMenu.css" 
function DropDownMenu(props) {
  const [anchorEl, setAnchorEl] = React.useState(null);

  function handleClick(event) {
    if (anchorEl !== event.currentTarget) {
      setAnchorEl(event.currentTarget);
    }
  }

  function handleClose() {
    setAnchorEl(null);
  }


  return (
    <div>
      <Button
        aria-owns={anchorEl ? "simple-menu" : undefined}
        aria-haspopup="true"
        onClick={handleClick}
        onMouseOver={handleClick}
        style={{
            fontSize: "20px",
            color: "white",
            borderBottom: "3px #ADADAD solid",
            textDecoration: "none",
          }}
      >
        Моё
      </Button>
      <Menu         

        id="simple-menu"
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleClose}
        MenuListProps={{ onMouseLeave: handleClose }}
      >
        {props.links.map((link) =>             
         <NavLink             
            key={link.title}
            variant="button"
            to={link.path}
            className={({ isActive }) => (isActive ? 'activeNavLink' : '')}
            style={{ 
              fontSize: "20px",
              color: "black",
              borderBottom: "3px #ADADAD solid",
              textDecoration: "none",
            }}
          >
            {link.title}
          </NavLink>
            
            )}
      </Menu>
    </div>
  );
}

export default DropDownMenu;