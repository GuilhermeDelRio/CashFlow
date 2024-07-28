import { createRouter, createWebHistory } from "vue-router";

// Views
import DashboardView from '../views/dashboard/DashboardView.vue';
import Login from '../views/login/LoginView.vue';
import ExpensesView from "../views/expenses/ExpensesView.vue";

const routes = [
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: DashboardView
  },
  {
    path: '/Expenses',
    name: 'Expenses',
    component: ExpensesView
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router