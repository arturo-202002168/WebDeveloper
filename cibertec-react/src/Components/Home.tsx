import React from "react";
import { IViewProps } from "./_types";

export default function Home(props: IViewProps) {
    return <div>
        <button className="btn btn-sm btn-primary" onClick={()=>{
            props.actualizarVista("canciones");
        }}>Ver canciones</button>
    </div>
}