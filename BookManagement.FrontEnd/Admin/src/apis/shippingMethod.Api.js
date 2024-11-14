
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "ShippingMethod";


const getAllShippingMethods = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllShippingMethods`, {
    param: {
        name: params.name
    }
  });
  return result;
}

const getShippingMethodById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetShippingMethodById/${id}`);
    return result;
}

const updateShippingMethod = async (params) => {
  const result = await axiosIns.put(`${CONTROLLER_NAME}/UpdateShippingMethod`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const deleteShippingMethod = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteShippingMethod/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createShippingMethod = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateShippingMethod`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const ShippingMethodApi = {
  createShippingMethod, updateShippingMethod,
  deleteShippingMethod, getAllShippingMethods, getShippingMethodById
}
