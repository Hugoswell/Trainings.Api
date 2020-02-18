import React from "react";
import Header from "../Components/Common/Header/Header.js";
import RegisterContainer from "../Components/RegisterContainer/RegisterContainer.js";
import Footer from "../Components/Common/Footer/Footer.js";
import "../css/index.css";
import HeaderContext from "../Components/Common/Header/HeaderContext";

function Register() {
  const contextValue = {
    NavbarRightContent: "Me connecter",
    NavbarRightLink: "/login"
  };

  return (
    <>
      <HeaderContext.Provider value={contextValue}>
        <Header />
      </HeaderContext.Provider>
      <RegisterContainer />
      <Footer />
    </>
  );
}

export default Register;
