import Home from '@/views/Home'
import Login from '@/views/Login'
import CadastroPadrao from '@/views/CadastroPadrao'
import Contatos from '@/views/Contatos'
import Contato from '@/views/Contato'


const routes = [
    {
      path: '/',
      name: 'login',
      component: Login,
      title: 'Login',
      meta: { requiredAuth: false }
    },
    {
        path: '/home',
        name: 'home',
        component: Home,
        title: 'Home',
        meta: { requiredAuth: true }
    },
    {
        path: '/cadastro',
        name: 'cadastro',
        component: CadastroPadrao,
        title: 'Cadastro Usuario',
        meta: { requiredAuth: false }
    },
    {
      path: '/contatos',
      name: 'contatos',
      component: Contatos,
      title: 'Lista Contatos',
      meta: { requiredAuth: true }
    },
    {
      path: '/contatos/novo',
      name: 'novo-contato',
      component: Contato,
      title: 'Cadastro Contato',
      meta: { requiredAuth: true }
    },
    {
      path: '/contatos/editar',
      name: 'editar-contato',
      component: Contato,
      title: 'Editar Contato',
      meta: { requiredAuth: true }
    }

  ]

  export default routes;