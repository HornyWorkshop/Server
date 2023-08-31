import "normalize.css";

import { createApp } from "vue";
import { router } from "./router";
import { locale } from "./locale";
import { store } from "./store";

import app from "@/app.vue";

createApp(app).use(router).use(locale).use(store).mount("#app");
