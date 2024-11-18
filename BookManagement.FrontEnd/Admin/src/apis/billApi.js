
import axiosIns from "@/plugin/axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "Bill";


const getBillUserById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetBillById/${id}`);
    return result;
}


const createBill = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateBill`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const BillApi = {
  createBill,  getBillUserById
}
