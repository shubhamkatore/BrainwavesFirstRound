import Vue from "vue";
import Vuex from "vuex";
import services from "./services";
//import axios from "axios";

Vue.use(Vuex);
//var apiUrl = "https://localhost:44375/api/";
export default new Vuex.Store({
  state: {
    data: [
      {
        symbol: "",
        value: ""
      }
    ]
  },
  getters: {
    getHomeData(state) {
      return state.data;
    }
  },
  mutations: {},
  actions: {
    loadHomePageData: state => {
      // axios.get(apiUrl + "stock").then(function(response) {
      //   debugger;
      //   if (response.data) state.data = response.data;
      // });
      state.data = services.getHomePageDay();
      //debugger;
    }
  }
});
