
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "Voucher";


const getAllVouchers = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllVouchers`, {
    params: {
        name: params.name
    }
  });
  return result;
}

const getVoucherById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetVoucherById/${id}`);
    return result;
}

const updateVoucher = async (params) => {
  const result = await axiosIns.put(`${CONTROLLER_NAME}/UpdateVoucher`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const deleteVoucher = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteVoucher/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createVoucher = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateVoucher`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const VoucherApi = {
  createVoucher, updateVoucher,
  deleteVoucher, getAllVouchers, getVoucherById
}
