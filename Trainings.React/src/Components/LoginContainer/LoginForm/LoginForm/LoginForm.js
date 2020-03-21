import React from "react";
import Cta from "../../../Common/Cta/Cta.js";
import FormControl from "../../../Common/FormControl/FormControl.js";

function LoginForm() {
  return (
    <div className="hidden sm:block w-2/5 bg-white rounded opacity-85 p-12 box-shadow">
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
            J'ai oublié mon mot de passe
          </label>
        </div>
      </div>

      <Cta content="Me connecter" />
    </div>
  );
}

export default LoginForm;
