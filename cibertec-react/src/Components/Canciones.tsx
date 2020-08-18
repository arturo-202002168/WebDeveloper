import React from "react";
import { getTrackList, ITrack } from "../Services/trackService";

// Propiedades del componente CardCancion
export interface ICardCancionProps {
    track: ITrack;
}

export function CardCancion(props: ICardCancionProps) {
    const track = props.track;
    return <div className="card" style={{ width: "20%" }}>
        <div className="card-body">
            <h5 className="card-title">{track.name}</h5>
            <div className="card-text">
                <ul>
                    <li>
                        <strong>Artista</strong>
                        {`: ${track.artistName}`}
                    </li>
                    <li>
                        <strong>Album</strong>
                        {`: ${track.albumName}`}
                    </li>
                    <li>
                        <strong>Genero</strong>
                        {`: ${track.genreName}`}
                    </li>
                    <li>
                        <strong>Tipo</strong>
                        {`: ${track.mediaTypeName}`}
                    </li>
                    <li>
                        <strong>Precio</strong>
                        {`: S/ ${track.unitPrice}`}
                    </li>
                </ul>
            </div>
            <a href="#" className="btn btn-primary">Comprar</a>
        </div>
    </div>
}

export default function Canciones() {
    // Crear el state para guardar los items y el nextPage
    const [items, setItems] = React.useState<ITrack[]>([]);
    const [nextPage, setNextPage] = React.useState<number | undefined>();
    const [loading, setLoading] = React.useState(true);
    // Utilizar los effects
    React.useEffect(() => {
        // Cuando es un [] solo se ejecuta la primera vez que se carga el componente
        // Obtener la data del servicio
        async function loadData() {
            const data = await getTrackList(nextPage);
            console.info("data", data);
            // Setear los items
            setItems(data.items);
            setLoading(false);
            setNextPage(data.nextPage);
        }
        loadData();
    }, []);

    if(loading){
        return <div>
            Cargando la data.....
        </div>
    }
    return <div>
        <h1>Canciones</h1>
        <div className="d-flex flex-wrap">
        {
            items.map(t => { return <CardCancion track={t} key={t.trackId} />; })
        }
        <div>
            <button className="btn btn-primary" onClick={async ()=>{
                // obtener el nuevo resultado
                const nuevoResultado = await getTrackList(nextPage);
                // concatenar los nuevos items a los antiguos
                setItems([...items, ...nuevoResultado.items]);
                setNextPage(nuevoResultado.nextPage);
            }}>Ver mas</button>
        </div>
        </div>
        
    </div>
}
