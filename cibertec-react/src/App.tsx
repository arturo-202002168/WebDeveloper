import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import Home from './Components/Home';
import Canciones from './Components/Canciones';

function App() {
  // Crear una variable de estado
  const [vista, setVista] = React.useState("home");
  return (
    <div className="App">
      {vista === "home" && <Home actualizarVista={(nuevaVista: string) => { setVista(nuevaVista); }}></Home>}
      {vista === "canciones" && <Canciones></Canciones>}
    </div>
  );
}

export default App;
