
import axiosIns from "@/plugin/axios";

const CONTROLLER_NAME = "Cart";


const getCartById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetCartById/${id}`);
    return result;
}


const createCart = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateCart`, params);
  return result
}

export const CartApi = {
  createCart,  getCartById
}
