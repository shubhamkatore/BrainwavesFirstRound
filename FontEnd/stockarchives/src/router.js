import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import ViewAllStocks from "./views/ViewAllStocks.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/viewallstocks",
      name: "viewallstocks",
      component: ViewAllStocks
    }
  ]
});
