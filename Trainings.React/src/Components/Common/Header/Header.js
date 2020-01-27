import React from "react";
import Logo from "../Logo/Logo.js";
import BurgerMenu from "./BurgerMenu/BurgerMenu.js";
import Navbar from "./Navbar/Navbar.js";

function Header() {
  return (
    <header className="fixed w-screen flex justify-center items-center h-16 z-10 bg-white top-0">
      <Logo />
      <Navbar />
      <BurgerMenu />
    </header>
  );
}

export default Header;
