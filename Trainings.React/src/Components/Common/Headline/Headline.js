import React, { useContext } from "react";
import RegisterContainerContext from "../../RegisterContainer/RegisterContainerContext";

function Headline() {
  const { headline } = useContext(RegisterContainerContext);

  return (
    <div className="w-4/5 sm:w-2/5">
      <h1 className="monserrat-semibold-italic text-white text-center text-xs sm:text-3xl">
        {headline}
      </h1>
    </div>
  );
}

export default Headline;
