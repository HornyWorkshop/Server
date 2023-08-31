<template>
  <aside class="menu">
    <div class="group" v-for="(links, group) of links" :key="group">
      {{ t(`ui.header.menu.${group}_text`) }}
      <div class="links">
        <RouterLink class="link" :to="{ name: link.name }" v-for="link of links" :key="link">{{ t(`ui.header.menu.${group}.${link.token}`) }}</RouterLink>
      </div>
    </div>
  </aside>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useI18n } from "vue-i18n";

export default defineComponent({
  data() {
    const links = {
      content: [
        { token: "cards", name: "card-list" },
        { token: "plugins", name: "plugin-list" },
        { token: "mods", name: "mod-list" },
        { token: "franchises", name: "franchise-list" },
        { token: "persons", name: "person-list" },
        { token: "categories", name: "category-list" },
        { token: "tags", name: "tag-list" },
        { token: "installed", name: "installed-list" },
        { token: "tasks", name: "task-list" },
      ],
      add: [
        { token: "card", name: "card-add" },
        { token: "plugin", name: "plugin-add" },
        { token: "mod", name: "mod-add" },
        { token: "franchise", name: "franchise-add" },
        { token: "person", name: "person-add" },
        { token: "category", name: "category-add" },
        { token: "tag", name: "tag-add" },
      ],
    };

    return {
      links,
    };
  },

  setup() {
    return { ...useI18n() };
  },
});
</script>

<style lang="scss" scoped>
.menu {
  z-index: 1;
  top: 0;
  position: sticky;
  padding: 20px 0;
  display: grid;
  grid-auto-flow: column;
  justify-content: center;
  gap: 1.5rem;
  background-color: var(--background-color);
}

.group {
  position: relative;

  &:hover {
    .links {
      visibility: visible;
    }
  }
}

.links {
  position: absolute;
  top: 100%;
  right: 0;
  background-color: var(--background-color);
  visibility: hidden;
}

.link {
  line-height: 1;
  white-space: pre;
  padding: 10px 20px;
  display: block;
  text-decoration: none;
}
</style>
