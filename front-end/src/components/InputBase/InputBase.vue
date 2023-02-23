<template>
  <div class="input-single">       
      <input class="input" required :placeholder="placeHolder" :type="type" v-model="valor">
      <label for=""> {{ label }}</label>
  </div>
</template>

<script>
export default {
  name:"InputBase",
  model:{
      prop: "value",
      event:'onChange'
  },
  props:{
      label: { type: String, default: ''},
      type: { type: String, default: 'text'},
      placeHolder: { type: String, default: ''},
      value: { type: String, default: ''}
  },
  data(){
      return {
          valor: this.value
      }
  },
  watch:{
      valor(){
          this.$emit('onChange', this.valor);
      }
  }
}
  </script>
  
  <style scoped>
 
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