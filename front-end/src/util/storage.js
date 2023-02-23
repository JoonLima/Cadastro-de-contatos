import Usuario from "@/Models/Usuario";

function salvarUsuarioNaStorage(usuario){
    let stringUsuario = JSON.stringify(usuario);
    localStorage.setItem('usuario', stringUsuario)
}

function obterUsuarioNaStorage(){
    let usuarioString = localStorage.getItem('usuario');
    return new Usuario (JSON.parse(usuarioString));
}

function salvarTokenNaStorage(token){
    localStorage.setItem('token', token);
}

function obterTokenNaStorage(){
    return localStorage.getItem('token');
}

function removerTokenNaStorage(){
    localStorage.removeItem('token');
}

function removerUsuarioNaStorage(){
    localStorage.removeItem('usuario');
}


export default {
    salvarUsuarioNaStorage,
    salvarTokenNaStorage,
    obterTokenNaStorage,
    removerTokenNaStorage,
    obterUsuarioNaStorage,
    removerUsuarioNaStorage
}