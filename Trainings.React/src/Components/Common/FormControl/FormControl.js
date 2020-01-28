import React from "react";
import "./FormControl.css";

function FormControl(props) {
  return (
    <div className={`flex flex-col ${props.width} ${props.mt}`}>
      <label
        className="hidden sm:block text-orange-600 uppercase monserrat-semibold text-lg"
        htmlFor={props.inputId}
      >
        {props.labelValue}
      </label>
      <input
        id={props.inputId}
        type={props.inputType}
        placeholder={props.placeholderValue}
        className="mt-1 form-input pl-4 rounded"
      />
    </div>
  );
}

export default FormControl;
