<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useDialog } from 'primevue/usedialog';
import { useExpensesStore } from '../../store/expensesStore';
import Datatable from '../../components/common/Datatable.vue';
import Expense from '../../models/Expense';
import LoginView from '../login/LoginView.vue';

const dialog = useDialog();
const expenseStore = useExpensesStore();
const expenses = ref<Expense[]>([]);

onMounted(async () => {
  expenses.value = await expenseStore.getAllExpenses();
})

const openModal = () => {
  dialog.open(LoginView, {
    props: {
      header: 'Create expense',
      style: {
        width: '50vw',
      },
      dismissableMask: true,
      modal: true,
      draggable: false
    }
  });
};

</script>

<template>
  <main>
    <h1>Expenses</h1>
    <Datatable 
      :columns="expenses" 
      viewName="Expenses"
      @open-modal="openModal"
    />

  </main>
</template>

<style lang="scss">

</style>