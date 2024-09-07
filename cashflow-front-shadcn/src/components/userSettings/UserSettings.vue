<script setup lang="ts">
import Avatar from '../ui/avatar/Avatar.vue'
import AvatarFallback from '../ui/avatar/Avatar.vue'
import Button from '../ui/button/Button.vue'

</script>

<template>
  <Button variant="ghost" class="relative h-8 w-8 rounded-full">
        <Avatar >
          <!-- <AvatarImage src="/avatars/01.png" alt="@shadcn" /> -->
          <AvatarFallback>SC</AvatarFallback>
        </Avatar>
      </Button>
</template>