<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </div>
    <router-view/>
    <button @click="add">+</button>
    <button @click="sub">-</button>
    <h2>{{$store.state.counter}}</h2>
    <h2>平方:{{$store.getters.powerCounter}}</h2>
  </div>
</template>

<script>
  export default {
    name: 'App',
    methods: {
      add() {
        this.$store.commit('increment')
      },
      sub() {
        this.$store.commit('decrement')
      }
    },
  }
</script>

<style>

</style>
