<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useDialog } from 'primevue/usedialog';
import { useExpensesStore } from '../../store/expensesStore';
import Datatable from '../../components/common/Datatable.vue';
import Expense from '../../models/Expense';
import CreateExpenseModalContent from './fragments/CreateExpenseModalContent.vue';
const dialog = useDialog();
const expenseStore = useExpensesStore();
const expenses = ref<Expense[]>([]);

onMounted(async () => {
  expenses.value = await expenseStore.getAllExpenses();
})

const openModal = () => {
  dialog.open(CreateExpenseModalContent, {
    props: {
      header: ' ',
      style: {
        width: '50vw',
        height: '60vh',
      },
      dismissableMask: true,
      modal: true,
      draggable: false,
      contentStyle: {
        'height': '100%',
      },
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
h1 {
  color: var(--lightfont);
}
</style>