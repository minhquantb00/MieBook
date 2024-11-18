
import axiosIns from "@/plugin/axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "AddressUser";


const getAddressUserById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAddressUserById/${id}`);
    return result;
}

const getAllAddressUsers = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllAddressUsers/`, {
    param: {
        userId: params.userId
    }
  });
  return result;
}
const getAddressUserByUserId = async (id) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAddressUserByUserId/${id}`);
  return result;
}

const createAddressUser = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateAddressUser`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const AddressUserApi = {
  createAddressUser,  getAddressUserByUserId, getAddressUserById, getAllAddressUsers
}
