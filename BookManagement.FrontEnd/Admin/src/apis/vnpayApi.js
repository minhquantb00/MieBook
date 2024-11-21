
import axiosIns from "@/plugin/axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "VnPay";


const vnPayReturn = async () => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/VNPayReturn/`);
    return result;
}

const createVnPayUrl = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateVnPayUrl`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const VnPayApi = {
  createVnPayUrl, vnPayReturn
}
