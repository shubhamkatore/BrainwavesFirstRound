<template>
  <div class="home">
    <label>Best Performing Stocks</label>
    <b-tabs type="is-boxed">
      <b-tab-item label="Daily">
        <label v-if="loading" class="loader"></label>
        <b-table :data="dailyData" :columns="dailyColumns"></b-table>
      </b-tab-item>
      <b-tab-item label="Monthly"></b-tab-item>
      <b-tab-item label="Weekly"></b-tab-item>
      <b-tab-item label="Yearly"></b-tab-item>
    </b-tabs>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import axios from "axios";
var apiUrl = "https://brainwaveshackathon.azurewebsites.net/api/";
export default {
  name: "home",
  methods: {
    ...mapGetters(["getHomeData"]),
    ...mapActions(["loadHomePageData"]),
    homePageData() {
      var myData = this;
      axios.get(apiUrl + "stock").then(function(response) {
        myData.loading = false;
        if (response.data) myData.dailyData = response.data;
      });
    }
  },
  mounted() {
    this.homePageData();
    // this.loadHomePageData();
    // this.dailyData = this.getHomeData();
  },
  data() {
    return {
      loading: true,
      sorting: ["status", "asc"],
      dailyData: [
        {
          Name: "",
          Value: ""
        }
      ],
      dailyColumns: [
        {
          field: "Name",
          label: "Name",
          width: "40",
          numeric: true
        },
        {
          field: "Value",
          label: "Value"
        },
        {
          field: "Percentage",
          label: "Percentage"
        }
      ]
    };
  }
};
</script>
<style>
.home {
  margin-left: 15%;
  margin-right: 15%;
}
.loader {
  border: 16px solid #f3f3f3;
  border-radius: 50%;
  border-top: 16px solid #3498db;
  width: 120px;
  height: 120px;
  -webkit-animation: spin 2s linear infinite; /* Safari */
  animation: spin 2s linear infinite;
}
</style>
