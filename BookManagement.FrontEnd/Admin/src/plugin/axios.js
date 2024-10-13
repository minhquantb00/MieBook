import LocalStorageKey from '@/constants/LocalStorageKey';
import router from '@/router/index';
import axios from 'axios';

const axiosIns = axios.create({
  baseURL: 'https://localhost:7027/api',
  timeout: 1000,
  // headers: {
  //   Accept: "application/json",
  //   "Content-Type": "application/json",
  //   "Access-Control-Allow-Origin": "*",
  // }
});

axiosIns.interceptors.request.use((config) => {
  const token = sessionStorage.getItem(LocalStorageKey.ACCESS_TOKEN) || localStorage.getItem(LocalStorageKey.ACCESS_TOKEN);
  if(token){
    config.headers = config.headers || {};
    config.headers.Authorization = token ? `Bearer ${JSON.parse(token)}` : "";
  }

  return config;
});

axiosIns.interceptors.request.use((response) => {
  return response;
},
(error) => {
  if(error.response.status === 401){
    localStorage.removeItem(LocalStorageKey.ACCESS_TOKEN);
    localStorage.removeItem(LocalStorageKey.USER_INFO);
    localStorage.removeItem(LocalStorageKey.REFRESH_TOKEN);
    router.push('/login-v1');
  }else{
    return Promise.reject(error);
  }
});
export default axiosIns;
