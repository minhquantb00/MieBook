
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "BookReview";



const getBookReviewById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetBookReviewById/${id}`);
    return result;
}


const deleteBookReview = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteBookReview/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createBookReview = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateBookReview`, params, {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const BookReviewApi = {
  createBookReview,
  deleteBookReview, getBookReviewById
}

