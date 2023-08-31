<script setup lang="ts">
import { Filter } from "../core/filters";

defineProps<{ filter: Filter; name: string }>();
</script>

<template>
  <header class="header">
    <div class="header-name">{{ name }}</div>
    <div class="value" v-for="value in filter" :key="value" @click="filter.delete(value)">
      <div class="value-name">
        {{ value }}
      </div>
    </div>
  </header>
</template>

<style scoped>
.header-name {
  padding: 10px 0;
  text-transform: uppercase;
  font-weight: bold;
}

.value {
  overflow: hidden;
  display: inline-block;
  position: relative;
}

.value-name {
  padding: 5px 10px;
  background-color: #2b2c30;
  color: var(--secondaryFontColor);
  border-radius: 5px;
}

.value:hover .value-name {
  background-color: var(--linkColor);
  border-color: var(--linkColor);
  color: var(--linkColor);
  cursor: pointer;
}
</style>
