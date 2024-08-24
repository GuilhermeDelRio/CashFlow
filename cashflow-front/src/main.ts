import { createApp } from 'vue'
import { createPinia } from 'pinia'
import router from './routes'
import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura'
import DialogService from 'primevue/dialogservice'
import App from './App.vue'
import 'primeicons/primeicons.css'
import './style.scss'
import '/node_modules/primeflex/primeflex.css'

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

app.use(DialogService)

app.mount('#app')
