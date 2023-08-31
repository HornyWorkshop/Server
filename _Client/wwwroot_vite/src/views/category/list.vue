<template>
  <!-- <Single id="category" :source="value" /> -->
</template>

<script lang="ts">
import { useContentStore } from "@/store/modules/content";
import { defineAsyncComponent, defineComponent } from "vue";

export default defineComponent({
  setup() {
    const value = useContentStore();
    return { value: value.categories };
  },

  components: {
    // Single: defineAsyncComponent(() => import("@/components/editors/single.vue")),
  },
});
</script>
