import React from "react";

function FooterLink({ link, content }) {
  return (
    <a href={link} className="text-gray-500 mt-4">
      {content}
    </a>
  );
}

export default FooterLink;
