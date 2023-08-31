<template>
  <section>
    <div class="button">{{ t("ui.franchises.add") }}</div>

    <div class="franchises" v-if="!loading">
      <span class="header">#</span>
      <span class="header">id</span>
      <span class="header">name</span>
      <span class="header">category</span>
      <span class="header">tag</span>

      <div class="franchise" v-for="node of result.franchises.nodes" :key="node.id">
        <span class="entry edit">edit</span>
        <span class="entry id">{{ node.id }}</span>
        <span class="entry name">
          {{ node.name[locale] || node.name.en }}
        </span>
        <span class="entry categories">
          <template v-for="(category, index) of node.categories" :key="category.id">
            <span class="dot" v-if="index != 0">・</span>
            <span class="category">
              {{ `${category.name[locale] || category.name.en}` }}
            </span>
          </template>
        </span>
        <span class="entry tags">
          <template v-for="(tag, index) of node.tags" :key="tag.id">
            <span class="dot" v-if="index != 0">・</span>
            <span class="category">
              {{ `${tag.name[locale] || tag.name.en}` }}
            </span>
          </template>
        </span>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import { useFranchisesQuery } from "@/generated/graphql";
import { useI18n } from "vue-i18n";

export default defineComponent({
  setup() {
    const use = () => {
      let first = ref(50);
      let after = ref(null);

      const changePage = () => {
        return {
          ...useFranchisesQuery({
            first: first.value,
            after: after.value,
          }),
        };
      };

      return { first, after, ...changePage() };
    };

    return { ...use(), ...useI18n() };
  },

  components: {
    // Single: defineAsyncComponent(() => import("@/components/editors/single.vue")),
  },
});
</script>

<style lang="scss" scoped>
section {
  background-color: var(--secondary-color);
  border: 1px solid var(--list-hover-color);
}
</style>

<style lang="scss" scoped>
.button {
  text-align: center;
  text-transform: uppercase;
  font-style: italic;
  padding: 10px;
  cursor: pointer;
  line-height: 1;

  text-decoration: underline;
  transition: color var(--anim-dur) var(--anim-tim), background-color var(--anim-dur) var(--anim-tim), text-decoration-color var(--anim-dur) var(--anim-tim);

  &:hover {
    color: black;
    text-decoration-color: transparent;
    background-color: var(--font-color);
  }
}

.franchises {
  display: grid;
  grid-template-columns: auto auto auto auto 1fr;
  justify-content: start;
  gap: 10px;
}

.franchise {
  display: contents;
}

.header {
  text-transform: uppercase;
  border-bottom: 1px solid var(--font-color);
  padding: 10px;
  text-align: center;
}

.entry {
  padding: 0 10px;
}

.edit {
  cursor: pointer;
  color: var(--link-color);
}

.id {
  text-align: right;
}

.edit,
.tag,
.category {
  font-style: italic;
  padding: 0 5px;
  cursor: pointer;

  transition: color var(--anim-dur) var(--anim-tim), background-color var(--anim-dur) var(--anim-tim);

  &:hover {
    color: black;
    background-color: var(--font-color);
  }
}

.category {
  color: rgba(255, 0, 102, 0.8);
}

.tag {
  color: rgba(0, 192, 255, 0.8);
}

.dot {
  color: var(--font-hover-color);
}
</style>
