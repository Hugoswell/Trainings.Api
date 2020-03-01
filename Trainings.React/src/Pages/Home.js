import React from "react";
import Header from "../Components/Common/Header/Header.js";
import Footer from "../Components/Common/Footer/Footer.js";
import HeaderContext from "../Components/Common/Header/HeaderContext";

function Home() {
  const contextValue = {
    NavbarRightContent: "M'inscrire",
    NavbarRightLink: "/register"
  };

  return (
    <>
      <HeaderContext.Provider value={contextValue}>
        <Header />
      </HeaderContext.Provider>
      <Footer />
    </>
  );
}

export default Home;
