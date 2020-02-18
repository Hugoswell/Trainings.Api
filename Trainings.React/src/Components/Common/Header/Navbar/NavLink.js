import React from "react";
import { Link } from "react-router-dom";

function NavLink(props) {
  return (
    <li className="mx-6 text-gray-500 monserrat-semibold">
      <Link to={props.to} className={props.classes}>
        {props.content}
      </Link>
    </li>
  );
}

export default NavLink;
