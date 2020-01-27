import React from "react";
import LogoImg from "../../../img/logo.svg";

function Logo() {
  return (
    <img
      src={LogoImg}
      alt="Trainings logo"
      className="h-14 sm:mx-8 sm:h-16 -mt-2"
    />
  );
}

export default Logo;
