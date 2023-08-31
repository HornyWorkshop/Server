<script setup lang="ts">
import FilterValues from "./FiltersValues.vue";
import { Filters } from "../core/filters";

const { filters } = defineProps<{ filters: Filters }>();
</script>

<template>
  <header class="filter">
    <input type="text" name="filter-request" id="filter-request" />

    <FilterValues :filter="filters.desired" name="desired" />
    <FilterValues :filter="filters.banned" name="banned" />
  </header>
</template>

<style scoped>
#filter-request {
  padding: 5px 10px;
  border: none;
  width: 100%;

  font: inherit;
}
</style>
