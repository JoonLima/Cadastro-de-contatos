export default class Usuario{

    constructor(usuario){
        usuario = usuario || {}

        this.id = usuario.id;
        this.nome = usuario.nome;
        this.email = usuario.email;
        this.senha = usuario.senha;
    }

    modeloValidoLogin(){
        return !!(this.email && this.senha);
    }
}