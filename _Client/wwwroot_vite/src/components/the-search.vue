<template>
  <input class="input" type="text" placeholder="search request..." />
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({});
</script>

<style lang="scss" scoped>
.input {
  background-color: transparent;
  box-sizing: border-box;
  padding: 10px 20px;
  // width: 100vw;
  // font-size: 5rem;
  text-align: center;
  border: none;

  transition: border-color var(--anim-dur) var(--anim-tim), color var(--anim-dur) var(--anim-tim);
  border-bottom: 1px solid var(--border-second-color);
  color: var(--font-hover-color);

  &:hover,
  &:focus {
    border-color: var(--border-first-color);
    color: var(--font-color-color);
  }

  &:focus {
    outline: none;
  }
}
</style>
