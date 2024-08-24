<script setup lang="ts">
import Toast from 'primevue/toast';
import Sidebar from './components/common/Sidebar.vue';
import DynamicDialog from 'primevue/dynamicdialog';
</script>

<template>
  <div class='app'>
    <!-- <Toast /> -->
    <DynamicDialog />
    <Sidebar />
    <router-view />
  </div>
</template>

<style lang="scss">
.app {
  display: flex;
  
  main {
    flex: 1 1 0;
    padding: 2rem;

    @media (max-width: 1024px) {
			padding-left: 6rem;
		}

    h1 {
      margin-bottom: 5px;
    }
  }
}
</style>
