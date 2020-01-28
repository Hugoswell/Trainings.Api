import React from "react";
import RegisterFormMobile from "./RegisterForm/RegisterFormMobile/RegisterFormMobile";
import BackgroundImageAndForm from "../Common/BackgroundImageAndForm/BackgroundImageAndForm";
import RegisterContainerContext from "./RegisterContainerContext";

function RegisterContainer() {
  const contextValue = {
    headline: "Des entrainements adaptés à votre demande et besoin.",
    imageName: "musculation-HF"
  };

  return (
    <>
      <RegisterContainerContext.Provider value={contextValue}>
        <BackgroundImageAndForm />
      </RegisterContainerContext.Provider>
      <RegisterFormMobile />
    </>
  );
}

export default RegisterContainer;
