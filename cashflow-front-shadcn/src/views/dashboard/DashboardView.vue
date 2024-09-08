<script setup lang="ts">
import Button from '../../components/ui/button/Button.vue'
import { Receipt } from 'lucide-vue-next'
import TransactionsDialog from '../../components/transactionsDialog/TransactionsDialog.vue'
</script>

<template>
<div class="md:container md:mx-auto mt-9">
  <div class="flex justify-between">
    <h1 class="text-3xl text-bold font-bold">
      Dashboard
    </h1>

    <div>
      <TransactionsDialog entity-name="Expense" :isEdit="false">
        <template #trigger>
          <Button>
            Create Expense
            <Receipt class="ml-1" />
          </Button>
        </template>
      </TransactionsDialog>
    </div>
  </div>

</div>
</template>

<style scoped>
</style>