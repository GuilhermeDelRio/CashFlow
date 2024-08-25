<script setup lang="ts">
import { inject, onMounted, ref } from 'vue'
import { z } from 'zod'
import { useExpensesStore } from '../../../store/expensesStore'
import { parseRecurrence, parseRecurrenceToString } from '../../../util/util'
import useValidation from '../../../composables/useValidation'
import Expense from '../../../models/Expense'

import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import Select from 'primevue/select'
import Divider from 'primevue/divider'
import DatePicker from 'primevue/datepicker'
import Button from 'primevue/button'

const expenseStore = useExpensesStore()
const isEditable = ref(false)
const dialogRef: any = inject('dialogRef')

onMounted(() => {
  const params = dialogRef.value.data
  if (params.selectedExpense) {
    isEditable.value = true
    data.value = {
      id: params.selectedExpense.id,
      expense_name: params.selectedExpense.expenseName,
      expense_amount: params.selectedExpense.value,
      category: { name: params.selectedExpense.category },
      recurrence: { name: parseRecurrenceToString(params.selectedExpense.recurrence) },
      initialDate: new Date(params.selectedExpense.initialDate),
      finalDate: new Date(params.selectedExpense.finalDate)
    }
  }
})

const categotyList = ref([
  {name: 'Category 1'},
  {name: 'Category 2'},
  {name: 'Category 3'},
  {name: 'Category 4'}
])

const recurrenceList = ref([
  {name: 'Daily'},
  {name: 'Weekly'},
  {name: 'Monthly'},
  {name: 'Quarterly'},
  {name: 'Yearly'}
])

const data = ref({
  id: '',
  expense_name: '',
  expense_amount: 0,
  category: { name: '' },
  recurrence: { name: '' },
  initialDate: new Date(),
  finalDate: new Date()
})

const expenseSchema = z.object({
  expense_name: z.string()
    .min(3, { message: 'Expense name must have at least 3 characters' }),	
  expense_amount: z.number()
    .min(0.01, { message: 'Expense amount must be greater than 0' }),
  category: z.object({ name: z.string()
    .min(1, { message: 'Category must be selected' }) }),
  recurrence: z.object({ name: z.string()
    .min(1, { message: 'Recurrence must be selected' }) }),
  initialDate: z.date(),
  finalDate: z.date()
})

const { validate, isValid, getError, scrolltoError } = useValidation(expenseSchema, data, {
  mode: 'lazy',
});

const handleSubmit = async () => {
  await validate()
  
  if (!isValid.value) {
    scrolltoError('.p-invalid', { offset: 24 })
    return
  }

  const request = {
    expenseName: data.value.expense_name,
    value: data.value.expense_amount,
    category: data.value.category.name,
    recurrence: parseRecurrence(data.value.recurrence.name),
    initialDate: data.value.initialDate,
    finalDate: data.value.finalDate
  } as Expense

  if (isEditable.value) {
    request.id = data.value.id
    expenseStore.updateExpense(request)
  }
  else {
    expenseStore.postExpense(request)
  }
  
  resetForm()
}

const resetForm = () => {
  data.value = {
    id: '',
    expense_name: '',
    expense_amount: 0,
    category: { name: '' },
    recurrence: { name: '' },
    initialDate: new Date(),
    finalDate: new Date()
  }
}
</script>

<template>
 <Divider />
  <div class="expense-form">
    <form @submit.prevent="handleSubmit">
      
      <div>
        <label for="expense_name">Expense name</label>
        <InputText 
          v-model="data.expense_name" 
          id="expense_name" 
          fluid 
          :class="{ 'p-invalid': !!getError('expense_name') }"
        />
        <div class="error">{{ getError('expense_name') }}</div>
      </div>

      <div>
        <label for="expense_amount">Amount</label>
        <InputNumber 
          v-model="data.expense_amount" 
          id="expense_amount" 
          showButtons 
          mode="currency" 
          currency="BRL" 
          fluid
          :class="{ 'p-invalid': !!getError('expense_amount') }"
        />
        <div class="error">{{ getError('expense_amount') }}</div>
      </div>
      
      <div class="group-items mb-2">
        <Select 
          v-model="data.category" 
          :options="categotyList" 
          optionLabel="name" 
          placeholder="Select a Category" 
          checkmark 
          :highlightOnSelect="false" 
          class="w-full md:w-56"
          :class="{ 'p-invalid': !!getError('category.name') }"
        />
        <div class="error">{{ getError('category.name') }}</div>

        <Select 
          v-model="data.recurrence" 
          :options="recurrenceList" 
          optionLabel="name" 
          placeholder="Select a Recurrence" 
          checkmark 
          :highlightOnSelect="false" 
          class="w-full md:w-56 ml-3"
          :class="{ 'p-invalid': !!getError('recurrence.name') }"
        />
        <div class="error">{{ getError('recurrence.name') }}</div>
      </div>

      <div class="group-items">
        <DatePicker 
          v-model="data.initialDate" 
          showIcon 
          dateFormat="dd/mm/yy" 
          iconDisplay="input" 
          class="w-full md:w-56"
          :class="{ 'p-invalid': !!getError('initialDate') }"
        />
        <div class="error">{{ getError('initialDate') }}</div>

        <DatePicker 
          v-model="data.finalDate" 
          showIcon 
          dateFormat="dd/mm/yy" 
          iconDisplay="input"    
          class="w-full md:w-56 ml-3"
          :class="{ 'p-invalid': !!getError('finalDate') }"
        />
        <div class="error">{{ getError('finalDate') }}</div>
      </div>

      <div class="mt-4 form-button">
        <Button 
          type="submit" 
          :label="!isEditable ? 'Create expense' : 'Edit expense'" 
        />
      </div>
      
    </form>
  </div>
</template>  
 
<style lang="scss">
.expense-form {
  margin-top: 25px;
}
.group-items {
  display: flex;
  flex-direction: row;
}
.error {
  color: red;
  font-size: 0.875rem;
  margin-top: 0.25rem;
  
}

.form-button {
  display: flex;
  justify-content: flex-end;
  margin-top: 1rem;
}
</style>
