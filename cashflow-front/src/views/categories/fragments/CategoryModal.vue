<script setup lang="ts">
import { inject, onMounted, ref } from 'vue'
import { z } from 'zod'
import { useCategoriesStore } from '../../../store/categoriesStore'
import useValidation from '../../../composables/useValidation'

import InputText from 'primevue/inputtext'
import Divider from 'primevue/divider'
import Button from 'primevue/button'
import Category from '../../../models/Category'

const categoriesStore = useCategoriesStore()
const isEditable = ref(false)
const dialogRef: any = inject('dialogRef')

const data = ref<Category>({
  id: '',
  categoryName: '',
  description: ''
})

const categorySchema = z.object({
  id: z.string().optional(),
  categoryName: z.string().min(3, { message: "Category name is required." }),
  description: z.string().min(3, { message: "Description is required." })
})

const { validate, isValid, getError, scrolltoError } = useValidation(
  categorySchema, data, {
  mode: 'lazy',
})

const handleSubmit = async () => {
  await validate()
  
  if (!isValid.value) {
    scrolltoError('.p-invalid', { offset: 24 })
    return
  }

  if (isEditable.value) 
    categoriesStore.updateCategory(data.value)
  else 
    categoriesStore.postCategory(data.value)
  
  resetForm()
}

onMounted(() => {
  const params = dialogRef.value.data
  if (params.selectedItem) {
    isEditable.value = true
    data.value = {
      id: params.selectedItem.id,
      categoryName: params.selectedItem.categoryName,
      description: params.selectedItem.description,
    }
  }
})

const resetForm = () => {
  data.value = {
    id: '',
    categoryName: '',
    description: ''
  }
}
</script>

<template>
 <Divider />
  <div class="expense-form">
    <form @submit.prevent="handleSubmit">
      <div>
        <label for="categoryName">Category name</label>
        <InputText 
          v-model="data.categoryName" 
          id="categoryName" 
          fluid 
          :class="{ 'p-invalid': !!getError('categoryName') }"
        />
        <div class="error">{{ getError('categoryName') }}</div>
      </div>

      <div>
        <label for="description">Description</label>
        <InputText 
          v-model="data.description" 
          id="description" 
          fluid 
          :class="{ 'p-invalid': !!getError('description') }"
        />
        <div class="error">{{ getError('description') }}</div>
      </div>

      <div class="mt-4 form-button">
        <Button 
          type="submit" 
          :label="!isEditable ? 'Create category' : 'Edit category'" 
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
