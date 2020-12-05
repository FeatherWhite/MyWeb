<template>
  <div id="app">
    <div id="nav">

    </div>
    <main-tab-bar></main-tab-bar>
    <router-view/>
  </div>
</template>

<script>
import MainTabBar from "@/components/content/mainTabBar/MainTabBar.vue";

export default {
  components: {
    MainTabBar
  },
};
</script>

<style>
@import "assets/css/base.css";
</style>
