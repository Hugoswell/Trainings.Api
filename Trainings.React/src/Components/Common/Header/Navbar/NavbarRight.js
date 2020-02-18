import React, { useContext } from "react";
import NavLink from "./NavLink";
import HeaderContext from "../HeaderContext";

function NavbarRight() {
  const { NavbarRightContent, NavbarRightLink } = useContext(HeaderContext);
  return <NavLink to={NavbarRightLink} content={NavbarRightContent} />;
}

export default NavbarRight;
