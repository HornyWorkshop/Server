import { defineStore } from "pinia";

export const useContentStore = defineStore({
  id: "content",

  state: () => ({
    franchises: [] as string[],
    persons: [] as string[],
    categories: [] as string[],
    tags: [] as string[],
    cards: [] as string[],
    plugins: [] as string[],
    mods: [] as string[],
  }),
});
