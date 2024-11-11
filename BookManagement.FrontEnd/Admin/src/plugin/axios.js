import LocalStorageKey from '@/constants/LocalStorageKey';
import router from '@/router/index';
import axios from 'axios';

const axiosIns = axios.create({
  baseURL: 'https://localhost:7027/api',
  timeout: 10000,
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
