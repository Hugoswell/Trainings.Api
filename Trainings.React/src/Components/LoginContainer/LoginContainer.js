import React from "react";
import RegisterContainerContext from "../RegisterContainer/RegisterContainerContext";
import BackgroundImageAndForm from "../Common/BackgroundImageAndForm/BackgroundImageAndForm";

function LoginContainer() {
  const contextValue = {
    headline:
      "Il faut toujours viser la lune, car même en cas d'échec, on atterrit dans les étoiles.",
    imageName: "cardio-HF"
  };

  return (
    <>
      <RegisterContainerContext.Provider value={contextValue}>
        <BackgroundImageAndForm />
      </RegisterContainerContext.Provider>
    </>
  );
}

export default LoginContainer;
