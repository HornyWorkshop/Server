<script setup lang="ts">
import Header from "./components/Header.vue";
</script>

<template>
  <Header />
  <RouterView class="route" />
</template>

<style scoped>
.route {
  padding: 10px;
}
</style>

<style>
:root {
  /* --backgroundColor: #171717; */
  --backgroundColor: #0f0f0f;
  /* --blockColor: #444444; */
  --blockColor: #151718;
  /* --blockColor: #222831; */
  /* --blockColor: #393E46; */
  --linkHoverColor: #ffd369;
  --linkColor: #da0037;
  --primaryFontColor: #ededed;
  --secondaryFontColor: #a3a3a3be;
  --borderColor: #3a3a3abe;
}

body {
  background-color: var(--backgroundColor);
}

#app {
  font-family: "Anonymous Pro", monospace;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--primaryFontColor);
}

a {
  color: var(--linkColor);
  text-decoration: unset;
  font-style: italic;
}

a:hover {
  text-decoration: revert;
}
</style>
