
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "Book";


const getAllBooks = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllBooks`, {
    param: {
        topicBookId: params.topicBookId
    }
  });
  return result;
}

const getBookById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetBookById/${id}`);
    return result;
}

const updateBook = async (params) => {
  const result = await axiosIns.put(`${CONTROLLER_NAME}/UpdateBook`, params, {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const deleteBook = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteBook/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createBook = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateBook`, params, {
    headers: {
      "Content-Type": "multipart/form-data",
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const BookApi = {
  createBook, updateBook,
  deleteBook, getAllBooks, getBookById
}
