<template>
  <section class="tasks">
    <Block>
      <template v-slot:header>Tasks</template>
      <template v-slot:body>
        <div class="list">
          <div class="row" v-for="(item, key, index) of items" :key="key">
            <div class="item order">#{{ 1 + index }}</div>
            <div class="item name">
              {{ key }}
            </div>
            <div class="item status">{{ item.parts.current }} / {{ item.parts.total }}</div>
          </div>
        </div>
      </template>
    </Block>
  </section>
</template>

<script lang="ts">
import { TaskList } from "@/api/grpc";
import { defineAsyncComponent, defineComponent, onBeforeUnmount } from "vue";

export default defineComponent({
  setup() {
    const taskList = new TaskList();

    onBeforeUnmount(() => {
      taskList.dispose();
      console.log("disposed");
    });

    return { items: taskList.list };
  },

  data() {
    return {};
  },

  components: {
    Block: defineAsyncComponent(() => import("@/components/block.vue")),
  },
});
</script>

<style lang="scss" scoped>
.task {
  padding: 20px;
}

.list {
  display: grid;
  grid-template-columns: auto 1fr auto;
}

.row {
  display: contents;

  &:hover > .item {
    background-color: var(--list-hover-color);
  }
}

.item {
  padding: 10px;
}
</style>
