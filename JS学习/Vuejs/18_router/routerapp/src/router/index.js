import Vue from "vue";
// import Home from "../home/Home.vue";
// import Page1 from "../home/About.vue";
// import Page2 from "../home/User.vue";
// 引入 vue-router
import VueRouter from "vue-router";
// import { component } from "vue/types/umd";
//用上路由懒加载
const Home = ()=>import("../home/Home.vue");
const About = ()=>import("../home/About.vue");
const User = ()=>import("../home/User.vue");
const Message = ()=>import("../home/HomeMessage.vue");
const News = ()=>import("../home/HomeNews.vue");
const Profile = ()=>import("../home/Profile.vue");

Vue.use(VueRouter); // 使用 vue-router

const routes = [
  {
    path: "",
    redirect: "/home",
    meta: {
      title:"首页"
    }
  },
  {
    path: "/home",
    component: Home,
    meta: {
      title:"首页"
    },
    children:[
      // {
      //   path: "",
      //   redirect: "message",
      //   meta: {
      //     title:"消息"
      //   }
      // },
      {
        path: "news",
        component: News,
        meta: {
          title:"新闻"
        }
      },
      {
        path: "message",
        component: Message,
        meta: {
          title:"消息"
        }
      }
    ]
  },
  {
    path: "/About",
    component: About,    
    meta: {
      title:"关于"
    }
  },
  {
    path: "/User/:userId",
    component: User,
    meta: {
      title:"用户"
    }
  },
  {
    path: "/Profile",
    component: Profile, 
    meta: {
      title:"详细信息"
    }
  }
];

const router = new VueRouter({
  routes, // （缩写）相当于 routes: routes
  mode: "history",
});
//全局导航守卫
router.beforeEach((to,from,next)=>{
  document.title = to.matched[0].meta.title;
  next();
})

export default router;
