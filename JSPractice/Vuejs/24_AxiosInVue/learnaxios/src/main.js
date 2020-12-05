import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from "axios"

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

// axios.defaults.baseURL = 'http://152.136.185.210:7878/api/m5'

// axios({
//   url:'/home/multidata'
// }).then(res=>console.log(res))

// axios({
//   url:'/home/data',
//   params: {
//     type: 'pop',
//     page: 1
//   }
// }).then(res => console.log(res))

// // 2.axios并发请求
// axios.all([axios({
//   url: '/home/multidata'
// }),axios({
//   url:'/home/data',
//   params: {
//     type: 'sell',
//     page: 5
//   }
// })]).then(result=>console.log(result))

// 4.创建axios实例
const instance1 = axios.create({
  baseURL: 'http://152.136.185.210:7878/api/m5',
  timeout: 5000
})

instance1({
  url: '/home/multidata'
}).then(res=>{
  console.log(res);
})

instance1({
  url: '/home/data',
  params: {
    type: 'pop',
    page: 1
  }
}).then(res => console.log(res))