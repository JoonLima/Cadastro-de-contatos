<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-12">
        <h3 class="titulo">
          {{ modoCadastro ? 'NOVO' : 'EDITAR' }} CONTATO
        </h3>
        <hr>
      </div>
    </div>


    <div class="row">
      <div class="col-sm-2">
        <div class="form-group">
          <label for="id">Código</label>
          <input v-model="contato.id" id="id" type="text" disabled class="form-control desabilitado">
        </div>
      </div>


      <div class="col-sm-10">
        <label for="nome">Nome</label>
        <input v-model="contato.nome" id="nome" type="text" class="form-control">
      </div>

      <div class="col-sm-6 margin-top">
        <label for="email">Email</label>
        <input v-model="contato.email" id="email" type="text" class="form-control">
      </div>

      <div class="col-sm-6 margin-top">
        <label for="telefone">Telefone</label>
        <input v-model="contato.telefone" id="telefone" type="text" class="form-control">
      </div>

    </div>

    <div class="row">
      <div class="col-sm-12">
        <hr>          
        <button @click="cancelarAcao" type="button" class="btn btn-secondary float-end">Cancelar</button>
        <button @click="salvarContato" type="button" class="btn btn-primary float-end">Salvar</button>
      </div>
    </div>

  </div>
</template>

<script>
import Contato from '@/Models/Contato'
import contatoService from '@/services/contato-service'
import storage from '@/util/storage'

export default {
  name: 'ViewContato',
  components:{
  },
  data(){
    return{
      contato: new Contato(),
      modoCadastro: true
    }
  },

  methods:{

    obterContatoPorId(id){
      contatoService.obterContato(id)
      .then(response => {
        this.contato = new Contato(response.data)
      })
      .catch(error => {
        console.log(error)
      })
    },

    cancelarAcao(){
      this.contato = new Contato()
      this.$router.push({name: 'contatos'})
    },

    cadastrarContato(){
      if(!this.contato.modeloValidoCadastro()){
        this.$swal({
                    icon: 'warning',
                    title: 'Todos os campos são obrigatórios.',
                    showConfirmButton: false,
                    animate: true,
                    timer: 2000
                    })
        return;                    
      }

      let usuarioLogado = storage.obterUsuarioNaStorage();
      let idUsuarioLogado = usuarioLogado.id;

      this.contato.usuarioId = idUsuarioLogado;

      contatoService.cadastrar(this.contato)
      .then(() => {
        this.$swal({
                    icon: 'success',
                    title: 'Contato cadastrado com sucesso.',
                    showConfirmButton: false,
                    animate: true,
                    timer: 2000
                    })

        this.contato = new Contato()
      })
      .catch(error => {
        console.log(error)
      })

    },

    atualizarContato(){
      if(!this.contato.modeloValidoCadastro()){
        this.$swal({
                    icon: 'warning',
                    title: 'Todos os campos são obrigatórios.',
                    showConfirmButton: false,
                    animate: true,
                    timer: 2000
                    })
        return;
      }

      contatoService.atualizar(this.contato)
      .then(() => {
        this.$swal({
                    icon: 'success',
                    title: 'Contato atualizado com sucesso.',
                    showConfirmButton: false,
                    animate: true,
                    timer: 2000
                    })
        this.$router.push({ name: 'contatos'})
      })
      .catch(error =>{
        console.log(error)
      })
    },

    salvarContato(){
      this.modoCadastro ? this.cadastrarContato() : this.atualizarContato();
    }
  },

  mounted(){
     let id = this.$route.params.id;
     if(!id) return;

     this.modoCadastro = false;
     this.obterContatoPorId(id);
  }
}

</script>

<style scoped>

td, th{
  color: #fff;
  justify-content: space-around;
}

label{
  color: #fff;
}

.desabilitado{
  background-color: rgb(185, 185, 185);
}

.btn{
  margin-right: 10px;
}

.btn-primary{
  background-color: var(--cor-botao);
}

.btn-primary:hover{
    background-color: var(--cor-hover-botao);
}

.margin-top{
  margin-top: 15px;
}

</style>
