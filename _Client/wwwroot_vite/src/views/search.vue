<template>
  <TheSearch />
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from "vue";

export default defineComponent({
  components: {
    TheSearch: defineAsyncComponent(() => import("@/components/the-search.vue")),
  },
});
</script>

<style lang="scss" scoped></style>
