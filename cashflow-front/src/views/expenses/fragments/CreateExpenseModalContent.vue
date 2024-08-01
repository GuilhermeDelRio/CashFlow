<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { getRecurrenceOptions } from '../../../util/util';
import { Recurrence } from '../../../models/Expense';

const recurrenceValues = ref<Recurrence[]>([]);

const mockData = [
  { ExpenseName: 'Expense 1', Value: 100, Category: 'Category 1', Recurrence: 'Recurrence 1', InitialDate: new Date(), FinalDate: new Date() },
  { ExpenseName: 'Expense 2', Value: 200, Category: 'Category 2', Recurrence: 'Recurrence 2', InitialDate: new Date(), FinalDate: new Date() },
  { ExpenseName: 'Expense 3', Value: 300, Category: 'Category 3', Recurrence: 'Recurrence 3', InitialDate: new Date(), FinalDate: new Date() },
];

onMounted(() => {
  recurrenceValues.value = getRecurrenceOptions();
});
</script>

<template>
  <Vueform size="md" :display-errors="false" class="expense-form">
    <StaticElement 
      name="register_title"
      content="Create expense"
      tag="h2"
    />

    <StaticElement
      name="divider"
      tag="hr"
    />

    <GroupElement name="container-text">
      <TextElement
        name="expanse_name"
        placeholder="Expense name"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        field-name="Expense name"
        :rules="[
          'required',
          'max:255',
        ]"
      />
      <TextElement
        name="expense_amount"
        placeholder="Expense amount"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        field-name="Expanses amount"
        :rules="[
          'required',
          'numeric'
        ]"
      />
    </GroupElement>
    
    <GroupElement name="container">
      <SelectElement
        name="Category"
        :search="true"
        :native="false"
        input-type="search"
        autocomplete="disabled"
        placeholder="Category"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        :rules="[
          'required',
        ]"
        :items="mockData.map(item => item.Category)"
      />
      <SelectElement
        name="Recurrence"
        :search="true"
        :native="false"
        input-type="search"
        autocomplete="disabled"
        placeholder="Recurrence"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        :rules="[
          'required',
        ]"
        :items="recurrenceValues.map(item => item)"
      />
    </GroupElement>

    <GroupElement name="container-date">
      <DateElement
        name="InitialDate"
        placeholder="Initial date"
        field-name="Initial date"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        :rules="[
          'required',
        ]"
        display-format="MMMM DD, YYYY"
      />
      <DateElement
        name="FinalDate"
        placeholder="Final date"
        :columns="{
          container: 6,
          label: 12,
          wrapper: 12,
        }"
        field-name="Final date"
        :rules="[
          'required',
        ]"
        display-format="MMMM DD, YYYY"
      />
    </GroupElement>

    <ButtonElement
      name="register"
      :submits="true"
      button-label="Create expense"
      :full="true"
      size="md"
    />
  </Vueform>
</template> 
 
<style lang="scss">
.expense-form {
  padding: 20px;
}
</style>