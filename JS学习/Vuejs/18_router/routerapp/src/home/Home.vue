<!-- Home.vue -->
<template>
  <div>
    <div>Home</div>
    <div>
      <router-link :to="{ name: 'Page1'}" tag="button">goto Page1</router-link>
      <router-link :to="{ name: 'Page2'}" tag="button">goto Page2</router-link>
    </div>
    <!-- 子路由界面 -->
    <!-- 如果路由为 /home/page1，此处是 Page1 组件 -->
    <!-- 如果路由为 /home/page2，此处是 Page2 组件 -->
    <router-view></router-view>
  </div>
</template>

<script>
  export default {
    mounted () {
      this.$router.push({ name: "Page1", params: { id: 123 } });
    },
  }
</script>