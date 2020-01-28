import React from "react";
import BackgroundImageAndFormContext from "../Common/BackgroundImageAndForm/BackgroundImageAndFormContext";
import BackgroundImageAndForm from "../Common/BackgroundImageAndForm/BackgroundImageAndForm";

function LoginContainer() {
  const contextValue = {
    headline:
      "Il faut toujours viser la lune, car même en cas d'échec, on atterrit dans les étoiles.",
    imageName: "cardio-HF"
  };

  return (
    <>
      <BackgroundImageAndFormContext.Provider value={contextValue}>
        <BackgroundImageAndForm />
      </BackgroundImageAndFormContext.Provider>
    </>
  );
}

export default LoginContainer;
