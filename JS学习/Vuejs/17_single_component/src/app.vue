<template>
    <div>
        <v-title title="vue组件化"></v-title>
        <v-button @click="handleClick">点击按钮</v-button>
    </div>
</template>
<script>
    import vTitle from './components/title.vue';
    import vButton from './components/button.vue';
    
    export default {
        components: {
            vTitle,
            vButton
        },
        methods: {
            handleClick(e) {
                console.log(e);
            }
        }
    };
</script>
// 加了scope样式只对当前组件有效
<style scoped>
.app{
  color: red;
  font-size: 24px;
}
</style>

