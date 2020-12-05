//导入Vue框架
import Vue from "vue";
//导入 app.vue 框架
import App from "./app.vue";

//创建vue根实例
new Vue({
  el: "#app",
  render:h=>h(App)
});
