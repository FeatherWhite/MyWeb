<template>
  <!-- 字符串 -->
  <!-- $route 可直接注入到模板 -->
  <div>{{ $route.params.id }}</div>
</template>

<script>
export default {
  data() {
    return {};
  },
  mounted() {
    // 每个组件中都可以通过 this.$route 获取路由信息
    console.log(this.$route.params);
  },
};
</script>

<style></style>
