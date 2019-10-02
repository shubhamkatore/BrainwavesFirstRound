<template>
  <div class="viewallstocks">
    <label>View All Stocks</label>
    <b-loading :is-full-page="openOnFocus" :active="openOnFocus" :can-cancel="true"></b-loading>
    <b-tabs v-model="tabId" type="is-boxed">
      <b-tab-item label="By Symbol/Name">
        <b-field label="Stock Name" class="inline">
          <b-autocomplete
            rounded
            class="mar inline"
            v-model="name"
            placeholder="Type Stock Name"
            :open-on-focus="openOnFocus"
            :data="filteredDataObj"
            field="symbol"
          >
            <template slot="empty">No results found</template>
          </b-autocomplete>
        </b-field>
        <button class="button is-primary mar" @click="getStockByName">Get Data</button>
        <label v-if="loading" class="loader"></label>
        <div class="current">
          <label>Currently Viewing :</label>
          <label v-text=" data[0].symbol"></label>
        </div>
        <b-table
          :data="data"
          :paginated="isPaginated"
          :per-page="perPage"
          :current-page.sync="currentPage"
          :pagination-simple="isPaginationSimple"
          :columns="columns"
        ></b-table>
      </b-tab-item>
      <b-tab-item label="By Date">
        <b-field label="Select a date" class="inline">
          <b-datepicker
            class="inline"
            placeholder="Click to select..."
            icon="calendar-today"
            v-model="focusedDate"
            :focused-date="focusedDate"
            :min-date="minDate"
            :max-date="maxDate"
          ></b-datepicker>
        </b-field>
        <button class="button is-primary mar" @click="getStockByDate">Get Data</button>
        <label v-if="loading" class="loader"></label>
        <div class="current">
          <label>Current Date :</label>
          <label v-text=" dateData[0].date"></label>
        </div>
        <b-table
          :data="dateData"
          :paginated="isPaginated"
          :per-page="perPage"
          :current-page.sync="currentPageDate"
          :pagination-simple="isPaginationSimple"
          :columns="dateColumns"
        ></b-table>
      </b-tab-item>
    </b-tabs>
  </div>
</template>

<script>
import axios from "axios";
var apiUrl = "https://brainwaveshackathon.azurewebsites.net/api/";
export default {
  name: "viewallstocks",
  mounted() {
    var myData = this;
    axios.get(apiUrl + "stock/names").then(function(response) {
      if (response.data) myData.filteredDataObj = response.data;
    });
    this.getStockByName();
    this.getStockByDate();
    //this.data = myData;
  },
  methods: {
    getStockByName() {
      var myData = this;
      myData.loading = true;
      axios.get(apiUrl + "stock/names/" + this.name).then(function(response) {
        if (response.data) myData.data = response.data;
        myData.loading = false;
      });
    },
    getStockByDate() {
      var d = this.focusedDate,
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();
      if (month.length < 2) month = "0" + month;
      if (day.length < 2) day = "0" + day;
      var formattedDate = [year, month, day].join("-");
      var myData = this;
      myData.loading = true;
      axios
        .get(apiUrl + "stock/date/" + formattedDate)
        .then(function(response) {
          if (response.data) myData.dateData = response.data;
          myData.loading = false;
        });
    }
    // toggleColumnData() {
    //   this.columns[0] =
    //     this.tabId == 0
    //       ? {
    //           field: "date",
    //           label: "Date",
    //           width: "40"
    //         }
    //       : {
    //           field: "symbol",
    //           label: "Name",
    //           width: "40"
    //         };
    // }
  },
  data() {
    return {
      loading: true,
      tabId: 0,
      filteredDataObj: [{ symbol: "" }],
      openOnFocus: true,
      isPaginated: true,
      isPaginationSimple: false,
      defaultSortDirection: "asc",
      currentPage: 1,
      currentPageDate: 1,
      perPage: 10,
      focusedDate: new Date("2016-12-30"),
      minDate: new Date("2010-01-04"),
      maxDate: new Date("2016-12-30"),
      name: "WLTW",
      data: [
        {
          symbol: "",
          value: "",
          status: ""
        }
      ],
      dateData: [
        {
          symbol: "",
          value: "",
          status: ""
        }
      ],
      dateColumns: [
        {
          field: "symbol",
          label: "Name",
          width: "40"
        },
        {
          field: "open",
          label: "Open"
        },
        {
          field: "close",
          label: "Close"
        },
        {
          field: "low",
          label: "Low"
        },
        {
          field: "high",
          label: "High"
        },
        {
          field: "volume",
          label: "Volume"
        }
      ],
      columns: [
        {
          field: "date",
          label: "Date",
          width: "40"
        },
        {
          field: "open",
          label: "Open"
        },
        {
          field: "close",
          label: "Close"
        },
        {
          field: "low",
          label: "Low"
        },
        {
          field: "high",
          label: "High"
        },
        {
          field: "volume",
          label: "Volume"
        }
      ]
    };
  },
  computed: {
    // dateColumns() {
    //   var columns = this.columns;
    //   columns[0] = {
    //     field: "symbol",
    //     label: "Name",
    //     width: "40"
    //   };
    //   return columns;
    // }
  },
  watch: {
    // tabId: function(value) {
    //   this.toggleColumnData();
    // }
  }
};
</script>
<style>
.viewallstocks {
  margin-left: 15%;
  margin-right: 15%;
}
.mar {
  margin-left: 20px;
}
.current {
  font-weight: bold;
}
.inline {
  display: inline-block !important;
}
.label {
  display: inline-block !important;
}
</style>

