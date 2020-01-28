import React, { useContext } from "react";
import RegisterContainerContext from "../../RegisterContainer/RegisterContainerContext";

function BackgroundImage() {
  const { imageName } = useContext(RegisterContainerContext);
  const backgroundImagePath = require(`../../../img/${imageName}.jpg`);

  return (
    <>
      <img
        src={backgroundImagePath}
        alt="Background image"
        className="opacity-65 img-height"
      />
    </>
  );
}

export default BackgroundImage;
