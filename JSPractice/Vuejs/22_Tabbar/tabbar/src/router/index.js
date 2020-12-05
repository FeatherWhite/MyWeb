import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const Home = () => import("../views/home/Home.vue");
const Profile = () => import("../views/profile/Profile.vue");
const Category = () => import("../views/category/Category.vue");
const Cart = () => import("../views/cart/Cart.vue");

const router = new VueRouter({
  mode: "history",
  routes: [
    {
      path: "",
      redirect: "/home",
    },
    {
      path: "/home",
      component: Home,
    },
    {
      path: "/category",
      component: Category,
    },
    {
      path: "/profile",
      component: Profile,
    },
    {
      path: "/cart",
      component: Cart,
    },
  ],
});

export default router;
