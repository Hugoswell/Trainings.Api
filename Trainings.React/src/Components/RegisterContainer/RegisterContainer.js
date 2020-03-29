import React from "react";
import RegisterFormMobile from "./RegisterForm/RegisterFormMobile/RegisterFormMobile";
import BackgroundImageAndForm from "../Common/BackgroundImageAndForm/BackgroundImageAndForm";
import BackgroundImageAndFormContext from "../Common/BackgroundImageAndForm/BackgroundImageAndFormContext";

function RegisterContainer() {
  const contextValue = {
    headline: "Des entrainements adaptés à votre demande et besoin.",
    imageName: "musculation-HF",
    form: "register"
  };

  return (
    <>
      <BackgroundImageAndFormContext.Provider value={contextValue}>
        <BackgroundImageAndForm />
      </BackgroundImageAndFormContext.Provider>
      <RegisterFormMobile />
    </>
  );
}

export default RegisterContainer;
