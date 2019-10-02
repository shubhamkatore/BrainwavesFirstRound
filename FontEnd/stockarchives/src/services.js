import axios from "axios";

var apiUrl = "https://brainwaveshackathon.azurewebsites.net/api/";

export default {
  async getHomePageDay() {
    var data = await axios
      .get(apiUrl + "stock")
      .then(function(response) {
        return response.data;
      })
      .catch(function(error) {
        console.log(error);
      });
    return data;
  }
};
