import { createWebHistory, createRouter } from "vue-router";

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("@/views/home.vue"),
  },
  {
    path: "/card/list",
    name: "card-list",
    component: () => import("@/views/card/list.vue"),
  },
  {
    path: "/plugin/list",
    name: "plugin-list",
    component: () => import("@/views/plugin/list.vue"),
  },
  {
    path: "/mod/list",
    name: "mod-list",
    component: () => import("@/views/mod/list.vue"),
  },
  {
    path: "/franchise/list",
    name: "franchise-list",
    component: () => import("@/views/franchise/list.vue"),
  },
  {
    path: "/person/list",
    name: "person-list",
    component: () => import("@/views/person/list.vue"),
  },
  {
    path: "/category-list",
    name: "category-list",
    component: () => import("@/views/category/list.vue"),
  },
  {
    path: "/tag/list",
    name: "tag-list",
    component: () => import("@/views/tag/list.vue"),
  },
  {
    path: "/installed/list",
    name: "installed-list",
    component: () => import("@/views/installed/list.vue"),
  },
  {
    path: "/task/list",
    name: "task-list",
    component: () => import("@/views/task/list.vue"),
  },
  {
    path: "/card/add",
    name: "card-add",
    component: () => import("@/views/card/add.vue"),
  },
  {
    path: "/plugin/add",
    name: "plugin-add",
    component: () => import("@/views/plugin/add.vue"),
  },
  {
    path: "/mod/add",
    name: "mod-add",
    component: () => import("@/views/mod/add.vue"),
  },
  {
    path: "/franchise/add",
    name: "franchise-add",
    component: () => import("@/views/franchise/add.vue"),
  },
  {
    path: "/person/add",
    name: "person-add",
    component: () => import("@/views/person/add.vue"),
  },
  {
    path: "/category-add",
    name: "category-add",
    component: () => import("@/views/category/add.vue"),
  },
  {
    path: "/tag/add",
    name: "tag-add",
    component: () => import("@/views/tag/add.vue"),
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
