<script setup lang="ts">
import { onMounted, ref } from 'vue';
import Datatable from '../../components/common/Datatable.vue';
import { useExpensesStore } from '../../store/expensesStore';
import Expense from '../../models/Expense';

const expenseStore = useExpensesStore();
const expenses = ref<Expense[]>([]);

onMounted(async () => {
  expenses.value = await expenseStore.getAllExpenses();
})

</script>

<template>
  <main>
    <h1>Expenses</h1>
    <Datatable :columns="expenses"/>
  </main>
</template>

<style lang="scss">

</style>