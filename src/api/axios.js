import axios from 'axios';

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7266/api',
});
  
axiosInstance.interceptors.request.use(
  (config) => {
    if (config.url !== '/login' && config.url !== '/register') {
      const token = localStorage.getItem('token');
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }
    }
    return config;
  },
  (error) => Promise.reject(error)
);

axiosInstance.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      const { response } = error;
  
      if (response && response.data && response.data.error && response.data.error.errors) {
        alert(response.data.error.errors.join('\n'));
      }
  
      return Promise.reject(error);
    }
  );

export default axiosInstance;
