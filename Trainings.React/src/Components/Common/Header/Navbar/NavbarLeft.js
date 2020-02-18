import React from "react";
import NavLink from "./NavLink";

function NavbarLeft() {
  return (
    <>
      <NavLink content="Accueil" to="/login" classes="cursor-not-allowed" />
      <NavLink content="Vision" to="/login" classes="cursor-not-allowed" />
      <NavLink content="Générer" to="/login" classes="cursor-not-allowed" />
      <NavLink content="Profil" to="/login" classes="cursor-not-allowed" />
    </>
  );
}

export default NavbarLeft;
