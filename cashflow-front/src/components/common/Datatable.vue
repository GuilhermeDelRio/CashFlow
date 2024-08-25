<script setup lang="ts">
import { ref } from 'vue'
import { useConfirm } from 'primevue/useconfirm'
import { FilterMatchMode } from '@primevue/core/api'
import ConfirmDialog from 'primevue/confirmdialog'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'
import FileUpload from 'primevue/fileupload'
import IconField from 'primevue/iconfield'
import InputIcon from 'primevue/inputicon'
import InputText from 'primevue/inputtext'

defineProps({
  columns: Array<{ field: string; header: string }>,
  rows: Array,
  viewName: String
})

const confirm = useConfirm()
const selectedProducts = ref()
const dt = ref()
const filters = ref({
  'global': {value: null, matchMode: FilterMatchMode.CONTAINS},
})

const emits = defineEmits(['open-modal', 'delete-item', 'bulk-delete'])

const confirmDelete = (itemId: string) => {
  confirm.require({
    message: 'Do you want to delete this record?',
    header: 'Are you sure?',
    icon: 'pi pi-info-circle',
    rejectLabel: 'Cancel',
    rejectProps: {
      label: 'Cancel',
      severity: 'secondary',
      outlined: true
    },
    acceptProps: {
      label: 'Delete',
      severity: 'danger'
    },
    accept: () => {
      emits('delete-item', itemId)
    }
  })
}

const bulkDelete = () => {
  confirm.require({
    message: 'Do you want to delete the selected records?',
    header: 'Are you sure?',
    icon: 'pi pi-info-circle',
    rejectLabel: 'Cancel',
    rejectProps: {
      label: 'Cancel',
      severity: 'secondary',
      outlined: true
    },
    acceptProps: {
      label: 'Delete',
      severity: 'danger'
    },
    accept: () => {
      emits('bulk-delete', selectedProducts.value)
    }
  })
}

const exportCSV = () => {
  dt.value.exportCSV()
}

</script>

<template>
  <ConfirmDialog />
  <div class="datable-container">
    <Toolbar>
      <template #start>
        <Button 
          @click="$emit('open-modal', null, false)"
          label="New" 
          icon="pi pi-plus" 
          severity="success" 
          class="mr-2" 
        />
        <Button 
          @click="bulkDelete"
          :disabled="!selectedProducts || !selectedProducts.length"
          label="Delete" 
          icon="pi pi-trash" 
          severity="danger" 
        />
      </template>

      <template #end>
        <FileUpload mode="basic" accept="image/*" :maxFileSize="1000000" label="Import" chooseLabel="Import" class="mr-2" auto />
        <Button 
          @click="exportCSV()"
          label="Export" 
          icon="pi pi-upload" 
          severity="contrast" 
        />
      </template>
    </Toolbar>

    <DataTable
      ref="dt"
      :value="rows"
      v-model:selection="selectedProducts"
      :resizable-columns="true"
      :paginator="true"
      :rows="5"
      :filters="filters"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
      :rowsPerPageOptions="[5, 10, 25]"
      :currentPageReportTemplate="`Showing {first} to {last} of {totalRecords} ${viewName?.toLowerCase()}`"
    >
      <template #header>
        <div class="seach-input">
          <h2 class="m-0">{{ viewName }}</h2>
          <IconField>
            <InputIcon>
              <i class="pi pi-search" />
            </InputIcon>
            <InputText v-model="filters['global'].value" placeholder="Search..." />
        </IconField>
        </div>
      </template>
      
      <Column selectionMode="multiple" style="width: 3rem" :exportable="false"></Column>
      
      <Column
        v-for="col in columns" 
        :key="col.field" 
        :field="col.field" 
        :header="col.header" 
        sortable>
      </Column>

      <Column :exportable="false" style="min-width: 12rem">
        <template #body="slotProps">
          <Button
            @click="$emit('open-modal', slotProps.data, true)"
            icon="pi pi-pencil"
            outlined 
            rounded 
            class="mr-2" 
          />

          <Button 
            @click="confirmDelete(slotProps.data.id)"
            icon="pi pi-trash" 
            outlined 
            rounded 
            severity="danger" 
          />

        </template>
      </Column>
    </DataTable>
  </div>
</template>

<style lang="scss">
.datable-container {
  background-color: var(--lightfont);
  border-radius: 8px;
  padding: 10px;
}

.seach-input {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style>
