import { http } from './config'

function obterTodos(){
    return new Promise((resolve, reject) => {
        return http.get('usuarios')
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function obterPorId(id){
    return new Promise((resolve, reject) => {
        return http.get(`usuarios/${id}`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function cadastrar(usuario){
    return new Promise((resolve, reject) => {
        return http.post('usuarios/nova-conta', usuario)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function atualizar(usuario){
    return new Promise((resolve, reject) => {
        return http.put(`usuarios`, usuario)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function deletar(id){
    return new Promise((resolve, reject) => {
        return http.delete(`usuarios/${id}`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function login(email, senha){
    return new Promise((resolve, reject) => {
        return http.post(`usuarios/entrar`, { email, senha })
        .then(response => resolve(response))
        .catch(error => reject(error))
    });
}

function logout(){
    return new Promise((resolve, reject) => {
        return http.delete(`usuarios/sair`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}


export default {
    obterTodos,
    obterPorId,
    cadastrar,
    atualizar,
    deletar,
    login,
    logout
}