import { http } from './config'

function obterContatos(){
    return new Promise((resolve, reject) => {
        return http.get('contatos')
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function obterContato(id){
    return new Promise((resolve, reject) => {
        return http.get(`contatos/${id}`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function obterPorUsuario(idUsuarioLogado){
    return new Promise((resolve, reject) => {
        return http.get(`contatos/usuario/${idUsuarioLogado}`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function cadastrar(usuario){
    return new Promise((resolve, reject) => {
        return http.post('contatos', usuario)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function atualizar(usuario){
    return new Promise((resolve, reject) => {
        return http.put(`contatos`, usuario)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}

function deletar(id){
    return new Promise((resolve, reject) => {
        return http.delete(`contatos/${id}`)
        .then(response => resolve(response))
        .catch(error => reject(error))
    })
}


export default {
    obterContatos,
    obterContato,
    obterPorUsuario,
    cadastrar,
    atualizar,
    deletar
}