import React from "react";

function RegisterCTA(props) {
  return (
    <div className="flex justify-center">
      <button className="mt-8 bg-orange-600 text-xl px-16 py-4 rounded sm:mt-12 text-white monserrat-semibold box-shadow">
        {props.content}
      </button>
    </div>
  );
}

export default RegisterCTA;
