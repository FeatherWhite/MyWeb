import Vue from "vue";
import Home from "../home/Home.vue";
import Page1 from "../home/About.vue";
import Page2 from "../home/User.vue";
// 引入 vue-router
import VueRouter from "vue-router";

Vue.use(VueRouter); // 使用 vue-router

const routes = [
  {
    path: "",
    redirect: "/home",
  },
  {
    path: "/home",
    component: Home,
  },
  {
    path: "/About",
    component: Page1,
  },
  {
    path: "/User/:userId",
    component: Page2,
  },
];

const router = new VueRouter({
  routes, // （缩写）相当于 routes: routes
  mode: "history",
});

export default router;
