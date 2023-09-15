import React, { useEffect, useState } from "react";
import styles from "./App.module.css";
import Tables from "./components/Tables";
import Form from "./components/Form";

function App() {


  return (
    <div className="App">
      <header className="App-header">
        <h1>Inventory Manager</h1>
        <div>
        <Tables />
        </div>
        <div>
        <Form />
        </div>
      </header>
    </div>
  );
}

export default App;
