<template>
  <section class="list">
    <div class="card" v-for="(node, index) of nodes" :key="index">
      <div class="cover" :style="cardStyle(node.url)" />
      <div class="info">
        <div class="social">
          <div class="button open">open</div>
          <div class="button install">install</div>
          <div class="button like material-icons">&#xe87e;</div>
        </div>
        <div class="name">{{ node.name.en }}</div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  methods: {
    cardStyle(url: string) {
      return {
        backgroundImage: `url(${url})`,
      };
    },
  },

  data() {
    const max = 2;

    const categories = Array.from(Array(max).keys()).map((e, i) => ({
      id: i,
      name: {
        ru: `Category Category Category Category Category ${i}`,
        en: `Category Category Category Category Category ${i}`,
        kr: `Category Category Category Category Category ${i}`,
        jp: `Category Category Category Category Category ${i}`,
      },
    }));

    const tags = Array.from(Array(max).keys()).map((e, i) => ({
      id: i,
      name: {
        ru: `Tag ${i}`,
        en: `Tag ${i}`,
        kr: `Tag ${i}`,
        jp: `Tag ${i}`,
      },
    }));

    const franchises = Array.from(Array(10).keys()).map((e, i) => ({
      id: i,
      name: {
        ru: `Franchise Franchise Franchise Franchise ${i}`,
        en: `Franchise Franchise Franchise Franchise ${i}`,
        kr: `Franchise Franchise Franchise Franchise ${i}`,
        jp: `Franchise Franchise Franchise Franchise ${i}`,
      },
    }));

    const node = {
      url: "https://cdn.discordapp.com/attachments/839938598241697812/856039410113052703/HS2ChaF_20210216230619016_2.png",
      name: {
        ru: "name",
        en: "name",
        kr: "name",
        jp: "name",
      },
      tags,
      categories,
      franchises,
    };

    const nodes = [
      ...Array(6).fill(node),
      // ...Array(32).fill("https://cdn.discordapp.com/attachments/839938598241697812/856039530855268372/HS2ChaF_20210216230619016_1.png"),
    ];

    return { nodes };
  },

  setup() {},
});
</script>

<style lang="scss" scoped>
$width: 252;
$height: 352;
$animDur: 0.11;

.list {
  display: grid;
  grid-template-columns: repeat(auto-fill, $width + px);
  gap: 20px;
}

.card {
  position: relative;
  width: $width + px;
  height: $height + px;
  overflow: hidden;

  &:hover {
    .cover {
      box-shadow: inset 0 0 152px hsla(0, 0%, 0%, 0.8);
      filter: contrast(125%) blur(2px);

      transition: transform var(--anim-dur) var(--anim-tim), box-shadow var(--anim-dur) var(--anim-tim), filter var(--anim-dur) var(--anim-tim);
      transform: scale(0.9);
    }

    .info {
      .social,
      .open,
      .install,
      .like {
        opacity: 1;
      }
    }
  }
}

.cover {
  position: absolute;
  width: inherit;
  height: inherit;
  background-position: center center;
  background-repeat: no-repeat;

  transition: transform var(--anim-dur) var(--anim-tim), box-shadow var(--anim-dur) var(--anim-tim), filter var(--anim-dur) var(--anim-tim);
}

.info {
  display: grid;
  position: absolute;
  width: inherit;
  height: inherit;
  grid-template-rows: auto auto;
  align-content: space-between;

  .name {
    padding: 10px;
    background-color: var(--font-color);
    color: var(--background-color);

    text-align: center;
  }

  .social {
    background-color: var(--font-color);
    padding: 10px;
    display: grid;
    grid-template-columns: auto auto min-content;
    justify-items: center;

    opacity: 0;
    transition: opacity var(--anim-dur) var(--anim-tim);

    .button {
      opacity: 0;

      cursor: pointer;
      color: var(--background-color);

      &:hover {
        color: rgba(255, 0, 102, 0.8);
      }

      &.open {
        transition: opacity var(--anim-dur) var(--anim-tim) $animDur * 3 + s;
      }

      &.install {
        transition: opacity var(--anim-dur) var(--anim-tim) $animDur * 2 + s;
      }

      &.like {
        transition: opacity var(--anim-dur) var(--anim-tim) $animDur * 1 + s;
      }

      &.like {
        font-size: inherit;
        line-height: inherit;
      }
    }
  }
}
</style>
