import axios from "axios";

const api = axios.create({
  baseURL: 'http://localhost:5148/api'
});

// console.log("Axios baseURL:", api.defaults.baseURL);

export default api;