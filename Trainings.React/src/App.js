import React from "react";
import Register from "./Pages/Register";
import Login from "./Pages/Login";
import Home from "./Pages/Home";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/register" exact component={Register} />
        <Route path="/login" exact component={Login} />
        <Route path="/" exact component={Home} />
      </Switch>
    </Router>
  );
}

export default App;
