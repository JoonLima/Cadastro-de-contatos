<template>
  <div class="box-cadastro">
    <div class="logo">
      <h1>Criar conta</h1>
    </div>

    <div class="row">

      <div class="col-sm-12 margin">
          <div class="input-single">
              <input required id="nome" v-model="usuario.nome" type="text" class="input">
              <label for="nome">Nome completo</label>
          </div>
      </div>
    </div>

    <div class="row">

    <div class="col-sm-12 margin">
        <div class="input-single">
            <input required id="nome" v-model="usuario.email" type="text" class="input">
            <label for="nome">E-mail</label>
        </div>
    </div>
    </div>

    <div class="row">

    <div class="col-sm-12 margin">
        <div class="input-single">
            <input required id="nome" v-model="usuario.senha" type="password" class="input">
            <label for="nome">Senha</label>
        </div>
    </div>
    </div>
    <div class="row">
  </div>


    <Botao value="Criar conta"
    :callBack="cadastrarUsuario"
    ></Botao>
    
  </div>
</template>

<script>
import Botao from '@/components/Botao/Botao'
import usuarioService from '@/services/usuario-service'
import Usuario from '@/Models/Usuario'

export default {
  name: "LoginView",
  components: {
    Botao
  },

  data(){
    return{
      usuario: new Usuario()
    }
  },
  
  methods:{

    cadastrarUsuario(){
      usuarioService.cadastrar(this.usuario)
      .then(() => {
                this.$swal({
                    icon: 'success',
                    title: 'Usuario cadastrado com sucesso.',
                    showConfirmButton: false,
                    animate: true,
                    timer: 2000
                    })
                this.$router.push({ name: 'login' })
            })
            .catch(error => {
                console.log(error)
            })
    }
  }
};
</script>

<style scoped>
div.box-cadastro {
  
  width: 500px;
  padding: 20px;
  margin: auto;
  border-radius: 7px;
  margin-top: 70px;
  background-color:var(--cor-primaria);
  box-shadow: 0 0 0.7em var(--cor-primaria);
  
}

.margin{
    margin-top: 10px;
    font-weight: bold;
}

.logo {
  padding: 25px;
  text-align: center;
  color: #fff;
}

.botao-cadastro{
  background-color: darkgray;
}

div.input-single{
    width: 100%;
    margin: 30px 0;
    position: relative;
  }

  div.input-single label{
    font-size: 16px;
    position: absolute;
    left: 0;
    color: #fff;
    bottom: 5px;
    cursor: text;
    transition: 0.5s ease-in-out;
  }

  div.input-single .input{
    width: 100%;
    padding: 5px;
    color: #fff;
    background-color: var(--cor-primaria);
    border: 0;
    border-bottom: 2px solid #fff;
    outline: 0;
    font-size: 16px;
  }
  
  div.input-single .input:focus,
  div.input-single .input:valid{
    border-bottom: 2px solid var(--cor-botao);
    transition: 0.8s;
  }

  div.input-single .input:focus ~ label,
  div.input-single .input:valid ~ label{
    transform: translateY(-27px);
    font-size: 12px;
  }
</style>