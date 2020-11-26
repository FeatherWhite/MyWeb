<!-- App.vue -->
<template>
  <div id="app">
  <router-link to="/home">首页</router-link>
  <router-link to="/About" replace active-class="active">相关</router-link>
  <router-link :to="'/User/'+userId" replace>用户</router-link>
  <router-view></router-view>
  </div>
</template>

<script>

export default {
  name: 'App',
  components: {
    
  },
  data() {
    return {
      userId: "王的女人"
    }
  },
}
</script>

<style>
.router-link-active {
  color: #f00;
}
.active {
  color: #f00;
}
</style>
