import { createI18n } from "vue-i18n";

const franchise = {};
const person = {};
const tag = {};
const category = {};

const ui = {
  guid: "GUID",
  lang: {
    en: "English",
    ru: "Русский",
    jp: "日本語",
    kr: "한국어",
  },
  header: {
    menu: {
      content_text: "Content",
      content: {
        home: "Home",
        cards: "Cards",
        plugins: "Plugins",
        mods: "Mods",
        franchises: "Franchises",
        persons: "Persons",
        categories: "Categories",
        tags: "Tags",
        installed: "Installed",
        tasks: "Tasks",
      },
      add_text: "Add",
      add: {
        card: "Add card",
        plugin: "Add plugin",
        mod: "Add mod",
        franchise: "Add franchise",
        person: "Add person",
        category: "Add category",
        tag: "Add tag",
      },
    },
  },
  franchises: {
    add: "Add franchise",
  },
  new: "New",
  download: "Download",
};

const values = { ui, franchise, person, tag, category };

const langs = {
  en: { ...JSON.parse(JSON.stringify(values)) },
  ru: { ...JSON.parse(JSON.stringify(values)) },
  jp: { ...JSON.parse(JSON.stringify(values)) },
  kr: { ...JSON.parse(JSON.stringify(values)) },
};

const messages = {
  ...langs,
};

export const locale = createI18n({
  locale: "en",
  messages,
});
