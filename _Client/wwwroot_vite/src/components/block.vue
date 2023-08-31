<template>
  <div class="block">
    <div class="header">
      <slot name="header" />
    </div>
    <div class="body">
      <slot name="body" />
    </div>
  </div>
</template>

<style lang="scss" scoped>
.block {
  // margin: auto;
  // width: 50vw;

  .header {
    border-bottom: 1px solid transparent;
    border-image: linear-gradient(to right, var(--border-first-color), var(--border-second-color)) 1;
    padding: 0 10px 10px 10px;
  }
}
</style>
