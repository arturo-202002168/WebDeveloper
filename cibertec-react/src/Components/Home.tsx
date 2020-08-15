import React from "react";

export interface IProps {
    actualizarVista: (nuevaVista: string) => void;
}

export default function Home(props: IProps) {
    return <div>
        <button className="btn btn-sm btn-primary" onClick={()=>{
            props.actualizarVista("canciones");
        }}>Ver canciones</button>
    </div>
}