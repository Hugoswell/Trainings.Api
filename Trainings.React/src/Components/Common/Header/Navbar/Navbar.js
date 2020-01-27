import React from "react";
import NavbarLeft from "./NavbarLeft";
import NavbarRight from "./NavbarRight";

function Navbar() {
  return (
    <nav className="hidden sm:flex h-16 items-center w-full lg:ml-12">
      <div className="w-9/12 h-full">
        <ul className="flex h-full items-center">
          <NavbarLeft />
        </ul>
      </div>
      <div className="w-3/12 h-full">
        <ul className="flex h-full items-center">
          <NavbarRight />
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
