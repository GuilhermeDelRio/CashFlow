<script setup lang="ts">
import { cn } from '../../lib/utils'
import UserSettings from '../userSettings/UserSettings.vue'
</script>

<template>
  <div class="md:container md:mx-auto flex h-16 items-center px-4 justify-between">
    
    <div class="mr-4">
      <h1>LOGO</h1>
    </div>
  
    <nav :class="cn('flex items-center space-x-4 lg:space-x-6', $attrs.class ?? '')">
      <RouterLink 
        to="/dashboard"
        class="text-sm font-medium transition-colors hover:text-primary">
        Dashboard
      </RouterLink>

      <RouterLink
        to="/settings"
        class="text-sm font-medium text-muted-foreground transition-colors hover:text-primary">
        Settings
      </RouterLink>
    </nav>

    <div class="ml-auto flex items-center space-x-4">
      <UserSettings />
    </div>
  </div>
</template>

<style scoped>
</style>
