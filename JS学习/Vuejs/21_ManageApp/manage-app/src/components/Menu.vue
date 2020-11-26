<template>
  <el-menu>
    <template v-for="menu in menus">
      <el-submenu v-if="menu.subMenus && menu.subMenus.length" :index="menu.index" :key="menu.index">
        <template slot="title">
          <!-- 绑个父菜单的 icon -->
          <i :class="menu.icon"></i>
          <!-- 再绑个父菜单的名称 text -->
          <!-- slot 其实类似于占位符，可以去 Vue 官方文档了解一下插槽 -->
          <span slot="title">{{ menu.text }}</span>
        </template>
        <el-menu-item-group>
          <!-- 子菜单也要遍历，同时绑上子菜单名称 text，也要绑个序号 index -->
          <!-- 使用 router-link 组件来导航. -->
          <!-- 通过传入 `to` 属性指定链接. -->
          <!-- <router-link> 默认会被渲染成一个 `<a>` 标签 -->
          <router-link tag="div"
            v-for="subMenu in menu.subMenus"
            :key="subMenu.index" :to="{name: subMenu.routerName}">
          <el-menu-item
            :index="subMenu.index"
          >{{subMenu.text}}</el-menu-item>
          </router-link>
        </el-menu-item-group>
      </el-submenu>
    </template>
  </el-menu>
</template>

<script>
const menus = [
  {
    text: "服务管理", // 父菜单名字
    icon: "el-icon-setting", // 父菜单图标
    subMenus: [{ text: "服务信息", routerName: 'Service'}], // 子菜单列表
  },
  {
    text: "产品管理",
    icon: "el-icon-menu",
    subMenus: [{ text: "产品信息" }, { text: "新增" }],
  },
  {
    text: "日志信息",
    icon: "el-icon-message",
  },
].map((x, i) => {
  // 添加 index，可用于默认展开 default-openeds 属性，和激活状态 efault-active 属性的设置
  return {
    ...x,
    // 子菜单就拼接${父菜单index}-${子菜单index}
    subMenus: (x.subMenus || []).map((y, j) => {
      return { ...y, index: `${i}-${j}` };
    }),
    // 父菜单就把 index 加上好了
    index: `${i}`,
  };
});
export default {
  props: {
    isMenuCollapse: Boolean,
  },
  data() {
    return {
      menus,
      activeIndex: "",
    };
  },
};
</script>

<style>
.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 300px;
  min-height: 400px;
}
</style>
