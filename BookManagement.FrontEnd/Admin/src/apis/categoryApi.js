
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "Category";


const getAllCategories = async (params) => {
  const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllCategories`, {
    param: {
        name: params.name
    }
  });
  return result;
}

const getCategoryById = async (id) => {
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetCategoryById/${id}`);
    return result;
}

const updateCategory = async (params) => {
  const result = await axiosIns.put(`${CONTROLLER_NAME}/UpdateCategory`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const deleteCategory = async (id) => {
  const result = await axiosIns.delete(`${CONTROLLER_NAME}/DeleteCategory/${id}`,{
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

const createCategory = async (params) => {
  const result = await axiosIns.post(`${CONTROLLER_NAME}/CreateCategory`, params, {
    headers: {
      Authorization: `Bearer ${authorization}`,
    }
  });
  return result
}

export const CategoryApi = {
  createCategory, updateCategory,
  deleteCategory, getAllCategories, getCategoryById
}
