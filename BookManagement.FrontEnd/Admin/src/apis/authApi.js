import { AuthMessage } from "@/constants/enum";
import axiosIns from "@/plugin/axios";
// import axios from "axios";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
const CONTROLLER_NAME = "User";
const errorList = {
  [AuthMessage.ErrorEmailNotActivated]: {
    error: { detail: AuthMessage.EmailNotActivated },
  },
  [AuthMessage.ErrorEmailNotFound]: {
    error: { detail: AuthMessage.LoginError },
  },
  [AuthMessage.ErrorPasswordInvalid]: {
    error: { detail: AuthMessage.LoginError },
  },
  [AuthMessage.ErrorEmailExist]: { error: { detail: AuthMessage.ExistUser } },
  [AuthMessage.ErrorAccountVerified]: {
    error: { detail: AuthMessage.AccountVerified },
  },
};

const login = async (params) => {
  try {
      const result = await axiosIns.post(`${CONTROLLER_NAME}/Login`, params);
      return result;
  } catch (error) {
      if (error.response && error.response.data && error.response.data.detail) {
          return errorList[error.response.data.detail];
      } else {
          return { error: AuthMessage.LoginFail };
      }
  }
};

const register = async (params) => {
  try {
    const result = await axiosIns.post(`${CONTROLLER_NAME}/Register`, params, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
};

const forgotPassword = async (params) => {
  try {
    const result = await axiosIns.post(`${CONTROLLER_NAME}/ForgotPassword`, params);
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
};

const confirmCreateNewPassword = async (params) => {
  try {
    const result = await axiosIns.post(`${CONTROLLER_NAME}/ConfirmCreateNewPassword`, params);
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
};

const getAllUsers = async (param) => {
  try{
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetAllUsers`, {
      params: {
        keyWord: param.keyWord
      }
    });
    return result;
  }
  catch(error){
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
}

const getUserById = async (id) => {
  try{
    const result = await axiosIns.get(`${CONTROLLER_NAME}/GetUserById/${id}`);
    return result;
  }
  catch(error){
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
}

const changePassword = async (params) => {
  try {
    const result = await axiosIns.put(`${CONTROLLER_NAME}/ChangePassword`, params, {
      headers: {
        Authorization: `Bearer ${authorization}`,
      }
    });
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
}

export const AuthApi = {
  register,
  login,
  forgotPassword,
  confirmCreateNewPassword,
  getAllUsers,
  getUserById,
  changePassword
}
