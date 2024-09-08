<script setup lang="ts">
import { defineProps, defineEmits } from 'vue'
import Button from '../ui/button/Button.vue'
import { Popover, PopoverTrigger, PopoverContent } from '../ui/popover'
import { Calendar } from '../ui/calendar'
import { Calendar as CalendarIcon } from 'lucide-vue-next'
import { cn } from '../../lib/utils'
import Label from '../ui/label/Label.vue'

const props = defineProps<{
  modelValue?: Date;
  fieldName: string;
}>();

const emit = defineEmits<{
  (e: 'update:modelValue', value: Date | null): void;
}>();

const placeholder = "Pick a date";
const df = new Intl.DateTimeFormat('en-US', { dateStyle: 'medium' });

const toDate = (value: any) => {
  if (value instanceof Date) {
    return value;
  } else if (typeof value === 'object' && value !== null) {
    return new Date(value.year, value.month - 1, value.day);
  }
  return new Date();
}

const handleDateChange = (date: any) => {
  const validDate = toDate(date);
  emit('update:modelValue', validDate);
}
</script>

<template>
  <div class="flex flex-col">
    <Label>{{ props.fieldName }}</Label>
    <Popover>
      <PopoverTrigger as-child>
        <div>
          <Button
            variant="outline"
            :class="cn('w-[220px]', !props.modelValue && 'text-muted-foreground')"
          >
            <span>{{ props.modelValue ? df.format(props.modelValue) : placeholder }}</span>
            <CalendarIcon class="ms-auto h-4 w-4 opacity-50" />
          </Button>
        </div>
      </PopoverTrigger>
      <PopoverContent class="w-auto p-0">
        <Calendar
          v-model:date="props.modelValue"
          initial-focus
          @update:model-value="handleDateChange"
        />
      </PopoverContent>
    </Popover>
  </div>
</template>
