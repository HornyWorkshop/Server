<template>
  <header class="header">
    <RouterLink to="home">Home</RouterLink>
    <RouterLink to="cards">Cards</RouterLink>
    <RouterLink to="scenes">Scenes</RouterLink>
    <RouterLink to="plugins">Plugins</RouterLink>
  </header>
</template>

<style scoped>
.header {
  padding: 10px;
  background-color: var(--blockColor);
  border-bottom: 1px solid var(--borderColor);

  display: flex;
  gap: 10px;
}

a {
  color: var(--primaryFontColor);
  font-style: normal;
  text-transform: uppercase;
  font-weight: bold;
}

.router-link-active {
  pointer-events: none;
  text-decoration: revert;
  padding-bottom: 2px;
}
</style>
