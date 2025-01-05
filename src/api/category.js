import axiosInstance from './axios';
import API_ENDPOINTS from './endpoints';

export const getAllCategories = async () => {
  const response = await axiosInstance.get(API_ENDPOINTS.category.getAll);
  return response.data;
};
