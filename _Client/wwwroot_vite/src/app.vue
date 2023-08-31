<template>
  <TheHeader />
  <RouterView class="router-view" />
</template>

<script lang="ts">
import { defineComponent, defineAsyncComponent, provide } from "vue";
import { DefaultApolloClient } from "@vue/apollo-composable";

import { ApolloClient, InMemoryCache } from "@apollo/client/core";

const client = new ApolloClient({
  uri: "https://localhost:5001/graphql",
  cache: new InMemoryCache(),
});

export default defineComponent({
  setup() {
    provide(DefaultApolloClient, client);
  },

  components: {
    TheHeader: defineAsyncComponent(() => import("@/components/the-menu.vue")),
  },
});
</script>

<style lang="scss">
:root {
  --font-color: rgba(255, 255, 255, 0.9);
  --font-hover-color: rgba(255, 255, 255, 0.4);

  --border-first-color: var(--font-hover-color);
  --border-second-color: rgba(255, 255, 255, 0.05);

  --list-hover-color: var(--border-second-color);

  --background-color: #09090d;
  --first-background-color: rgb(12, 14, 16);
  --second-background-color: rgb(15, 24, 34);

  --link-color: var(--font-hover-color);
  --link-hover-color: var(--font-color);

  --secondary-color: #111116;
}

:root {
  --anim-dur: 0.33s;
  --anim-tim: ease;
}

html {
  min-height: 100%;
  font-size: 18px;
}

body {
  background-color: var(--background-color);
  color: var(--font-color);
}

a {
  color: var(--link-color);
  transition: color var(--anim-dur) var(--anim-tim);

  &.router-link-exact-active,
  &:hover {
    color: var(--link-hover-color);
  }

  &.router-link-exact-active {
    cursor: default;
  }
}

#app {
  font-family: "Padauk", "Material Icons", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>

<style lang="scss" scoped>
.router-view {
  margin: 0 5vw;
  padding: 20px;
}
</style>
