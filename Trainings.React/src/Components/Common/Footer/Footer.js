import React from "react";
import Logo from "../Logo/Logo.js";
import FooterLink from "./FooterLink.js";
import FooterSocials from "./FooterSocials.js";
import "./Footer.css";

function Footer() {
  return (
    <footer>
      <div className="flex flex-col sm:flex-row items-center justify-around mt-32 font-light mb-16">
        <div className="flex w-9/12 flex-col justify-center sm:w-1/6">
          <span className="hidden sm:block">
            <Logo />
          </span>
          <p className="text-center mt-4 font-medium text-gray-500">
            © 2020 Trainings, Inc
          </p>
        </div>
        <div className="flex w-9/12 mt-6 sm:mt-0 sm:w-1/6 justify-around">
          <div className="flex flex-col">
            <FooterLink link="" content="Accueil" />
            <FooterLink link="" content="Notre vision" />
            <FooterLink link="" content="Vos données" />
          </div>
          <div className="flex flex-col">
            <FooterLink link="" content="Contact" />
            <FooterLink link="" content="Blog" />
          </div>
        </div>
        <div className="w-9/12 mt-10 sm:mt-0 sm:w-1/6">
          <FooterSocials />
        </div>
      </div>
    </footer>
  );
}

export default Footer;
