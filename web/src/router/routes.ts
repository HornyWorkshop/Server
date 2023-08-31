import { RouteRecordRaw } from "vue-router";

import CardsView from "../views/CardsView.vue";
import HomeView from "../views/HomeView.vue";

export const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/home",
  },
  {
    path: "/home",
    name: "home",
    component: HomeView,
  },
  {
    path: "/cards",
    name: "cards",
    component: CardsView,
  },
];
