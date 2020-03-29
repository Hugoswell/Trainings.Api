import React from "react";
import Header from "../Components/Common/Header/Header.js";
import Footer from "../Components/Common/Footer/Footer.js";
import LoginContainer from "../Components/LoginContainer/LoginContainer";
import HeaderContext from "../Components/Common/Header/HeaderContext";

function Login() {
  const contextValue = {
    NavbarRightContent: "M'inscrire",
    NavbarRightLink: "/register"
  };

  return (
    <>
      <HeaderContext.Provider value={contextValue}>
        <Header />
      </HeaderContext.Provider>
      <LoginContainer />
      <Footer />
    </>
  );
}

export default Login;
