<template>
  <el-container style="border: 1px solid #eee; min-height: 100%;">
    <el-aside style="width:200px;">
      <!-- 使用 Menu 组件，传入变量 isMenuCollapse -->
      <Menu />
    </el-aside>
    
    <el-container>
      <el-header></el-header>
      <el-main>
        <router-view></router-view>
      </el-main>
    </el-container>
  </el-container>
</template>

<script>
import Menu from '../../components/Menu.vue';
export default {
  name: 'app',
  data:() =>{
    return {
      isMenuCollapse: false// 是否收起左侧菜单
    }
  },
  components: {
    Menu,
  },
}
</script>

<style>
body {
  margin: 0;
}
.el-header {
  color: #333;
  line-height: 60px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  text-align: right;
  font-size: 12px;
  background-color: #ededed;
}

.el-aside {
  color: #333;
}
</style>