import { createApp } from 'vue'
import { createPinia } from 'pinia'
import Vue3Toastify, { type ToastContainerOptions } from 'vue3-toastify'
import ConfirmationService from 'primevue/confirmationservice'
import router from './routes'
import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura'
import DialogService from 'primevue/dialogservice'
import App from './App.vue'
import 'primeicons/primeicons.css'
import './style.scss'
import '/node_modules/primeflex/primeflex.css'
import 'vue3-toastify/dist/index.css'

const pinia = createPinia()
const app = createApp(App)

app.use(router)
app.use(pinia)

app.use(PrimeVue, {
  theme: {
    preset: Aura,
    options: {
      prefix: 'p',
      darkModeSelector: '',
    }
  }
})

app.use(ConfirmationService);
app.use(DialogService)

app.use(Vue3Toastify, {
  autoClose: 3000,
} as ToastContainerOptions);

app.mount('#app')
