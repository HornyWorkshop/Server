<script setup lang="ts">
import { ref } from "vue";
import type { Filters as FiltersType } from "../core/filters";
import type { Cards as CardsType } from "../core/cards";

import Cards from "../components/Cards.vue";
import CardsSidebar from "../components/CardsSidebar.vue";

const filters = ref<FiltersType>({ desired: new Set<string>(), banned: new Set<string>() });
const cards = ref<CardsType>([
  {
    name: "This can happen either by explicitly positioning into a row that is out of range",
    cover: "https://cdn.discordapp.com/attachments/839938598241697812/927025440512671785/679ec3fc1203543d825c2148eaabdfb199e720b4_result.webp",
    tags: [],
  },
  {
    name: "This can happen either by explicitly positioning into a row that is out of range",
    cover: "https://cdn.discordapp.com/attachments/839938598241697812/927025440718213180/1497dea040c464e5b1b599b6c07e8b8dde0d48c8_result.webp",
    tags: [],
  },
  {
    name: "This can happen either by explicitly positioning into a row that is out of range",
    cover: "https://cdn.discordapp.com/attachments/839938598241697812/927025440869212240/862363693ab0b98ba50aaec40b403c7c970ec54c_result.webp",
    tags: [],
  },
  {
    name: "This can happen either by explicitly positioning into a row that is out of range",
    cover: "https://cdn.discordapp.com/attachments/839938598241697812/927025440869212240/862363693ab0b98ba50aaec40b403c7c970ec54c_result.webp",
    tags: [],
  },
]);
</script>

<template>
  <section class="cards-page">
    <CardsSidebar :filters="filters" :cards="cards" />
    <Cards :cards="cards" />
  </section>
</template>

<style scoped>
.cards-page {
  display: grid;
  grid-template-columns: minmax(200px, 20vw) 1fr;
  gap: 10px;
}
</style>
