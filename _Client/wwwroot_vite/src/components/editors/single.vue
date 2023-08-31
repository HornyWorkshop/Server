<template>
  <section class="editor">
    <ContributionMessage />
    <div class="entries">
      <!-- Header -->
      <div class="guid header">{{ t("ui.guid") }}</div>
      <template v-for="locale of availableLocales" :key="locale">
        <div class="locale header">{{ t(`ui.lang.${locale}`) }}</div>
      </template>

      <!-- Body -->
      <template v-for="value of values" :key="value">
        <div class="guid entry">{{ value }}</div>

        <template v-for="locale of availableLocales" :key="locale">
          <input class="value entry" v-model="messages[locale][id][value]" />
        </template>
      </template>
    </div>
    <div class="buttons">
      <div class="button" @click.prevent="onAdd">{{ t("ui.new") }}</div>
      <div class="button" @click.prevent="onDownload">{{ t("ui.download") }}</div>
    </div>
  </section>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent, ref } from "vue";
import { v4 as uuid } from "uuid";
import { useI18n } from "vue-i18n";
import { downloadZip } from "@/core";

export default defineComponent({
  props: {
    id: {
      type: String,
      required: true,
    },
    source: {
      type: Array,
      default: () => [],
      // required: true,
    },
  },

  methods: {
    onAdd() {
      const value = uuid();
      this.values.push(value);

      for (const locale of this.availableLocales) {
        (this.messages as any)[locale][this.id][value] = "";
        this.mergeLocaleMessage(locale, { [`${this.id}.${value}`]: "" });
      }
    },

    onDownload() {
      return downloadZip(this.id, this.values, this.messages);
    },

    onUpdate(locale: string, guid: string, value: string) {
      this.mergeLocaleMessage(locale, { [`${this.id}.${guid}`]: value });
    },
  },

  setup(props) {
    const { t, mergeLocaleMessage, messages, availableLocales } = useI18n();

    const values = ref(props.source);
    return { values, t, mergeLocaleMessage, messages, availableLocales };
  },

  components: {
    ContributionMessage: defineAsyncComponent(() => import("@/components/editors/contribution-message.vue")),
  },
});
</script>

<style lang="scss" scoped>
.entries {
  --columns-count: 4;

  margin-bottom: 10px;
  display: grid;
  align-items: center;
  grid-template-columns: min-content repeat(var(--columns-count), min-content); // repeat(auto-fill, minmax(400px, 1fr));

  gap: 10px;

  .header {
    // border-bottom: 1px solid transparent;
    // border-image: linear-gradient(to right, var(--border-first-color), var(--border-second-color)) 1;
    padding: 10px;
    font-weight: 700;
    text-transform: uppercase;
  }

  .entry {
    white-space: pre;

    &.guid {
      text-transform: uppercase;
    }
  }

  // .locales {
  //   padding: 10px 10px 0 10px;
  //   display: grid;
  //   grid-template-columns: auto 1fr;
  //   gap: 10px;
  //   align-items: center;

  .value {
    padding: 10px;
    background-color: transparent;
    border: none;
    border-bottom: 1px solid var(--border-second-color);

    transition: border-color var(--anim-dur) var(--anim-tim), color var(--anim-dur) var(--anim-tim);
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
}

.button {
  cursor: pointer;
  padding: 10px 20px;
  width: min-content;
  white-space: pre;

  background-color: var(--border-second-color);
  transition: background-color var(--anim-dur) var(--anim-tim);

  &:hover {
    background-color: var(--font-hover-color);
  }
}

.buttons {
  display: flex;
}
</style>
