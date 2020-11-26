import Vue from 'vue'
import App from './App.vue'
import Home from './home/Home.vue'
import Page1 from './home/Page1.vue'
import Page2 from './home/Page2.vue'
// 引入 vue-router
import VueRouter from "vue-router";

Vue.use(VueRouter); // 使用 vue-router
Vue.config.productionTip = false

const routes = [
  {
    path:"/home",
    component: Home,
    name: "Home",
    children: [
      { path: "page1/:id", component: Page1, name: "Page1" },
      { path: "page2", component: Page2, name: "Page2" }
    ]
  },
    // 通配符 * 会匹配所有路径
  // 路由 { path: '*' } 通常用于客户端 404 错误
  // 含有通配符的路由应该放在最后
  { path: "*", redirect: { name: "Home" } }
];

const router = new VueRouter({
  routes // （缩写）相当于 routes: routes
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
