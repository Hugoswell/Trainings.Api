import React from "react";
import Cta from "../../../Common/Cta/Cta.js";
import FormControl from "../../../Common/FormControl/FormControl.js";

function RegisterFormMobile() {
  return (
    <div className="flex flex-col items-center mt-6 sm:hidden">
      <FormControl
        width="w-4/5"
        mt="mt-5"
        inputId="firstname"
        labelValue="Prénom"
        inputType="text"
        placeholderValue="Prénom"
      />
      <FormControl
        width="w-4/5"
        mt="mt-5"
        inputId="lastname"
        labelValue="Nom"
        inputType="text"
        placeholderValue="Nom"
      />
      <FormControl
        width="w-4/5"
        mt="mt-5"
        inputId="email"
        labelValue="Email"
        inputType="email"
        placeholderValue="Email"
      />

      <div className="flex flex-col w-4/5 mt-5">
        <label
          className="hidden sm:block text-orange-600 uppercase monserrat-semibold text-lg"
          htmlFor="password"
        >
          Mot de passe
        </label>
        <input
          id="password"
          type="password"
          placeholder="Mot de passe"
          className="w-full mt-1 pl-4 form-input"
        />
        <label
          htmlFor="password"
          className="w-full ml-1 mt-4 text-sm text-orange-600 monserrat-light-italic"
        >
          Rendez le aussi long et fou que vous souhaitez
        </label>
      </div>

      <Cta />
    </div>
  );
}

export default RegisterFormMobile;
