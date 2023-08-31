<template>
  <header class="block">
    <div class="name">
      <slot name="header" />
    </div>
    <div class="content">
      <slot name="content" />
    </div>
  </header>
</template>

<style scoped>
.block:not(:last-child) {
  margin-bottom: 10px;
}

.name {
  text-align: center;
  text-transform: uppercase;
  font-weight: bold;
  color: #d03d12;
}

.content {
  background-color: var(--blockColor);
  border: 1px solid var(--borderColor);
  padding: 10px;
}
</style>
