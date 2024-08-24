<script setup lang="ts">
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

const emits = defineEmits(['open-modal'])

</script>

<template>
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
        <Button label="Delete" icon="pi pi-trash" severity="danger" />
      </template>

      <template #end>
        <FileUpload mode="basic" accept="image/*" :maxFileSize="1000000" label="Import" chooseLabel="Import" class="mr-2" auto />
        <Button label="Export" icon="pi pi-upload" severity="contrast" />
      </template>
    </Toolbar>

    <DataTable 
      :value="rows" 
      :resizable-columns="true"
      :paginator="true"
      :rows="5"
    >
      <template #header>
        <div class="seach-input">
          <h2 class="m-0">{{ viewName }}</h2>
          <IconField>
            <InputIcon>
              <i class="pi pi-search" />
            </InputIcon>
            <InputText placeholder="Search..." />
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

          <Button icon="pi pi-trash" outlined rounded severity="danger" />
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
