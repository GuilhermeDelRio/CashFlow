<script setup lang="ts">
import Input from '../ui/input/Input.vue'

const props = defineProps({
  modelValue: String,
  fieldName: String
})

const emit = defineEmits(['update:modelValue'])
</script>

<template>
  <div>
    <label>{{ fieldName }}</label>
    <Input 
      type="text" 
      :placeholder="fieldName?.toLocaleLowerCase()"
      :value="props.modelValue" 
      @input="emit('update:modelValue', $event.target.value)" />
  </div>
</template>
