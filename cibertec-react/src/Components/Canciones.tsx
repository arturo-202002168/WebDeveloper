import React from "react";
import axios from "axios";

export default function Canciones() {
    // Utilizar los effects
    React.useEffect(() => {
        // Cuando es un [] solo se ejecuta la priemra vez que se carga el componente
        // Obtener la data del servicio
        axios.get("https://localhost:5001/api/Track")
            .then(function (response) {
                console.info("respuesta del llamado", response);
            });
    }, []);
    return <div>
        Canciones
    </div>
}