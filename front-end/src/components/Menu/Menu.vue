<template>
    <div class="nav container">
        <div class="menu-opcoes">
            <router-link to="/home">HOME</router-link>
            <router-link to="/contatos">CONTATOS</router-link>
        </div>
        
        <div class="menu-login">
            <router-link to="/perfil">Bem vindo(a), {{ retornarNomeDoUsuario() }}</router-link>
            <router-link to="/">
                <button @click="logout" type="button" class="btn ">SAIR</button>
            </router-link>
        </div>
    </div>
</template>

<script>
import utilStorage from '@/util/storage';

export default {
    name: 'MeuMenu',

    methods:{
      logout(){
        utilStorage.removerUsuarioNaStorage();
        utilStorage.removerTokenNaStorage();
        this.$router.push({ path:'/' })
      },

      retornarNomeDoUsuario(){
        let usuarioLogado = utilStorage.obterUsuarioNaStorage();
        return usuarioLogado.nome;
      }
    }
}
</script>

<style scoped>

.nav {
  display: flex;
  width: 100%;
}

.menu-opcoes {
  width: fit-content;
  margin: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  float: left;
}

.menu-opcoes a {
  overflow: hidden;
  text-decoration: none;
  padding: 20px 10px;
  color: var(--cor-letras);
  float: left;
}

.menu-login {
  width: fit-content;
  margin-left: auto;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 7px 10px;
  float: right;
}

.menu-login a {
  overflow: hidden;
  text-decoration: none;
  padding: 20px 10px;
  color: var(--cor-letras);
}

.btn{
  color: var(--cor-letras);
  border: 2px solid var(--cor-letras);
}

.menu-opcoes a:hover,
.menu-login a:hover {
  color: var(--cor-hover);
}

.btn:hover{
  color: var(--cor-hover);
}

</style>