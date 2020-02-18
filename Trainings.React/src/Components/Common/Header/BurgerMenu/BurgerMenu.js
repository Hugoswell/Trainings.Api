import React from "react";
import "./BurgerMenu.css";

function BurgerMenu() {
  return (
    <button className="burger-menu flex flex-col justify-center absolute h-8 sm:hidden">
      <span className="block w-8 rounded-lg"></span>
      <span className="block w-8 rounded-lg"></span>
      <span className="block w-8 rounded-lg"></span>
    </button>
  );
}

export default BurgerMenu;
