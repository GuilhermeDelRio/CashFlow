<script setup lang="ts">
import Datatable from '../../components/common/Datatable.vue';

const expenses = [
  {
    expense: 'Spotify',
    value: 21,
    category: 'lazer',
    recurrence: 'mensal',
    initialDate: '20 jun',
    finalDate: '20 jun'
  },
  {
    expense: 'Noize',
    value: 21,
    category: 'lazer',
    recurrence: 'mensal',
    initialDate: '20 jun',
    finalDate: '20 jun'
  }
]

</script>

<template>
  <main>
    <h1>Expenses</h1>
    <Datatable :columns="expenses"/>
  </main>
</template>

<style lang="scss">

</style>