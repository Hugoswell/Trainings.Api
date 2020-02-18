import React, { useContext } from "react";
import BackgroundImageAndFormContext from "../BackgroundImageAndForm/BackgroundImageAndFormContext";

function BackgroundImage() {
  const { imageName } = useContext(BackgroundImageAndFormContext);
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
