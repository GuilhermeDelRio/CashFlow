<script setup lang="ts">
import Datatable from '../../components/common/Datatable.vue';
</script>

<template>
  <main>
    <div class='dashboard'>
      <h1>Dashboard</h1>

      <!-- <div class="dashboard__grid-container">
        <div class="dashboard__grid-item1">
          <Datatable />
        </div>

        <div class="dashboard__grid-item">2</div>
        <div class="dashboard__grid-item">3</div>
        <div class="dashboard__grid-item">2</div>
        <div class="dashboard__grid-item">3</div>
        <div class="dashboard__grid-item">2</div>
        <div class="dashboard__grid-item">3</div>
      </div> -->

    </div>
  </main>
</template>

<style lang="scss">
.dashboard {
  // border: 1px solid red;

  &__grid-container {
    border: 1px solid red;
    display: grid;
    grid-template-columns: auto auto auto;
    gap: 10px;
  }

  &__grid-item1 {
    grid-column-start: 1;
    grid-column-end: 2;
  }

  &__grid-item {
    border: 1px solid rgba(0, 0, 0, 0.8);
    // width: %;
    // background-color: var(--lightfont);
    // border-radius: 8px;
    // padding: 10px;
    // font-size: 30px;
    // text-align: center;
  }
}
</style>