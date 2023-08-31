<script setup lang="ts">
import type { Cards as CardsType } from "../core/cards";
import { Filters as FiltersType } from "../core/filters";

import OnThisPage from "../components/OnThisPage.vue";
import Filters from "../components/Filters.vue";
import SidebarBlock from "../components/SidebarBlock.vue";

defineProps<{ cards: CardsType }>();

const filters = new FiltersType();
filters.banned.add("test");
</script>

<template>
  <aside>
    <SidebarBlock>
      <template #header> Filters </template>
      <template #content>
        <Filters :filters="filters" />
      </template>
    </SidebarBlock>
    <SidebarBlock>
      <template #header> On this page </template>
      <template #content>
        <OnThisPage :filters="filters" :cards="cards" />
      </template>
    </SidebarBlock>
  </aside>
</template>

<style scoped>
aside {
  border-right: 1px dotted var(--secondaryFontColor);
  padding-right: 10px;
}
</style>
