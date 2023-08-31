<template>
  <div class="window">
    <div class="window-content">
      <h1>{{ msg }}</h1>

      <p>
        Recommended IDE setup:
        <a href="https://code.visualstudio.com/" target="_blank">VSCode</a>
        +
        <a href="https://marketplace.visualstudio.com/items?itemName=octref.vetur" target="_blank">Vetur</a>
        or
        <a href="https://github.com/johnsoncodehk/volar" target="_blank">Volar</a>
        (if using
        <code>&lt;script setup&gt;</code>)
      </p>

      <p>
        See
        <code>README.md</code> for more information.
      </p>

      <p>
        <a href="https://vitejs.dev/guide/features.html" target="_blank">Vite Docs</a>
        |
        <a href="https://v3.vuejs.org/" target="_blank">Vue 3 Docs</a>
      </p>

      <button type="button" @click="count++">count is: {{ count }}</button>
      <p>
        Edit
        <code>components/HelloWorld.vue</code> to test hot module replacement.
      </p>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
export default defineComponent({
  name: "HelloWorld",
  props: {
    msg: {
      type: String,
      required: true,
    },
  },
  setup: () => {
    const count = ref(0);
    return { count };
  },
});
</script>

<style lang="scss" scoped>
.window {
  margin: auto;
  border: 1px solid transparent;
  text-align: center;
  padding: 20px;

  $borderColor: linear-gradient(to right, var(--border-first-color), var(--border-second-color));

  border-image: $borderColor 1;

  background-color: rgba(0, 0, 0, 0.4);
}

.window2 {
  box-sizing: border-box;
  background-color: transparent;
  position: relative;
  border-radius: 5px;
  border: none;
  overflow: hidden;

  // box-sizing: border-box;
  // background-color: transparent;
  // position: relative;
  // border: none;

  // // background-color: rgba(0, 0, 0, 0.5);
  // padding: 20px;
  // border-radius: 20px;
  // // position: relative;

  &::after {
    box-sizing: border-box;
    position: absolute;
    content: "";
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    border: 30px solid;
    border-radius: 20px;
    border-image: linear-gradient(to right, rgba(255, 255, 255, 0.6), rgba(255, 255, 255, 0.05)) 1;
    z-index: -1;

    // box-sizing: border-box;
    // content: "";
    // // z-index: -1;
    // position: absolute;
    // top: -2px;
    // left: -2px;
    // width: calc(100% + 4px);
    // height: calc(100% + 4px);
    // border-radius: 20px;

    // border: 3px solid;
    // border-image: linear-gradient(
    //   to right,
    //   rgba(255, 255, 255, 0.6),
    //   rgba(255, 255, 255, 0.05)
    // );

    // background: linear-gradient(
    //   to right,
    //   rgba(255, 255, 255, 0.6),
    //   rgba(255, 255, 255, 0.05)
    // );
  }
}
</style>

<style scoped>
a {
  color: #42b983;
}

label {
  margin: 0 0.5em;
  font-weight: bold;
}

code {
  background-color: #eee;
  padding: 2px 4px;
  border-radius: 4px;
  color: #304455;
}
</style>
