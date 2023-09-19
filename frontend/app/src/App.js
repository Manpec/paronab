import React, { useEffect, useState } from "react";
import "./App.css";
import Tables from "./components/Tables";



function App() {

  
  return (
    <div className="App">
      <header className="App-header">
        <h1>Päron AB</h1>
        <div>
          <Tables />
        </div>
      </header>
    </div>
  );
}

export default App;
