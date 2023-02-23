<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-12">
        <h3 class="titulo">
          MEUS CONTATOS
        </h3>
        <hr>
      </div>
      <div class="col-sm-2">
        <Botao
        value="Novo Contato"
        :callBack="novoContato"
        ></Botao>
      </div>
    </div>
    <table class="table">
      <thead class="table-dark">
        <tr>
          <th scope="col">Nome</th>
          <th scope="col">Email</th>
          <th scope="col">Telefone</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in contatos" :key="item.id">
          <td>{{ item.nome }}</td>
          <td>{{ item.email }}</td>
          <td>{{ item.telefone }}</td>
          <td class="td-icon">
            <i @click="editarContato(item)" class="fa-solid fa-pencil icon"></i>
            <i @click="excluirContato(item)" class="fa-solid fa-trash icon"></i>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Botao from '@/components/Botao/Botao.vue'
import contatoService from '@/services/contato-service'
import Contato from '@/Models/Contato'
import storage from '@/util/storage'

export default {
  name: 'MeusContatos',
  components:{
    Botao
  },
  data(){
    return{
      contatos: []
    }
  },

  methods:{

    retornarContatosDoUsuario(){

      let usuarioLogado = storage.obterUsuarioNaStorage();
      let idUsuarioLogado = usuarioLogado.id;

      contatoService.obterPorUsuario(idUsuarioLogado)
      .then((response) => {
        let contatos = response.data.map((c) => new Contato(c))
        this.contatos = contatos.sort().reverse();
      })
      .catch((error) => {
        console.log(error)
      })
    },

    novoContato(){
      this.$router.push({name: 'novo-contato'})
    },

    editarContato(contato){
      this.$router.push({name: 'editar-contato', params: {id: contato.id} })
    },

    excluirContato(contato){

      this.$swal({
                    icon: 'question',
                    title: 'Deseja excluir o contato?',
                    text: `Nome: ${contato.nome}`,
                    showCancelButton: true,
                    confirmButtonColor: '',
                    confirmButtonText: "Sim",
                    cancelButtonText: "Não",
                    animate: true
                    })
                    .then((result) => {
                      if(result.isConfirmed){
                        contatoService.deletar(contato.id)
                          .then(() => {
                            let indice = this.contatos.findIndex(c => c.id == contato.id);
                            this.contatos.splice(indice, 1);
                          })
                          .catch(error => {
                            console.log(error)
                          })
                      }
                    })
    }
  },

  mounted(){
    this.retornarContatosDoUsuario();
  }
 
}

</script>

<style scoped>

td, th{
  color: #fff;
  justify-content: space-around;
}

.td-icon{
  width: 100px;
}
.icon{
  margin-right: 15px;
  cursor: pointer;
}

.icon:hover{
  color: var(--cor-letras);
}



</style>
