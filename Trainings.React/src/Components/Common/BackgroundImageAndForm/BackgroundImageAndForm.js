import React, { useContext } from "react";
import BackgroundImage from "../BackgroundImage/BackgroundImage";
import Headline from "../Headline/Headline";
import RegisterForm from "../../RegisterContainer/RegisterForm/RegisterForm/RegisterForm";
import LoginForm from "../../LoginContainer/LoginForm/LoginForm/LoginForm";
import "./BackgroundImageAndForm.css";
import BackgroundImageAndFormContext from "../BackgroundImageAndForm/BackgroundImageAndFormContext";

function BackgroundImageAndForm() {
  const { form } = useContext(BackgroundImageAndFormContext);
  const formComponent = form === "register" ? <RegisterForm /> : <LoginForm />;

  return (
    <div className="relative mt-16">
      <BackgroundImage />
      <div className="absolute absolute-cy w-screen">
        <div className="flex items-center justify-around">
          <Headline />
          {formComponent}
        </div>
      </div>
    </div>
  );
}

export default BackgroundImageAndForm;
