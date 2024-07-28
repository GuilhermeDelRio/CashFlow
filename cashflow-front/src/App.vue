<script setup lang="ts">
import Sidebar from './components/common/Sidebar.vue';
</script>

<template>
  <div class='app'>
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
