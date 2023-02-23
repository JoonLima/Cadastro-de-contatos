import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from '@/router/router'

Vue.use(VueRouter)

const router = new VueRouter({
  routes,
  mode: 'history'
})

router.beforeEach((to, from, next) => {

  let token = localStorage.getItem('token');

  if(to.name == 'login'){
    if(token){
      next({ name: 'home' });
    }else{
      next();
    }
    

  }else if(to.matched.some(rota => rota.meta.requiredAuth)){
    if(token == null){
      next({
        path:"/",
        params: { nextUrl: to.fullPath }
      });
    }else{
      next();
    }

  }else{
    if(token == null){
      next();
    } else {
      next({ name: 'home' })
    }
  }
})



export default router
