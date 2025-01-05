import axiosInstance from './axios';
import API_ENDPOINTS from './endpoints';

export const login = async (data) => {
  const response = await axiosInstance.post(API_ENDPOINTS.auth.login, data);
  return response.data;
};

export const register = async (data) => {
  const response = await axiosInstance.post(API_ENDPOINTS.auth.register, data);
  return response.data;
};
