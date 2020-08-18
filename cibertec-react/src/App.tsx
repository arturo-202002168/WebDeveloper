import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import Home from './Components/Home';
import Canciones from './Components/Canciones';
import Login from './Components/Login';

function App() {
  // Crear una variable de estado
  const [vista, setVista] = React.useState("login");
  return (
    <div className="App">
      {vista === "login" && <Login actualizarVista={(nuevaVista: string) => { setVista(nuevaVista); }}></Login>}
      {vista === "home" && <Home actualizarVista={(nuevaVista: string) => { setVista(nuevaVista); }}></Home>}
      {vista === "canciones" && <Canciones></Canciones>}
    </div>
  );
}

export default App;
