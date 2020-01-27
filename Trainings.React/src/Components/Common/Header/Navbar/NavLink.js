import React from "react";

function NavLink(props) {
  return (
    <li className="mx-6 text-gray-500 monserrat-semibold">
      <a href={props.link}>{props.content}</a>
    </li>
  );
}

export default NavLink;
