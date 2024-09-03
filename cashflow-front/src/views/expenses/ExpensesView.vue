<script setup lang="ts">
import { ref } from 'vue'
import { useExpensesStore } from '../../store/expensesStore'
import ExpensesModal from './fragments/ExpensesModal.vue'
import GenericTableView from '../../components/genericTableView/GenericTableView.vue'

const expenseStore = useExpensesStore()
const entityName = ref('Expenses')

const expenseColumns = ref([
  { field: 'expenseName', header: 'Expense Name' },
  { field: 'value', header: 'Value' },
  { field: 'category', header: 'Category' },
  { field: 'recurrence', header: 'Recurrence' },
  { field: 'initialDate', header: 'Initial Date' },
  { field: 'finalDate', header: 'Final Date' }
])

</script>

<template>
  <GenericTableView 
    :entityName="entityName"
    :entityStore="expenseStore"
    :dataColumns="expenseColumns"
    :modalContent="ExpensesModal"
  />
</template>

<style lang="scss"></style>