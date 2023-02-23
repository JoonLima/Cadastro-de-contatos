export default class Contato{

    constructor(contato){
        contato = contato || {}

        this.id = contato.id;
        this.nome = contato.nome;
        this.email = contato.email;
        this.telefone = contato.telefone;
        this.usuarioId = contato.usuarioId;
    }

    modeloValidoCadastro(){
        return !!(this.email && this.nome && this.telefone);
    }
}