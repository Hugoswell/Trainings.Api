import React from "react";
import "./FormControl.css";

function FormControl(props) {
  return (
    <div className={`flex flex-col ${props.width} ${props.mt}`}>
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
