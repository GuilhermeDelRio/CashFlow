<script setup lang="ts">
import { ref } from 'vue'
import { useCategoriesStore } from '../../store/categoriesStore'
import GenericTableView from '../../components/genericTableView/GenericTableView.vue'
import CategoryModal from './fragments/CategoryModal.vue'

const categoriesStore = useCategoriesStore()
const entityName = ref('Categories')

const categoriesColumns = ref([
  { field: 'categoryName', header: 'Category name' },
  { field: 'description', header: 'Description' }
])
</script>

<template>

  <GenericTableView 
    :entityName="entityName"
    :entityStore="categoriesStore"
    :dataColumns="categoriesColumns"
    :modalContent="CategoryModal"
  />

</template>

<style lang="scss">
</style>