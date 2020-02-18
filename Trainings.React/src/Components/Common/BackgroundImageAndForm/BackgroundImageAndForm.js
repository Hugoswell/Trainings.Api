import React from "react";
import BackgroundImage from "../BackgroundImage/BackgroundImage";
import Headline from "../Headline/Headline";
import RegisterForm from "../../RegisterContainer/RegisterForm/RegisterForm/RegisterForm";
import "./BackgroundImageAndForm.css";

function BackgroundImageAndForm() {
  return (
    <div className="relative mt-16">
      <BackgroundImage />
      <div className="absolute absolute-cy w-screen">
        <div className="flex items-center justify-around">
          <Headline />
          <RegisterForm />
        </div>
      </div>
    </div>
  );
}

export default BackgroundImageAndForm;
