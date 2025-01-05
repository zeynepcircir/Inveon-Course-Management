import axiosInstance from './axios';
import API_ENDPOINTS from './endpoints';

export const makePayment = async (data) => {
  const response = await axiosInstance.post(API_ENDPOINTS.payment.makePayment, data);
  return response.data;
};
