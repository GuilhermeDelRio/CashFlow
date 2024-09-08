<script setup lang="ts">
import Label from '../ui/label/Label.vue'
import { 
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '../ui/select'

const props = defineProps({
  modelValue: String,
  fieldName: String,
  selectOptions: {
    type: Array<any>,
    required: true,
  },
});

const emit = defineEmits(['update:modelValue'])
</script>

<template>
  <div>
    <Label>{{ fieldName }}</Label>
    <Select 
      :model-value="props.modelValue"
      @update:model-value="emit('update:modelValue', $event)"
    >
      <div>
        <SelectTrigger class="w-[220px]">
          <SelectValue :placeholder="`Select ${fieldName?.toLowerCase()}`" />
        </SelectTrigger>
      </div>
      <SelectContent>
        <SelectGroup>
          <SelectItem 
            v-for="(item, index) in selectOptions" 
            :key="index" 
            :value="item.name"
          >
            {{ item.name }}
          </SelectItem>
        </SelectGroup>
      </SelectContent>
    </Select>
  </div>
</template>
