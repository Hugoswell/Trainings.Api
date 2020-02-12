import React from "react";
import Register from "./Pages/Register";
import Login from "./Pages/Login";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/" exact component={Register} />
        <Route path="/login" exact component={Login} />
      </Switch>
    </Router>
  );
}

export default App;
