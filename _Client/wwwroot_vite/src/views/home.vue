<template>
  <Block>
    <template v-slot:header>test</template>
    <template v-slot:body>test</template>
  </Block>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from "vue";

export default defineComponent({
  components: {
    Block: defineAsyncComponent(() => import("@/components/block.vue")),
  },
});
</script>

<style lang="scss" scoped></style>
