<script setup lang="ts">
import { ref } from 'vue'
import { useExpensesStore } from '../../store/expensesStore'
import expenseSchema from './transactionsValidation'
import useValidation from '../../composables/useValidation'
import Button from '../ui/button/Button.vue'
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '../ui/dialog'

import TextInput from '../formInputs/TextInput.vue'
import NumberInput from '../formInputs/NumberInput.vue'
import SelectInput from '../formInputs/SelectInput.vue'
import DateInput from '../formInputs/DateInput.vue'
import Expense from '../../models/Expense'
import { parseRecurrence } from '../../util/util'

const expenseStore = useExpensesStore()

const props = defineProps({
  entityName: String,
  isEdit: Boolean,
  trigger: Object
})

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

const setDialogTitle = () => {
  return props.isEdit ? 'Edit' : 'Create'
}

const handleSubmit = async () => {
  await validate()

  if (!isValid.value) {
    scrolltoError('.p-invalid', { offset: 24 })
    return
  }

  const request = {
    id: '',
    expenseName: data.value.expenseName,
    value: data.value.value,
    category: data.value.category.name,
    recurrence: parseRecurrence(data.value.recurrence.name),
    initialDate: data.value.initialDate,
    finalDate: data.value.finalDate
  } as Expense

  console.log(request)
  if (props.isEdit) {
    request.id = data.value.id
    expenseStore.updateExpense(request)
  }
  else {
    expenseStore.postExpense(request)
  }

  console.log('enviado')
}

const { validate, isValid, getError, scrolltoError } = 
useValidation(expenseSchema, data, {
  mode: 'lazy',
});

</script>

<template>
  <Dialog>
    
    <DialogTrigger as-child>
      <slot name="trigger" />
    </DialogTrigger>

    <DialogContent>

      <DialogHeader>
        <DialogTitle>
          {{ `${setDialogTitle()} ${entityName}` }}
        </DialogTitle>
        <DialogDescription>
          Create your expense. Click save when you're done.
        </DialogDescription>
      </DialogHeader>

      <form @submit.prevent="handleSubmit">
        <div class="mb-2">
          <TextInput 
            v-model="data.expenseName" 
            field-name="Expense name"
            :class="{ 'border-red-500': !!getError('expenseName') }"
          />
          <div class="text-red-600">{{ getError('expenseName') }}</div>
        </div>

        <div class="mb-2">
          <NumberInput 
            v-model="data.value" 
            field-name="Amount"
            :class="{ 'border-red-500': !!getError('value') }"
          />
          <div class="text-red-600">{{ getError('value') }}</div>
        </div>

        <div class="mb-2 flex justify-between">
          <div>
            <SelectInput 
              v-model="data.category.name" 
              field-name="Category" 
              :select-options="categotyList"
              :class="{ 'border-red-500': !!getError('category.name') }"
            />
            <div class="text-red-600">{{ getError('category.name') }}</div>
          </div>

          <div>
            <SelectInput 
              v-model="data.recurrence.name"
              field-name="Recurrence" 
              :select-options="recurrenceList"
              :class="{ 'border-red-500': !!getError('recurrence.name') }"
            />
            <div class="text-red-600">{{ getError('recurrence.name') }}</div>
          </div>
        </div>

        <div class="mb-6 flex justify-between">
          <div>
            <DateInput 
              v-model="data.initialDate"
              field-name="Initial Date"
              :class="{ 'border-red-500': !!getError('initialDate') }"
            />
            <div class="text-red-600">{{ getError('initialDate') }}</div>
          </div>

          <div>
            <DateInput
              v-model="data.finalDate"
              field-name="Final Date"
              :class="{ 'border-red-500': !!getError('finalDate') }"
            />
            <div class="text-red-600">{{ getError('finalDate') }}</div>
          </div>
        </div>
        <DialogFooter>
          <Button type="submit">
            {{ setDialogTitle()}}
          </Button>
        </DialogFooter>

      </form>
    </DialogContent>
  </Dialog>
</template>