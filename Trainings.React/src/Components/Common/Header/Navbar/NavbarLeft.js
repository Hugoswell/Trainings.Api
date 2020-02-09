import React from "react";
import NavLink from "./NavLink";

function NavbarLeft() {
  return (
    <>
      <NavLink content="Accueil" link="#" classes="cursor-not-allowed" />
      <NavLink content="Vision" link="#" classes="cursor-not-allowed" />
      <NavLink content="Générer" link="#" classes="cursor-not-allowed" />
      <NavLink content="Profil" link="#" classes="cursor-not-allowed" />
    </>
  );
}

export default NavbarLeft;
