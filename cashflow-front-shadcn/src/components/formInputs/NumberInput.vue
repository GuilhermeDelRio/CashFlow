<script setup lang="ts">
import Label from '../ui/label/Label.vue';

import { 
  NumberField,
  NumberFieldContent,
  NumberFieldDecrement,
  NumberFieldIncrement,
  NumberFieldInput,
} from '../ui/number-field'

const props = defineProps({
  modelValue: Number,
  fieldName: String,
})

const emit = defineEmits(['update:modelValue'])
</script>

<template>
  <div>
    <Label>{{ fieldName }}</Label>
    <NumberField
      id="balance"
      :min="0"
      :default-value="0"
      :model-value="props.modelValue"
      :format-options="{
        style: 'currency',
        currency: 'BRL',
        currencySign: 'accounting',
      }"
      @update:model-value="emit('update:modelValue', $event)"
    >
      <NumberFieldContent>
        <NumberFieldDecrement />
        <NumberFieldInput />
        <NumberFieldIncrement />
      </NumberFieldContent>
    </NumberField>
  </div>
</template>
