import React from "react";
import "./RegisterForm.css";
import Cta from "../../../Common/Cta/Cta.js";
import FormControl from "../../../Common/FormControl/FormControl.js";

function RegisterForm() {
  return (
    <div className="hidden sm:block w-2/5 bg-white rounded opacity-85 p-12 box-shadow">
      <div className="flex justify-between">
        <div className="w-45">
          <FormControl
            inputId="firstname"
            labelValue="Prénom"
            inputType="text"
            placeholderValue="Prénom"
          />
        </div>
        <div className="w-45">
          <FormControl
            inputId="lastname"
            labelValue="Nom"
            inputType="text"
            placeholderValue="Nom"
            className="w-1/2"
          />
        </div>
      </div>

      <div className="mt-5">
        <FormControl
          inputId="email"
          labelValue="Email"
          inputType="email"
          placeholderValue="Email"
        />
      </div>

      <div className="mt-5">
        <FormControl
          inputId="password"
          labelValue="Mot de passe"
          inputType="password"
          placeholderValue="Mot de passe"
        />
        <div className="mt-4">
          <label
            htmlFor="password"
            className="w-10/12 text-lg text-orange-600 monserrat-light-italic"
          >
            Rendez le aussi long et fou que vous souhaitez
          </label>
        </div>
      </div>

      <Cta />
    </div>
  );
}

export default RegisterForm;
