
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "TopicBook";


const getAllTopicBooks = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllTopicBooks`, {
    param: {
        name: params.name
    }
  });
  return result;
}

const getTopicBookById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetTopicBookById/${id}`);
    return result;
}

const updateTopicBook = async (params) => {
  const result = await axiosIns.put(`${CONTROLLER_NAME}/UpdateTopicBook`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const deleteTopicBook = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteTopicBook/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createTopicBook = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateTopicBook`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const ShippingMethodApi = {
  createTopicBook, updateTopicBook,
  deleteTopicBook, getAllTopicBooks, getTopicBookById
}
