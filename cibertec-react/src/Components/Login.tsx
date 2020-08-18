import React, { FormEvent, FormEventHandler } from "react";
import { getToken } from "../Services/authService";
import { IViewProps } from "./_types";

export default function Login(props: IViewProps) {
    const submit = async (e: any) => {
        e.preventDefault();

        const email = e.currentTarget["email"].value;
        const password = e.currentTarget["password"].value;

        //Obtener el nuevo token
        const token = await getToken(email, password);

        // Guardar el token en el local storage
        window.localStorage.setItem("auth.key", token);

        // Redireccionar a la vista de home
        props.actualizarVista("home");

    }
    return <div>
        <form onSubmit={submit}>
            <input name="email" type="email"></input>
            <input name="password" type="password"></input>
            <input type="submit" value="Iniciar Sesion" />
        </form>
    </div>
}