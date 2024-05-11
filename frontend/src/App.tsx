import React from "react";
import "./App.scss";
import { TeamDetails } from "pages/TeamDetails";
import { Provider } from "react-redux";
import { store } from "store/store";

function App() {
  return (
    <Provider store={store}>
      <TeamDetails />
    </Provider>
  );
}

export default App;
