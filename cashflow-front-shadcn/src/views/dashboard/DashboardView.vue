<script setup lang="ts">
import Button from '../../components/ui/button/Button.vue'
import { Receipt } from 'lucide-vue-next'

const createExpense = () => {
  console.log('clicked')
}
</script>

<template>
<div class="md:container md:mx-auto mt-9">
  <div class="flex justify-between">
    <h1 class="text-3xl text-bold font-bold">
      Dashboard
    </h1>

    <div>
      <Button @click="createExpense">
        Create Expense
        <Receipt class="ml-1"/>
      </Button>
    </div>
  </div>

</div>
</template>

<style scoped>
</style>