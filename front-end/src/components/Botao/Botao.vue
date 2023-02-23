<template>
    <button @click="callBack">
        {{ value }}
    </button>
</template>

<script>
export default {
    name: 'BotaoBase',
    props:{
        value: { type: String, require},
        callBack: { type: Function , default: () => {} }
    }
}
</script>

<style scoped>

button{
    width: 100%;
    background-color:var(--cor-botao);
    color: #ddd;
    padding: 10px;
    margin: 15px 0px;
    border: none;
    border-radius: 3px;
    cursor: pointer;
    font-weight: bold;
}

button:hover{
    background-color: var(--cor-hover-botao);
}

</style>