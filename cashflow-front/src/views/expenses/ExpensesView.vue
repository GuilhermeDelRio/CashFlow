<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useDialog } from 'primevue/usedialog'
import { useExpensesStore } from '../../store/expensesStore'
import Datatable from '../../components/common/Datatable.vue'
import Expense from '../../models/Expense'
import CreateExpenseModalContent from './fragments/CreateExpenseModalContent.vue'

const dialog = useDialog()
const expenseStore = useExpensesStore()
const expenses = ref<Expense[]>([])

const expenseColumns = ref([
  { field: 'expenseName', header: 'Expanse Name' },
  { field: 'value', header: 'Value' },
  { field: 'category', header: 'Category' },
  { field: 'recurrence', header: 'Recurrence' },
  { field: 'initialDate', header: 'Initial Date' },
  { field: 'finalDate', header: 'Final Date' }
])

const openModal = (expense: Expense, isEditable: Boolean) => {
  dialog.open(CreateExpenseModalContent, {
    props: {
      header: !isEditable ? 'Create Expense' : 'Edit Expense',
      style: {
        width: '50vw',
        height: '50vh',
      },
      dismissableMask: true,
      modal: true,
      draggable: false,
      contentStyle: {
        'height': '100%',
      },
    },
    data: {
      selectedExpense: expense
    }
  })
}

onMounted(async () => {
  expenses.value = await expenseStore.getAllExpenses()
})

</script>

<template>
  <main>
    <h1>Expenses</h1>
    <Datatable 
      :columns="expenseColumns" 
      :rows="expenses"
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