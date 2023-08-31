<script setup lang="ts">
import type { Cards } from "../core/cards";

defineProps<{ cards: Cards }>();
</script>

<template>
  <section class="cards">
    <div class="grid">
      <div class="cell" v-for="{ name, cover } of cards" :key="cover">
        <img class="cover" :src="cover" :alt="cover" />
        <div class="info">
          <div class="name">{{ name }}</div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(150px, 1fr));
  justify-content: space-evenly;
  gap: 10px;
}

.cell {
  display: flex;
  flex-direction: column;
  justify-content: center;
  background-color: var(--blockColor);
  position: relative;
  overflow: hidden;
}

.cover {
  transform: translateZ(0);
}

.info {
  position: absolute;
  width: 100%;
  text-align: center;
  color: var(--backgroundColor);
  visibility: hidden;
}

.name {
  padding: 10px;
}

.cell:hover {
  background-color: var(--primaryFontColor);
}

.cell:hover .cover {
  opacity: 0.2;
  filter: blur(3px);
}

.cell:hover .info {
  visibility: visible;
}
</style>
