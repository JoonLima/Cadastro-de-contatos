<template>
  <div id="app">
    <nav class="nav">
      <Menu v-if="verificarRotaParaMenu()"></Menu>
    </nav>
    <router-view/>
  </div>
</template>

<script>
import Menu from '@/components/Menu/Menu.vue';

export default {
  components: {
    Menu
  },

  methods:{
    verificarRotaParaMenu(){
      if(this.$router.currentRoute.name == 'login'){
        return false;
      } else if (this.$router.currentRoute.name == 'cadastro'){
        return false
      } else {
        return true
      }
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap');

:root{
  --cor-primaria: #171a21;
  --cor-secundaria: #29455c;
  --cor-hover: #e3ecfe;
  --cor-letras: #939AB0;
  --cor-botao: #1E90FF;
  --cor-hover-botao: #389bff;
}

.container{
  max-width: 1000px;
}

body{
  font-family: 'Roboto', sans-serif;
  background-color: var(--cor-secundaria);
}

.nav{
  background-color: var(--cor-primaria);
  width: 100%;
}

.titulo{
  margin-top: 15px;
  color: #fff;
}

hr{
  color: #fff;
}


</style>
