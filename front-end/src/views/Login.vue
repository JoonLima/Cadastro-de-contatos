<template>
  <div class="box-login">
    <div class="logo">
      <h1>LOGIN</h1>
    </div>

    <InputBase label="E-mail" 
    v-model="usuario.email"
    ></InputBase>

    <InputBase label="Senha"
    type="password"
    v-model="usuario.senha"
    ></InputBase>

    <Botao value="Iniciar Sessão"
    :callBack="logar"
    ></Botao>

    <p>• Esqueceu a <router-link class="link" to="/">senha?</router-link> </p>
    <p>• Não tem conta? <router-link class="link" to="/cadastro">Criar</router-link> </p>

    
  </div>
</template>

<script>
import Botao from '@/components/Botao/Botao'
import InputBase from "@/components/InputBase/InputBase";
import Usuario from '../Models/Usuario';
import usuarioService from '../services/usuario-service'
import utilStorage from '../util/storage';


export default {
  name: "LoginView",
  components: {
    InputBase,
    Botao
  },

  data(){
    return{
      usuario: new Usuario()
    }
  },
  
  methods:{
    logar(){

      if(!this.usuario.modeloValidoLogin()){
        this.$swal({
                    icon: 'warning',
                    title: 'Email e senha são obrigatórios.',
                    showConfirmButton: true,
                    animate: true,
                    confirmButtonColor: "#1E90FF",
                    color: "#fff",
                    background: "#252525"
                    })
                    this.$router.push({ name: 'login' })
                    return;
      }

      usuarioService.login(this.usuario.email, this.usuario.senha)
      .then(response => {
        this.usuario = new Usuario (response.data.usuario);
        utilStorage.salvarUsuarioNaStorage(this.usuario);
        utilStorage.salvarTokenNaStorage(response.data.token);
        this.$router.push({ name: 'home' })
      })
      .catch(error => {
        console.log(error)
      })
    }
  }
};
</script>

<style scoped>
div.box-login {
  padding: 20px;
  width: 300px;
  margin: auto;
  border-radius: 7px;
  margin-top: 70px;
  background-color:var(--cor-primaria);
  box-shadow: 0 0 0.7em var(--cor-primaria);
}

.logo {
  padding: 25px;
  text-align: center;
  color: #fff;
}

p {
  font-weight: bold;
  color: #fff;
}

.link{
  color: var(--cor-botao);
}

.link:hover{
  color: var(--cor-hover);
}

.botao-cadastro{
  background-color: darkgray;
}
</style>