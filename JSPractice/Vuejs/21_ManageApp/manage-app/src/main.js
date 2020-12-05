import Vue from "vue";
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
import VueRouter from "vue-router";
import Home from "./pages/home/Home.vue";
import Service from "./pages/home/Service.vue";
import Product from "./pages/home/product/Product.vue";
import ProductList from "./pages/home/product/ProductList.vue";
import ProductEdit from "./pages/home/product/ProductEdit.vue";
import App from "./App.vue";

Vue.config.productionTip = false;
Vue.use(ElementUI);
Vue.use(VueRouter);

const routes = [
  {
    path: "/", // 父路由路径
    component: App, // 父路由组件，传入 vue component
    name: "App", // 路由名称
    children: [
      {
        // 应用首页
        path: "home",
        component: Home,
        name: "Home",
        children: [
          // 服务列表
          { path: "service", component: Service, name: "Service" },
          // 产品容器
          {
            path: "product",
            component: Product,
            name: "Product",
            children: [
              // 子路由内容
              // 产品列表
              { path: "list", component: ProductList, name: "ProductList" },
              // 产品新增
              { path: "add/0", component: ProductEdit, name: "ProductAdd" },
              // 产品编辑
              // 我们能看到，新增和编辑其实最终使用的是同一个组件
              // 当 edit/:id 匹配成功，
              // ProductEdit 会被渲染在 Product 的 <router-view> 中
              { path: "edit/:id", component: ProductEdit, name: "ProductEdit" },
            ],
          },
        ],
      },
    ],
  },
];

const router = new VueRouter({
  routes, // （缩写）相当于 routes: routes
});

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
