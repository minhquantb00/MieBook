
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "CartItem";


const getCartItemById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetCartItemById/${id}`);
    return result;
}


const deleteCartItem = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteCartItem/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createCartItem = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateCartItem`, params);
  return result
}

export const CartItemApi = {
  createCartItem,
  deleteCartItem,  getCartItemById
}
