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

const data = ref({
  id: '',
  expenseName: '',
  value: 0,
  category: { name: '' },
  recurrence: { name: '' },
  initialDate: new Date(),
  finalDate: new Date()
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

const expenseSchema = z.object({
  expenseName: z.string()
    .min(3, { message: 'Expense name must have at least 3 characters' }),	
  value: z.number()
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

  console.log(data.value)
  const request = {
    id: '',
    expenseName: data.value.expenseName,
    value: data.value.value,
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

onMounted(() => {
  const params = dialogRef.value.data
  if (params.selectedItem) {
    isEditable.value = true
    data.value = {
      id: params.selectedItem.id,
      expenseName: params.selectedItem.expenseName,
      value: params.selectedItem.value,
      category: { name: params.selectedItem.category },
      recurrence: { name: parseRecurrenceToString(params.selectedItem.recurrence) },
      initialDate: new Date(params.selectedItem.initialDate),
      finalDate: new Date(params.selectedItem.finalDate)
    }
  }
})

const resetForm = () => {
  data.value = {
    id: '',
    expenseName: '',
    value: 0,
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
        <label for="expenseName">Expense name</label>
        <InputText 
          v-model="data.expenseName" 
          id="expenseName" 
          fluid 
          :class="{ 'p-invalid': !!getError('expenseName') }"
        />
        <div class="error">{{ getError('expenseName') }}</div>
      </div>

      <div>
        <label for="value">Amount</label>
        <InputNumber 
          v-model="data.value" 
          id="value" 
          showButtons 
          mode="currency" 
          currency="BRL" 
          fluid
          :class="{ 'p-invalid': !!getError('value') }"
        />
        <div class="error">{{ getError('value') }}</div>
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
