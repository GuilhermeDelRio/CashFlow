<script setup lang="ts">
import { computed, onMounted } from 'vue'
import { useDialog } from 'primevue/usedialog'
import Datatable from '../../components/common/Datatable.vue'

const props = defineProps({
  entityStore: Object as () => any,
  entity: Object,
  entityName: String,
  dataColumns: Array<{ field: string; header: string }>,
  modalContent: Object
})

const dialog = useDialog()

const openModal = (item: any, isEditable: Boolean) => {
  dialog.open(props.modalContent, {
    props: {
      header: !isEditable ? `Create ${props.entityName}`: `Edit ${props.entityName}`,
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
      selectedItem: item
    }
  })
}

const deleteSingleItem = async (expenseId: string) => {
  await props.entityStore.deleteSingleItem(expenseId)
}

const bulkDeleteItems = async (expenseIds: { id: string }[]) => {
  const ids = expenseIds.map((item) => item.id)

  const payload = {
    ids: ids,
  }

  await props.entityStore.bulkDeleteItems(payload)
}

onMounted(async () => {
  if (props.entityStore) {
    await props.entityStore.getAll()
  }
})

const rows = computed(() => props.entityStore.getAllEntity)

</script>

<template>
  <main>
    <h1>{{ props.entityName }}</h1>
    <Datatable 
      :columns="dataColumns" 
      :rows="rows"
      :viewName="props.entityName"
      @delete-item="deleteSingleItem"
      @bulk-delete="bulkDeleteItems"
      @open-modal="openModal"
    />
  </main>
</template>

<style lang="scss">
h1 {
  color: var(--lightfont);
}
</style>